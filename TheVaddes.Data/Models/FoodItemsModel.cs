using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVaddes.Data.Models
{
    public class FoodItemsModel
    {
        public int itemId   { get; set; }
        public string itemName { get; set; }    
        public string itemType { get; set; }    
        public decimal itemPrice    { get; set; }
        public string itemImage     { get; set; }
        public string itemDescription   { get; set; }
        public int itemReview { get; set; }

    }
}
