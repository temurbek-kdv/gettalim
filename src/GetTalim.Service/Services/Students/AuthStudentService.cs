using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.Domain.Entities.Students;
using GetTalim.Domain.Exceptions.Auth;
using GetTalim.Domain.Exceptions.Students;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Common.Security;
using GetTalim.Service.Dtos.Notifications;
using GetTalim.Service.Dtos.Security;
using GetTalim.Service.Dtos.Students;
using GetTalim.Service.Dtos.StudentsAuth;
using GetTalim.Service.Interfaces.Notifications;
using GetTalim.Service.Interfaces.Students;
using Microsoft.Extensions.Caching.Memory;


namespace GetTalim.Service.Services.Students;

public class AuthStudentService : IAuthStudentService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IStudentRepository _studentRepository;
    private readonly IMailSender _mailSender;
    private readonly ITokenStudentService _tokenStudentService;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    private const string REGISTER_CACHE_KEY = "register_";
    private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
    private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

    public AuthStudentService(IMemoryCache memoryCache,
        IStudentRepository studentRepository,
        IMailSender mailSender,
        ITokenStudentService tokenStudentService)
    {
        this._memoryCache = memoryCache;
        this._studentRepository = studentRepository;
        this._mailSender = mailSender;
        this._tokenStudentService = tokenStudentService;
    }

 

#pragma warning disable
    public async Task<(bool Result, int CashedMinutes)> RegisterAsync(StudentRegisterDto registerDto)
    {
        var student = await _studentRepository.GetByEmailAsync(registerDto.Email);
        if (student is not null) throw new StudentAlreadyExistsException(registerDto.Email);

        // delete if exists user by this phone number
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + registerDto.Email, out StudentRegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(REGISTER_CACHE_KEY + registerDto.Email);
        }
        else _memoryCache.Set(REGISTER_CACHE_KEY + registerDto.Email, registerDto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CashedVerificationMinutes)> SendCodeForRegisterAsync(string mail)
    {
        if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + mail, out StudentRegisterDto registerDto))
        {
            StudentVerificationDto verificationDto = new StudentVerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

           
            // verificationDto.Code = CodeGenerator.GenerateRandomNumber();
            verificationDto.Code = 12345;


            if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + mail, out StudentVerificationDto oldDto))
            {
                _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + mail);
            }
            _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + mail, verificationDto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            EmailMessage emailSms = new EmailMessage();
            emailSms.Title = "Get Ta'lim";
            emailSms.Content = "Verification code : " + verificationDto.Code;
            emailSms.Recipent = mail;

            var mailResult = await _mailSender.SendAsync(emailSms);
            if (mailResult is true) return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            else return (Result: false, CachedVerificationMinutes: 0);
        }
        else throw new StudentCacheDataExpiredException(); 
    }


    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string mail, int code)
    {
        if(_memoryCache.TryGetValue(REGISTER_CACHE_KEY + mail, out StudentRegisterDto registroDto))
        {
            if(_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + mail, out StudentVerificationDto verificationDto))
            {
                if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                    throw new VerificationTooManyRequestsException();
                else if (verificationDto.Code == code)
                {
                    var dbResult = await RegisterToDatabaseAsync(registroDto);
                    if(dbResult is true)
                    {
                        var student = await _studentRepository.GetByEmailAsync(mail);
                        string token = _tokenStudentService.GenerateToken(student);
                        return (Result: true, Token: token);
                    }
                    else return (Result: false, Token: "");
                }
                else
                {
                    _memoryCache.Remove(VERIFY_REGISTER_CACHE_KEY + mail);
                    verificationDto.Attempt++;
                    _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + mail, verificationDto,
                        TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));
                    return (Result: false, Token: "");
                }
            }
            else throw new VerificationCodeExpiredException();
        }
        else throw new StudentCacheDataExpiredException();
    }

    private async Task<bool> RegisterToDatabaseAsync(StudentRegisterDto registroDto)
    {
        var student = new Student();
        student.FirstName = registroDto.FirstName;
        student.LastName = registroDto.LastName;
        student.Email = registroDto.Email.ToLower();
        student.IsEmailConfirmed = true;

        var hasherResult = PasswordHasher.Hash(registroDto.Password);
        student.PasswordHash = hasherResult.Hash;
        student.Salt = hasherResult.Salt;

        student.CreatedAt = student.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _studentRepository.CreateAsync(student);
        return dbResult > 0;
    }

    public async Task<(bool Result, string Token)> LoginAsync(StudentLoginDto loginDto)
    {
        var student = await _studentRepository.GetByEmailAsync(loginDto.Email.ToLower());
        if(student is null) throw new StudentNotFoundException();

        var hasherResult = PasswordHasher.Verify(loginDto.Password, student.PasswordHash, student.Salt);
        if (hasherResult == false) throw new PasswordNotMatchException();

        string token = _tokenStudentService.GenerateToken(student);

        return (Result: true, Token: token);
    }
}
