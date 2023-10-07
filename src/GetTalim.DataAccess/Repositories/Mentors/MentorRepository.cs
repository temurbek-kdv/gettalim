using Dapper;
using GetTalim.DataAccess.Interfaces.Mentors;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using GetTalim.Domain.Entities.Mentors;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.Mentors;

public class MentorRepository : BaseRepository, IMentorRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Mentor entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO mentors(first_name, last_name, image_path, " +
                " description, email, created_at, updated_at, stack) VALUES " +
                " (@FirstName, @LastName, @ImagePath, @Description, @Email, @CreatedAt, @UpdatedAt, @Stack) ; ";

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
            string query = "DELETE FROM mentors WHERE id = @Id ";

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

    public async Task<IList<Mentor>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM mentors order by id desc ";

            var result = (await _connection.QueryAsync<Mentor>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Mentor>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Mentor?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM mentors WHERE id = @Id ";

            var result = await _connection.QuerySingleAsync<Mentor>(query, new { Id = id });
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

    public async Task<IList<Course>> GetMentorsCourses(long mentorId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $" SELECT * FROM courses where mentor_id = {mentorId} ";

            var result = await _connection.QueryAsync<Course>(query);

            return result.ToList();
        }
        catch
        {
            return new List<Course>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Mentor entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE mentors SET  first_name=@FirstName, last_name=@LastName, " +
                " image_path=@ImagePath, description=@Description, email=@Email, " +
                $" created_at=@CreatedAt, updated_at=@UpdatedAt, stack=@Stack WHERE id = {id} ; ";

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
