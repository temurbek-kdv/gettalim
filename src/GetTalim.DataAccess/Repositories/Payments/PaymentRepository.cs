using Dapper;
using GetTalim.DataAccess.Interfaces.Payments;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Payments;
using static Dapper.SqlMapper;

namespace GetTalim.DataAccess.Repositories.Payments;

public class PaymentRepository : BaseRepository, IPaymentRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT COUNT(*) FROM payment ;";

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

    public async Task<int> CreateAsync(Payment entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO payment(student_id, course_id, " +
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
            string query = "DELETE FROM payment WHERE id = @Id ";

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

    public Task<IList<Payment>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<PaymentViewModel>> GetAllFullAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = @"SELECT payment.*, students.email AS student_email, courses.name AS course_name
                                FROM payment
                                INNER JOIN students ON payment.student_id = students.id
                                INNER JOIN courses ON payment.course_id = courses.id " +
                $"OFFSET {@params.GetSkipCount()} LIMIT {@params.PageSize} ;";

            var result = (await _connection.QueryAsync<PaymentViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<PaymentViewModel>();
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
            string query = "SELECT * FROM payment WHERE id = @Id ";

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
            string query = "UPDATE payment SET  student_id=@StudentId, " +
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
