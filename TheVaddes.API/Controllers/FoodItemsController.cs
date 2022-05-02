using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheVaddes.Data.IDAL;

namespace TheVaddes.API.Controllers
{
  [RoutePrefix("Api/FoodItems")]
  public class FoodItemsController : ApiController
  {
    private readonly IFoodItemsRepository _FoodItems;

    public FoodItemsController(IFoodItemsRepository foodItems)
    {
      _FoodItems = foodItems;
    }

    [HttpGet]
    [Route("GetAllFoodItemDetails")]
    public IHttpActionResult GetAllFoodItemDetails()
    {
      try
      {
        var results = _FoodItems.GetAllFoodItems();
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}
