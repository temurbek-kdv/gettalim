using GetTalim.Domain.Entities.Payments;

namespace GetTalim.DataAccess.ViewModels;

public class PaymentViewModel : Payment
{
    public string studentEmail { get; set; } = string.Empty;
    public string courseName {  get; set; } = string.Empty;
}
