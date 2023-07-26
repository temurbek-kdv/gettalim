using Dapper;
using GetTalim.DataAccess.Interfaces.Payments;
using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Payments;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.Payments;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Payment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO payments(student_id, course_id, " +
                " is_paid, created_at, updated_at) VALUES " +
                " ( @StudentId, @CourseId, @IsPaid, @CreatedAt, @UpdatedAt ); ";

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
            string query = "DELETE FROM payments WHERE id = @Id ";

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

    public async Task<IList<Payment>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM payments order by id desc ";

            var result = (await _connection.QueryAsync<Payment>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Payment>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
        
    }

    public async Task<Payment?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM payments WHERE id = @Id ";

            var result = await _connection.QuerySingleAsync<Payment>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Payment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE payments SET  student_id=@StudentId, " +
                " course_id=@CourseId, is_paid=@IsPaid, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $" WHERE id = {id}; ";

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
