using Dapper;
using GetTalim.DataAccess.Interfaces.Courses;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Categoires;
using GetTalim.Domain.Entities.Courses;
using System.Xml.Linq;

namespace GetTalim.DataAccess.Repositories.Courses;

public class CourseRepository : BaseRepository, ICourseRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT count(*) FROM courses ; ";

            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<int> CreateAsync(Course entity)
    {
        try
        {

            await _connection.OpenAsync();
            string query = "INSERT INTO courses(name, description, information, lessons, " +
                "hours, level, language, image_path, price, discount_price, mentor_id, category_id, created_at, updated_at)" +
                $"VALUES ( @Name, @Description, @Information, @Lessons, @Hours, @Level, @Language, " +
                "@ImagePath, @Price, @DiscountPrice, @MentorId, @CategoryId, @CreatedAt, @UpdatedAt) ;";

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
            string query = "DELETE FROM courses WHERE id = @Id ;";

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

    public async Task<IList<Course>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM courses ORDER BY id DESC " +
                $" OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize} ;";

            var result = (await _connection.QueryAsync<Course>(query)).ToList();
            return result;
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

    public async Task<Course?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM courses WHERE id = @Id ;";

            var result = await _connection.QuerySingleAsync<Course>(query, new { Id = id });
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
    public async Task<int> UpdateAsync(long id, Course entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.courses SET name=@Name, description=@Description, " +
                "information=@Information, lessons=@Lessons, hours=@Hours, level=@Level, language=@Language, image_path=@ImagePath, " +
                "price=@Price, discount_price=@DiscountPrice, mentor_id=@MentorId, category_id=@CategoryId, created_at=@createdAt, " +
                $"updated_at=@UpdatedAt WHERE id = {id} ;";

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

    public Task<(int ItemsCount, IList<Course>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Course>> GetCoursesByCategory(long categoryId, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM courses WHERE category_id = {categoryId} ORDER BY id DESC " +
                $" OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize} ;";

            var result = (await _connection.QueryAsync<Course>(query)).ToList();
            return result;
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

    public async Task<long> CountCourseByCategory(long categoryId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) FROM courses WHERE category_id = {categoryId} ; ";

            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<long> CountSearchedCoursesNameAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $" SELECT COUNT(*) FROM courses WHERE name ILIKE '%{name}%' ; ";

            var result = await _connection.QuerySingleAsync<long>(query);
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

    public async Task<List<Course>> GetSearchedCoursesNameAsync(string name, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $" SELECT * FROM courses WHERE name ILIKE '%{name}%' ORDER BY id DESC " +
               
                             $" OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize} ;";

            var result = (await _connection.QueryAsync<Course>(query)).ToList();
            return result;
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


   
}
