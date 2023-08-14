using Dapper;
using GetTalim.DataAccess.Interfaces.CourseRequierments;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.CourseRequierments;

public class CourseRequirmentRepository : BaseRepository, ICourseRequiermentRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(CourseRequirment entity)
    {

        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.course_requirments(requirment, course_id, " +
                "created_at, updated_at)VALUES (@Requirment, @CourseId, @CreatedAt, @UpdatedAt);";

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

    public async Task<int> DeleteAsync(long id)
    {

        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM course_requirments WHERE id = @Id;";

            var result = await _connection.ExecuteAsync(query, new {Id = id});
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

    public async Task<IList<CourseRequirment>> GetAllAsync(PaginationParams @params)
    {

        try
        {
            await _connection.OpenAsync();  
            string query = "SELECT * FROM course_requirments ORDER BY id DESC ;";

            var result = (await _connection.QueryAsync<CourseRequirment>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseRequirment>(); 
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseRequirment?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_requirments WHERE id = @Id";

            var result = await _connection.QuerySingleAsync<CourseRequirment>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<CourseRequirment>> GetCourcseRequirmentsAsync(long id)
    {
       try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_requirments WHERE course_id = @Id";
            var result = (await _connection.QueryAsync<CourseRequirment>(query, new {Id = id})).ToList();
            
            return result;
        }
        catch
        {
            return new List<CourseRequirment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> UpdateAsync(long id, CourseRequirment entity)
    {
        throw new NotImplementedException();
    }
}
