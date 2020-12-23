using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace wms_project
{
    class Users
    {
        public string uname;
        public string upassword;
        public bool isAdmin;

        private readonly string _path = $"C:\\Users\\kuba\\source\\repos\\wms-system-project\\users.json";

        public bool readUsers(string name, string pwd)
        {
            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                //Console.WriteLine(jsonFromFile);

                var userFromJson = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);

                //Console.WriteLine(userFromJson.GetType());
                //var test = userFromJson[0];
                //Console.WriteLine(test.name);
                //var test2 = userFromJson[1];
                //Console.WriteLine(test2.name);
                // UserJson p1 = userFromJson[0];
                
                foreach (var item in userFromJson)
                {
                 
                    if (item.name == name && item.password == pwd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                  
                }
                return false;
                
                

                // Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

       // to wyjebac
        public void setUsers(string name, string password, bool isAdmin)
        {
            this.uname = name;
            this.upassword = password;
            this.isAdmin = isAdmin;
        }
    }
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
}
