using GetTalim.DataAccess.Interfaces.Payments;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Payments;
using GetTalim.Domain.Exceptions.Payments;
using GetTalim.Service.Common.Helpers;
using GetTalim.Service.Dtos.Payment;
using GetTalim.Service.Interfaces.Payments;

namespace GetTalim.Service.Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        this._repository = repository;   
    }

    public async Task<bool> CreateAsync(PaymentCreateDto dto)
    {
        Payment payment = new Payment();
        payment.CourseId = dto.CourseId;
        payment.StudentId = dto.StudentId;
        payment.IsPaid = dto.IsPaid;
        payment.CreatedAt = payment.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.CreateAsync(payment);
        return dbResult > 0;
    }
    public async Task<Payment> GetByIdAsync(long paymentId)
    {
        var payment = await _repository.GetByIdAsync(paymentId);
        if (payment is null) throw new PaymentNotFoundException();
        else return payment;
    }

    public async Task<bool> DeleteAsync(long paymentId)
    {
        var payment = await _repository.GetByIdAsync(paymentId);
        if (payment is null) throw new PaymentNotFoundException();
        var result = await _repository.DeleteAsync(paymentId);
        return result > 0;
    }

    public async Task<IList<Payment>> GetAllAsync(PaginationParams @params)
    {
        var videos = await _repository.GetAllAsync(@params);
        return videos;
    }

    public async Task<bool> UpdateAsync(long paymentId, PaymentCreateDto dto)
    {
        var payment = await _repository.GetByIdAsync(paymentId);
        if (payment is null) throw new PaymentNotFoundException();

        payment.UpdatedAt = TimeHelper.GetDateTime();
        payment.IsPaid = dto.IsPaid;
        payment.CourseId = dto.CourseId;
        payment.StudentId = dto.StudentId;

        var dbResult = await _repository.UpdateAsync(paymentId, payment);
        return dbResult > 0;
    }

    public Task<long> CountAllAsync()
    {
        throw new NotImplementedException();
    }
}
