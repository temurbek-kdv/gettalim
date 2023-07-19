﻿namespace GetTalim.Service.Common.Helpers;

public class MediaHelpers
{
    public static string MakeImageName (string fileName)
    {
        FileInfo fileInfo = new FileInfo (fileName);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;
        return name;
    }

}
