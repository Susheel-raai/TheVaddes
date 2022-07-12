using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVaddes.Data.Models;

namespace TheVaddes.Data.IDAL
{
  public interface IUserRepository
  {
    List<UserModel> GetAllUsers();
    int AddUser(UserModel user);

    int AddUserOrders(List<UserOrderModel> userOrder);

    List<UserOrderModel> GetUsersOrders();

    List<UserOrderModel> GetPayments();

    int RemoveCard(UserOrderModel userOrders);
    int CancelOrder(UserOrderModel userOrders);
    int UserLogsDeatils(string username);
    List<UserLogModel> GetUserLogs();
    List<Postcodes> GetPostcodes(string code);
  }
}
