using Dapper;
using GetTalim.DataAccess.Interfaces.CourseViewModels;
using GetTalim.DataAccess.ViewModels;

namespace GetTalim.DataAccess.Repositories.CourseViewModels;

public class CourseViewModelRepository : BaseRepository, ICourseViewModelRepository
{
    public async Task<IList<CourseViewModel?>> GetCourseViewByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = @" SELECT kurs.id, kurs.name, kurs.description, kurs.information, kurs.lessons, 
kurs.hours, kurs.level, kurs.language, kurs.image_path, kurs.price,  
kurs.discount_price, kurs.mentor_id, kurs.category_id,  
kurs.updated_at, ustoz.first_name AS mentor, req.requirment, 
ben.name AS benefit  
FROM courses kurs JOIN  
course_requirments req ON req.course_id = kurs.id 
JOIN course_benefits ben ON ben.course_id = kurs.id 
JOIN mentors ustoz ON kurs.mentor_id = ustoz.id; ";
            var result = (await _connection.QueryAsync<CourseViewModel?>(query, new {Id = id})).ToList();
            return result;
               
        }
        catch
        {
            return new List<CourseViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
