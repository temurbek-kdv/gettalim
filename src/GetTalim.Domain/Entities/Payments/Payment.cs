namespace GetTalim.Domain.Entities.Payments;

public class Payment : Auditable
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public bool IsPaid { get; set; } = false;
}
