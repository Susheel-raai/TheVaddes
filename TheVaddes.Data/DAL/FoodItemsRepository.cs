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
    public class FoodItemsRepository : DbConnection, IFoodItemsRepository
    {
        public List<FoodItemsModel> GetAllFoodItems()
        {
            connection();
            List<FoodItemsModel> foodItemslist = new List<FoodItemsModel>();

            SqlCommand cmd = new SqlCommand("GetItems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                foodItemslist.Add(
                    new FoodItemsModel
                    {
                        itemId = Convert.ToInt32(dr["itemId"]),
                        itemName = Convert.ToString(dr["itemName"]),
                        itemType = Convert.ToString(dr["itemType"]),
                        itemPrice = Convert.ToDecimal(dr["itemPrice"]),
                        itemImage = Convert.ToString(dr["itemImage"]),
                        itemDescription = Convert.ToString(dr["itemDescription"]),
                        itemReview = Convert.ToDecimal(dr["itemReview"]),
                        itemQty = Convert.ToInt32(dr["itemQty"])
                    });
            }
            return foodItemslist;
        }
    }
}
