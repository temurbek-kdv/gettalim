namespace GetTalim.Service.Dtos.Payment;

public class PaymentCreateDto
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public bool IsPaid { get; set; } 
}
