using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVaddes.Data.Models;

namespace TheVaddes.Data.IDAL
{
  public interface IFoodItemsRepository
  {
    List<FoodItemsModel> GetAllFoodItems();
  }
}
