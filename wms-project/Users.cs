using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace wms_project
{
    public class UserJson
    {
        [JsonProperty("users")]
        public User User { get; set; }
    }
    public class User
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("isAdmin")]
        public string isAdmin { get; set; }
    }
    class Users
    {

        //private readonly string _path = $"C:\\Users\\Majkelo\\source\\repos\\wms-proj\\wms-project\\users.json";
        private readonly string _path = @".\users.json";

        public bool readUsers(string name, string pwd)
        {
            string jsonFromFile;

            try
            {
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var userFromJson = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);

                Console.WriteLine(userFromJson.GetType());
                //var test = userFromJson[0];
                //Console.WriteLine(test.name);
                //var test2 = userFromJson[1];
                //Console.WriteLine(test2.name);
                // Console.WriteLine(userFromJson);
                //UserJson p1 = userFromJson[0];

                // simple user validation
                foreach (var item in userFromJson)
                {
                    
                    if (item.name == name && item.password == pwd)
                    {
                        return true;
                    }
                                      
                }
                return false;
         
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


    }
   
}
