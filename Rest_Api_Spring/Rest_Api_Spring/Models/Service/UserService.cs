using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rest_Api_Spring.models;
using RestSharp;
using System.Collections.Generic;

namespace Rest_Api_Spring.Models.Service
{
    public class UserService : IUserService
    {
        public User AddUser(string api, User user)
        {
            string jsonString = JsonConvert.SerializeObject(user);
            var UpFile = new RestClient(api);
            UpFile.Timeout = -1;
            var requestFile = new RestRequest(Method.POST);
            requestFile.AddHeader("Content-Type", "application/json");
            requestFile = (RestRequest)requestFile.AddJsonBody(jsonString);

            IRestResponse responseFile = UpFile.Execute(requestFile);
            string myRes = responseFile.Content;

            User userList = JsonConvert.DeserializeObject<User>(myRes.ToString());

            return userList;
        }

        public User DeleteUser(string api)
        {
            var UpFile = new RestClient(api);
            UpFile.Timeout = -1;
            var requestFile = new RestRequest(Method.DELETE);
            requestFile.AddHeader("Content-Type", "application/json");

            IRestResponse responseFile = UpFile.Execute(requestFile);
            string myRes = responseFile.Content;

            User userList = JsonConvert.DeserializeObject<User>(myRes.ToString());

            return userList;
        }

        public User EditUser(string api, User user)
        {
            string jsonString = JsonConvert.SerializeObject(user);
            var UpFile = new RestClient(api);
            UpFile.Timeout = -1;
            var requestFile = new RestRequest(Method.PUT);
            requestFile.AddHeader("Content-Type", "application/json");
            requestFile.AddHeader("Accept", "*/*");
            requestFile = (RestRequest)requestFile.AddJsonBody(jsonString);
            IRestResponse responseFile = UpFile.Execute(requestFile);
            string myRes = responseFile.Content;

            User userList = JsonConvert.DeserializeObject<User>(myRes.ToString());

            return userList;
        }

        public List<User> GetAll(string api)
        {
            var UpFile = new RestClient(api);
            UpFile.Timeout = -1;
            var requestFile = new RestRequest(Method.GET);
            requestFile.AddHeader("Content-Type", "application/json");

            IRestResponse responseFile = UpFile.Execute(requestFile);
            string myRes = responseFile.Content;

            List <User> userList = JsonConvert.DeserializeObject<List<User>>(myRes.ToString());

            return userList;


        }

        public User GetById(string api, int id)
        {
            var UpFile = new RestClient(api + "/" + id);
            UpFile.Timeout = -1;
            var requestFile = new RestRequest(Method.GET);
            requestFile.AddHeader("Content-Type", "application/json");

            IRestResponse responseFile = UpFile.Execute(requestFile);
            string myRes = responseFile.Content;

            User userList = JsonConvert.DeserializeObject<User>(myRes.ToString());

            return userList;
        }
    }
}
