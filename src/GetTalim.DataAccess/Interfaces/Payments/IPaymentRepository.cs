using GetTalim.DataAccess.Common.Interfaces;
using GetTalim.DataAccess.Utils;
using GetTalim.DataAccess.ViewModels;
using GetTalim.Domain.Entities.Payments;

namespace GetTalim.DataAccess.Interfaces.Payments;

public interface IPaymentRepository : IRepository<Payment, Payment>, IGetAll<Payment>
{
    public  Task<IList<PaymentViewModel>> GetAllFullAsync(PaginationParams @params);
}
