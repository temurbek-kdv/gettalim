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
            string query = "SELECT * FROM course_viewmodel WHERE  id = @Id";
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
