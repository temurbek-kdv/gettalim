using Dapper;
using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Interfaces;
using GetTalim.DataAccess.Interfaces.Students;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Students;

namespace GetTalim.DataAccess.Repositories.Students;

public class StudentRepository:BaseRepository, IStudentRepository
{
    public async Task<int> CreateAsync(Student entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO students( first_name, last_name, is_male, email, email_confirmed, phone_number, image_path, password_hash, salt, identity_role, created_at, updated_at) " +
                "VALUES (@FirstName, @LastName, @IsMale, @Email, @IsEmailConfirmed, @PhoneNumber, @ImagePath, @PasswordHash, @Salt, @IdentityRole, @CreatedAt, @UpdatedAt); ";

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
            string query = $"UPDATE students SET first_name=@FirstName, " +
                $"last_name=@LastName, is_male=@IsMale, email=@Email, email_confirmed=IsEmailConfirmed, " +
                $" phone_number=@PhoneNumber, image_path=@ImagePath, password_hash=@PasswordHash, " +
                $" salt=@Salt, created_at=@CreatedAt, updated_at=@UpdateddAt WHERE id = {id}; ";

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

    public async Task<Student?> GetByEmailAsync(string email)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM students where email = @Email ";

            var data = await _connection.QuerySingleAsync<Student>(query, new {Email = email});
            return data;
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

    async Task<StudentViewModel?>  IRepository<Student, StudentViewModel>.GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT *  FROM students WHERE id = @Id ;";

            var result = await _connection.QuerySingleAsync<StudentViewModel>(query, new { Id = id });
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

    Task<IList<StudentViewModel>> IGetAll<StudentViewModel>.GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<(int ItemsCount, IList<StudentViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }
}
