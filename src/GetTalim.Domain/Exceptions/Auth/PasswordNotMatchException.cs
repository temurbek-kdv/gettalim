﻿namespace GetTalim.Domain.Exceptions.Auth;

public class PasswordNotMatchException : BadRequestException
{
    public PasswordNotMatchException()
    {
        TitleMessage = "Password is invalid";
    }
}
