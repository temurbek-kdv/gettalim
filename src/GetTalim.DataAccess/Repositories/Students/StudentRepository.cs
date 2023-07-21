using Dapper;
using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Repositories.Students;

public class StudentRepository:BaseRepository, IStudentRepository
{
    public async Task<int> CreateAsync(Student entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.students( first_name, last_name, is_male, email, email_confirmed, phone_number, image_path, password_hash, salt, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @IsMale, @Email, @IsEmailConfirmed, @PhoneNumber, @ImagePath, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt); ";

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

    public async Task<int> UpdateAsync(long id, Student entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.students SET first_name=@FirstName, " +
                $"last_name=@LastName, is_male=@IsMale, email=@Email, email_confirmed=IsEmailConfirmed, " +
                $" phone_number=@PhoneNumber, image_path=@ImagePath, password_hash=@PasswordHash, " +
                $"salt=@Salt, created_at=@CreatedAt, updated_at=@UpdateddAt WHERE id= {id}; ";

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
            string query = "DELETE FROM students WHERE id = @Id;";

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

    public async Task<Student?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT *  FROM students WHERE id = @Id ;";

            var result = await _connection.QuerySingleAsync<Student>(query, new { Id = id});
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

    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT count(*) FROM students ;";

            var result =  await _connection.QuerySingleAsync<long>(query);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
        throw new NotImplementedException();
    }

    public async Task<IList<Student>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM students ORDER BY id DESC ;";

            var result = (await _connection.QueryAsync<Student>(query)).ToList();
            return result; 
        }
        catch
        {
            return new List<Student>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

}
