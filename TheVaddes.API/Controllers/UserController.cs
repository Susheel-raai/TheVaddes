using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheVaddes.Data.IDAL;
using TheVaddes.Data.Models;

namespace TheVaddes.API.Controllers
{
  [RoutePrefix("Api/User")]
  public class UserController : ApiController
  {
    private readonly IUserRepository _user;

    public UserController(IUserRepository user)
    {
      _user = user;
    }

    [HttpGet]
    [Route("GetAllUsers")]
    public IHttpActionResult GetAllUsers()
    {
      try
      {
        var results = _user.GetAllUsers();
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("AddUser")]
    public IHttpActionResult AddUser(UserModel user)
    {
      try
      {
        int results = _user.AddUser(user);
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetUsersOrders")]
    public IHttpActionResult GetUsersOrders()
    {
      try
      {
        var results = _user.GetUsersOrders();
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}
