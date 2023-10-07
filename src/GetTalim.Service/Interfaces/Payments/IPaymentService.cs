using GetTalim.DataAccess.Utils;
using GetTalim.Domain.Entities.Payments;
using GetTalim.Service.Dtos.Payment;

namespace GetTalim.Service.Interfaces.Payments;

public interface IPaymentService
{
    public Task<bool> CreateAsync(PaymentCreateDto dto);
    public Task<bool> DeleteAsync(long paymentId);
    public Task<long> CountAllAsync();
    public Task<IList<Payment>> GetAllAsync(PaginationParams @params);
    public Task<Payment> GetByIdAsync (long paymentId);
    public Task<bool> UpdateAsync(PaymentUpdateDto dto);
}
