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

    [HttpPost]
    [Route("AddUserOrders")]
    public IHttpActionResult AddUserOrders(List<UserOrderModel> userOrder)
    {
      try
      {
        int results = _user.AddUserOrders(userOrder);
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetPayments")]
    public IHttpActionResult GetPayments()
    {
      try
      {
        var results = _user.GetPayments();
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("RemoveCard")]
    public IHttpActionResult RemoveCard(UserOrderModel userOrders)
    {
      try
      {
        int results = _user.RemoveCard(userOrders);
         return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("CancelOrder")]
    public IHttpActionResult CancelOrder(UserOrderModel userOrders)
    {
      try
      {
        int results = _user.CancelOrder(userOrders);
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    [Route("UserLogsDeatils")]
    public IHttpActionResult UserLogsDeatils(string username)
    {
      try
      {
        int results = _user.UserLogsDeatils(username);
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetUserLogs")]
    public IHttpActionResult GetUserLogs()
    {
      try
      {
        var results = _user.GetUserLogs();
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("GetPostcodes")]
    public IHttpActionResult GetPostcodes(string code)
    {
      try
      {
        var results = _user.GetPostcodes(code);
        return Ok(results);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
