using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.WebPages;
using InventoryLibrary;

namespace AzureWebService.Controllers
{
    public class UserController:ApiController
    {
        DBAccess.DBAccess userAccess = new DBAccess.DBAccess();
        // GET: api/User
        public IEnumerable<User> Get()
        {
            return userAccess.GetAllUsers();
        }

        
        public User Get(string username)
        {
            return userAccess.GetUser(username);
        }


        // POST: api/User
        public void Post([FromBody] User user)
        {
            userAccess.createUser(user);
        }


        // DELETE: api/User/username
        public void Delete(string username)
        {
            userAccess.deleteUser(username);
        }
    }
}