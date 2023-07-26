using Dapper;
using GetTalim.DataAccess.Interfaces.CourseBenefits;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Courses;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.CourseBenefits;

public class CourseBenefitRepository : BaseRepository, ICourseBenefitRepository
{
    public async Task<int> CreateAsync(CourseBenefit entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO course_benefits(name, course_id, " +
                " created_at, updated_at) VALUES (@Name, @CourseId, @CreatedAt, @UpdatedAt) ; ";

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
            string query = "DELETE FROM course_benefits WHERE id = @Id; ";

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

    public async Task<IList<CourseBenefit>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_benefits order by id desc  ";

            var result =  (await _connection.QueryAsync<CourseBenefit>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseBenefit>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseBenefit?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course_benefits WHERE id = @Id ";

            var result = await _connection.QuerySingleAsync<CourseBenefit>(query, new { Id = id });
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

    public  Task<int> UpdateAsync(long id, CourseBenefit entity)
    {
        throw new NotImplementedException();
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }
}
