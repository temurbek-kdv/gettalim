namespace GetTalim.Service.Validators;

public class PasswordValidator
{
    public static string Symbols { get; } = "~`!@#$%^&*()_-+={[}]|\\:;\"'<,>.?/";

    public static (bool IsValid, string Message) IsStrongPassword (string password)
    {
        if (password.Length < 8) return (IsValid: false, Message: "Password can not be less than 8 characters");
        bool isUppercase = false;
        bool isLowercase = false;
        bool isNumberExits = false;
        bool isCharacterExits = false;

        foreach (var item in  password)
        {
            if (char.IsUpper(item)) isUppercase = true;
            if (char.IsLower(item)) isLowercase = true;
            if (char.IsNumber(item)) isNumberExits = true;
            if (Symbols.Contains(item)) isCharacterExits = true;
        }

        if (isUppercase is false) return (IsValid: false, Message: "Password should contain at least one Uppercase letter");
        if (isLowercase is false) return (IsValid: false, Message: "Password should contain at least one Lowercase letter");
        if (isNumberExits is false) return (IsValid: false, Message: "Password should contain at least one Number");
        if (isCharacterExits is false) return (IsValid: false, Message: "Password should contain at least one Character");

        return (IsValid: true, Message: "");
    }
}
