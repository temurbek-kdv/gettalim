using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.Domain.Entities.Payments;

namespace GetTalim.DataAccess.Interfaces.Payments;

public interface IPaymentRepository : IRepository<Payment, Payment>, IGetAll<Payment>
{
}
