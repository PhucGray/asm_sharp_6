using share.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IOrder
    {
        Task<dynamic> GetAll();
        Task<dynamic> GetById(int id);
        Task<dynamic> GetOrderDetailsByOrderId(int orderId);
        Task<dynamic> GetByUserId(int userId);
        Task<dynamic> GetOrderStatuses();
        Task<dynamic> AddOrder(OrderModel order);
        Task<dynamic> AddOrderDetails(IEnumerable<OrderDetailModel> orderDetails);
        Task<dynamic> Update(int statusId, int id);
        Task<dynamic> GetVAT();
    }
}
