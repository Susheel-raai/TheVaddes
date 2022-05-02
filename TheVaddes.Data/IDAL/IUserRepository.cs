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

    int AddUserOrders();

    List<UserOrderModel> GetUsersOrders();
  }
}
