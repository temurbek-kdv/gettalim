using Dapper;
using GetTalim.DataAccess.Interfaces.CourseModuls;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;

namespace GetTalim.DataAccess.Repositories.CourseModuls;

public class CourseModulRepository : BaseRepository, ICourseModulRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(CourseModul entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.course_moduls (name, course_id, created_at, updated_at) " +
                " VALUES (@Name, @CourseId, @CreatedAt, @UpdatedAt) ;";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch 
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<CourseModul?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_moduls WHERE id = @Id ";

            var result = await _connection.QuerySingleAsync<CourseModul>(query, new {Id = id});
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync() ;
            string query = "DELETE FROM course_moduls WHERE id = @Id; ";

            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<CourseModul>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_moduls order by id desc";

            var result = (await _connection.QueryAsync<CourseModul>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseModul>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }


    public async Task<int> UpdateAsync(long id, CourseModul entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE course_moduls SET  name=@Name, " +
                " course_id=@CourseId, created_at=@CreatedAt, updated_at=@UpdatedAt WHERE id = @Id ; ";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<CourseModul>> GetByCourseIdAsync(long courseId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $" SELECT * FROM course_moduls where course_id = {courseId} ";

            var result = await _connection.QueryAsync<CourseModul>(query);
            
            return result.ToList();
        }
        catch
        {
            return new List<CourseModul>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
