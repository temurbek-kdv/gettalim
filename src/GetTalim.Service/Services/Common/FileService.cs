using GetTalim.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using GetTalim.Service.Common.Helpers;
using static System.Net.Mime.MediaTypeNames;


namespace GetTalim.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string AVATARS = "avatars";
    private readonly string ROOTHPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTHPATH = env.WebRootPath;
    }

    public async Task<bool> DeleteAvatarAsync(string subpath)
    {
        string path = Path.Combine(ROOTHPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTHPATH, subpath);
        if(File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        string newImageName = MediaHelpers.MakeImageName(avatar.FileName);
        string subPath = Path.Combine(MEDIA, AVATARS, newImageName);
        string path = Path.Combine(ROOTHPATH, subPath);

        var stream = new FileStream(path, FileMode.Create);
        await avatar.CopyToAsync(stream);
        return subPath;
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelpers.MakeImageName(image.FileName);
        string subPath = Path.Combine(MEDIA, IMAGES, newImageName);
        string path = Path.Combine(ROOTHPATH, subPath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        return subPath;

    }
}
