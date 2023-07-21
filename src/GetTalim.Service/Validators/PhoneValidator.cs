namespace GetTalim.Service.Validators;

public class PhoneValidator
{
    public static bool IsValid(string phone)
    {
        if (phone.Length != 13) return false;
        if (phone.StartsWith("+998") == false) return false;

        for (int i = 1;  i < phone.Length; i++)
        {
            if (char.IsDigit(phone[i])) continue;
            else return false;
        }

        return true;
    }
}
