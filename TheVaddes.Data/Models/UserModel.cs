using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVaddes.Data.Models
{
  public class UserModel
  {
    public bool isEdit { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string confirmPassword   { get; set; }

  }
}
