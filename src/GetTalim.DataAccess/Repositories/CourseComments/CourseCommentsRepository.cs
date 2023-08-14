using Dapper;
using GetTalim.DataAccess.Interfaces.CourseComments;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;


namespace GetTalim.DataAccess.Repositories.CourseComments;

public class CourseCommentsRepository : BaseRepository, ICourseCommentsRepository
{
    public  Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(CourseComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO course_comments(comment, student_id, course_id, created_at, updated_at) " +
                "VALUES(@Comment, @StudentId, @CourseId, @CreatedAt, @UpdatedAt) ;";

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
            string query = "DELETE FROM course_comments WHERE id = @Id;";

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

    public async Task<IList<CourseComment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_comments ORDER BY id DESC ;";

            var result = (await _connection.QueryAsync<CourseComment>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseComment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseComment?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_comments WHERE id = @Id";

            var result = await _connection.QuerySingleAsync<CourseComment>(query, new { Id = id });
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

    public async Task<IList<CourseComment>> GetCourseComments(long id)
    {
        try
        {
            await  _connection.OpenAsync();
            string query = "SELECT * FROM course_comments WHERE course_id = @Id";
            var result = (await _connection.QueryAsync<CourseComment>(query, new { Id = id })).ToList();
            
            return result;
        }
        catch
        {
            return new List<CourseComment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, CourseComment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE course_comments SET comment= @Comment, " +
                " student_id=@StudentId, course_id=@CourseId, created_at=@CreatedAt, " +
                " updated_at=@UpdatedAt WHERE id = @Id;";

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
}
