namespace GetTalim.Service.Dtos.Payment;

public class PaymentUpdateDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public bool IsPaid { get; set; }
}
