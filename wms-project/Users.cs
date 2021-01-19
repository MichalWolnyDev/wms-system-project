using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace wms_project
{
    /// <summary>
    /// Konstruktory do stworzenia listy z uzytkownikami
    /// </summary>
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

        private readonly string _path = @"..\..\DB\users.json";

        /// <summary>
        /// Odczyt uzytkownikow z pliku json
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
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
