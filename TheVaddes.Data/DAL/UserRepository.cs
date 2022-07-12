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
              orderDate = Convert.ToDateTime(dr["orderDate"]),
              cardType = Convert.ToString(dr["cardType"])
            });
      }
      return orderList;
    }

    public int AddUserOrders(List<UserOrderModel> userOrder)
    {
      connection();
      DataTable dt = new DataTable();

      dt.Columns.Add(new DataColumn("itemId",typeof(int)));
      dt.Columns.Add(new DataColumn("itemName",typeof(string)));
      dt.Columns.Add(new DataColumn("itemType", typeof(string)));
      dt.Columns.Add(new DataColumn("itemPrice", typeof(decimal)));
      dt.Columns.Add(new DataColumn("itemImage", typeof(string)));
      dt.Columns.Add(new DataColumn("itemDescription", typeof(string)));
      dt.Columns.Add(new DataColumn("itemReview", typeof(decimal)));
      dt.Columns.Add(new DataColumn("itemQty", typeof(int)));
      dt.Columns.Add(new DataColumn("userName", typeof(string)));
      dt.Columns.Add(new DataColumn("cardNumber", typeof(string)));
      dt.Columns.Add(new DataColumn("expiryDate", typeof(DateTime)));
      dt.Columns.Add(new DataColumn("cvv", typeof(string)));
      dt.Columns.Add(new DataColumn("cardType",typeof (string)));
      dt.Columns.Add(new DataColumn("address", typeof(string)));
      dt.Columns.Add(new DataColumn("postcode", typeof(string)));

      foreach (var order in userOrder)
      {
        dt.Rows.Add(order.itemId, order.itemName, order.itemType, order.itemPrice, order.itemImage, order.itemDescription, order.itemReview, order.itemQty,
          order.userName, order.cardNumber, order.expiryDate, order.cvv,order.cardType,order.address,order.postcode);
      }

      SqlCommand cmd = new SqlCommand("AddUserOrders", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add(new SqlParameter("@userOrdersTable", dt));
      con.Open();
      int i = cmd.ExecuteNonQuery();
      if (i >= 0)
        return 1;
      else
        return 0;
    }

    public List<UserOrderModel> GetPayments()
    {
      connection();
      List<UserOrderModel> paymentList = new List<UserOrderModel>();

      SqlCommand cmd = new SqlCommand("GetPayments", con);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlDataAdapter sd = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();

      con.Open();
      sd.Fill(dt);
      con.Close();
      foreach (DataRow dr in dt.Rows)
      {
        paymentList.Add(
            new UserOrderModel
            {
              cardNumber = Convert.ToString(dr["cardNumber"]),
              expiryDate = Convert.ToDateTime(dr["expiryDate"]),
              cvv = Convert.ToInt32(dr["cvv"]),
              userName = Convert.ToString(dr["userName"]),
              cardType = Convert.ToString(dr["cardType"])
            });
      }
      return paymentList;
    }

    public int RemoveCard(UserOrderModel userOrders)
    {
      connection();
      SqlCommand cmd = new SqlCommand("removeCard", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add(new SqlParameter("@cardNumber", userOrders.cardNumber));
      cmd.Parameters.Add(new SqlParameter("@userName", userOrders.userName));

      con.Open();
      int i = cmd.ExecuteNonQuery();
      if (i >= 0)
        return 1;
      else
        return 0;
    }

    public int CancelOrder(UserOrderModel userOrders)
    {
      connection();
      SqlCommand cmd = new SqlCommand("cancelOrder", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add(new SqlParameter("@orderDate", userOrders.orderDate));
      cmd.Parameters.Add(new SqlParameter("@userName", userOrders.userName));
      con.Open();
      int i = cmd.ExecuteNonQuery();
      if (i >= 0)
        return 1;
      else
        return 0;
    }

    public int UserLogsDeatils(string username)
    {
      connection();
      SqlCommand cmd = new SqlCommand("UserLogsDetails", con);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@userName", username));

      con.Open();
      int i = cmd.ExecuteNonQuery();
      if (i >= 0)
        return 1;
      else
        return 0;
    }

    public List<UserLogModel> GetUserLogs()
    {
      connection();
      List<UserLogModel> userLogList = new List<UserLogModel>();

      SqlCommand cmd = new SqlCommand("getUserLogsDetails", con);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlDataAdapter sd = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();

      con.Open();
      sd.Fill(dt);
      con.Close();
      foreach (DataRow dr in dt.Rows)
      {
        userLogList.Add(
            new UserLogModel
            {
              userName = Convert.ToString(dr["userName"]),
              logOutTime = Convert.ToDateTime(dr["logOutTime"])
            });
      }
      return userLogList;
    }

    public List<Postcodes> GetPostcodes(string code)
    {
      connection();
      List<Postcodes> postcodesList = new List<Postcodes>();

      SqlCommand cmd = new SqlCommand("GetPostCodes", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add(new SqlParameter("@code", code));
      SqlDataAdapter sd = new SqlDataAdapter(cmd);
      DataTable dt = new DataTable();

      con.Open();
      sd.Fill(dt);
      con.Close();
      foreach(DataRow dr in dt.Rows)
      {
        postcodesList.Add(
          new Postcodes
          {
            postcode = Convert.ToString(dr["postcode"]),
            latitude = Convert.ToDecimal(dr["latitude"]),
            longitude = Convert.ToDecimal(dr["longitude"])
          });
      }
      return postcodesList;
    }
  }
}
