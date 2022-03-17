using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Rest_Api_Spring.models
{
    public class JsonModel
    {
        public List<User> details { get; set; }
    }
    // User myDeserializedClass = JsonSerializer.Deserialize<User>(myJsonResponse);
    public class User
    {
        [JsonProperty("userId")]
        public int UserId;

        [JsonProperty("firstName")]
        public string FirstName;

        [JsonProperty("lastName")]
        public string LastName;

        [JsonProperty("userType")]
        public string UserType;

        [JsonProperty("startDate")]
        public object StartDate;

        [JsonProperty("codiceFiscale")]
        public string CodiceFiscale;

        [JsonProperty("eta")]
        public int Eta;
    }


}