namespace GetTalim.Domain.Entities.Courses;

public class WhatYouLearn : Auditable
{
    public string Name { get; set; } = string.Empty;
    public long CourseId { get; set; }

}
