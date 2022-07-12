using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVaddes.Data.Models
{
  public class UserOrderModel
  {
    public int itemId { get; set; }
    public string itemName { get; set; }
    public string itemType { get; set; }
    public decimal itemPrice { get; set; }
    public string itemImage { get; set; }
    public string itemDescription { get; set; }
    public decimal itemReview { get; set; }

    public int itemQty { get; set; }

    public string userName { get; set; }
    public string cardNumber { get; set; }
    public DateTime expiryDate { get; set; }
    public int cvv { get; set; }
    public DateTime orderDate { get; set; }
    public string cardType { get; set; }
    public string address { get; set; }
    public string postcode { get; set; }
  }
}
