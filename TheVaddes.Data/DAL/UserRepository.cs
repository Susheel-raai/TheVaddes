using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVaddes.Data.IDAL;
using TheVaddes.Data.Models;

namespace TheVaddes.Data.DAL
{
  public class UserRepository : DbConnection, IUserRepository
  {
    public List<UserModel> GetAllUsers()
    {
      connection();
      List<UserModel> userlist = new List<UserModel>();

      SqlCommand cmd = new SqlCommand("GetUsers", con);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlDataAdapter sd = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();

      con.Open();
      sd.Fill(dt);
      con.Close();
      foreach (DataRow dr in dt.Rows)
      {
        userlist.Add(
            new UserModel
            {
              firstName = Convert.ToString(dr["firstName"]),
              lastName = Convert.ToString(dr["lastName"]),
              userName = Convert.ToString(dr["userName"]),
              password = Convert.ToString(dr["password"]),
              confirmPassword = Convert.ToString(dr["confirmPassword"])
            });
      }
      return userlist;
    }

    public int AddUser(UserModel user)
    {
      connection();
      if(user.isEdit)
      {
        SqlCommand cmd = new SqlCommand("UpdateUser", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@firstName", user.firstName));
        cmd.Parameters.Add(new SqlParameter("@lastName", user.lastName));
        cmd.Parameters.Add(new SqlParameter("@userName", user.userName));
        cmd.Parameters.Add(new SqlParameter("@password", user.password));
        cmd.Parameters.Add(new SqlParameter("@confirmPassword", user.confirmPassword));

        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 0)
          return 1;
        else
          return 0;
      }
      else
      {
        SqlCommand cmd = new SqlCommand("AddNewUser", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@firstName", user.firstName));
        cmd.Parameters.Add(new SqlParameter("@lastName", user.lastName));
        cmd.Parameters.Add(new SqlParameter("@userName", user.userName));
        cmd.Parameters.Add(new SqlParameter("@password", user.password));
        cmd.Parameters.Add(new SqlParameter("@confirmPassword", user.confirmPassword));

        con.Open();
        int i = cmd.ExecuteNonQuery();
        if (i >= 0)
          return 1;
        else
          return 0;
      }
      
    }

    public int AddUserOrders()
    {
      throw new NotImplementedException();
    }

    public List<UserOrderModel> GetUsersOrders()
    {
      connection();
      List<UserOrderModel> orderList = new List<UserOrderModel>();

      SqlCommand cmd = new SqlCommand("GetUserOrders", con);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlDataAdapter sd = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();

      con.Open();
      sd.Fill(dt);
      con.Close();
      foreach (DataRow dr in dt.Rows)
      {
        orderList.Add(
            new UserOrderModel
            {
              itemId = Convert.ToInt32(dr["itemId"]),
              itemName = Convert.ToString(dr["itemName"]),
              itemType = Convert.ToString(dr["itemType"]),
              itemPrice = Convert.ToDecimal(dr["itemPrice"]),
              itemImage = Convert.ToString(dr["itemImage"]),
              itemDescription = Convert.ToString(dr["itemDescription"]),
              itemReview = Convert.ToDecimal(dr["itemReview"]),
              itemQty = Convert.ToInt32(dr["itemQty"]),
              userName = Convert.ToString(dr["userName"]),
              cardNumber = Convert.ToString(dr["cardNumber"]),
              expiryDate = Convert.ToDateTime(dr["expiryDate"]),
              cvv = Convert.ToInt32(dr["cvv"]),
              orderDate = Convert.ToDateTime(dr["orderDate"])
            });
      }
      return orderList;
    }
  }
}