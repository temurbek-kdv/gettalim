namespace GetTalim.DataAccess.ViewModels;

public class CourseViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Information { get; set; } = string.Empty;
    public int Lessons { get; set; }
    public double Hours { get; set; }
    public string Level { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Discount_price { get; set; }
    public int MentorId { get; set; }
    public int CategoryId { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Mentor { get; set; } = string.Empty;
    public string Requirment { get; set; } = string.Empty;
    public string Benefit { get; set; } = string.Empty;

}
