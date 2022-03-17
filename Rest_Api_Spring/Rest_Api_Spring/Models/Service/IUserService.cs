using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_Api_Spring.models;
using System.Collections.Generic;

namespace Rest_Api_Spring.Models.Service
{
    public interface IUserService
    {
        List<User> GetAll(string api);
        User GetById(string api, int id);
        User EditUser(string api, User user);
        User DeleteUser(string api);
        User AddUser(string api, User user);
    }
}


