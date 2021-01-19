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
    /// Konstruktory do stworzenia listy
    /// </summary>
    public class Items
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("price")]
        public string price { get; set; } 
        [JsonProperty("description")]
        public string description { get; set; }

        public Items(int itemid, string itemname, string itemprice, string itemdesc)
        {
            id = itemid;
            name = itemname;
            price = itemprice;
            description = itemdesc;

        }

    }
    /// <summary>
    /// Konstruktory do danych wynikowych
    /// </summary>
    public class JsonResult 
    { 
        public int id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string description { get; set; }
    }
    class DataManipulation
    {
        public string _path = @"..\..\DB\data.json";
      

        /// <summary>
        /// Dodawanie przedmiotow do bazy
        /// </summary>
        /// <param name="itemFromUser"></param>
        /// <param name="itemPrice"></param>
        /// <param name="itemDescription"></param>
        public void addData(string itemFromUser, string itemPrice, string itemDescription)
        {
            string jsonFromFile;
            int tempId = 0;
            int itemId;
            int i = 1;
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var list = JsonConvert.DeserializeObject<List<Items>>(jsonFromFile);

                // help item counter
                foreach (var item in list)
                {
                    if (i == list.Count)
                    {
                        tempId = item.id;
                    }
                    else
                    {
                        i++;
                    }
                    
                }
                //  id increment
                itemId = tempId += 1;
                
                list.Add(new Items(itemId, itemFromUser, itemPrice, itemDescription));
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(_path, convertedJson);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        /// <summary>
        /// Wyswietlanie danych
        /// </summary>
        /// <returns></returns>
        public List<JsonResult> displayData()
        {
            string jsonFromFile;
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var result = JsonConvert.DeserializeObject<List<JsonResult>>(jsonFromFile);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        ///  Edycja danych
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemFromUser"></param>
        /// <param name="itemPrice"></param>
        /// <param name="itemDescription"></param>
        /// <returns></returns>
        public bool editData(decimal id, string itemFromUser, string itemPrice, string itemDescription)
        {
            string jsonFromFile;
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var result = JsonConvert.DeserializeObject<List<Items>>(jsonFromFile);

              
                    var itemToEdit = result.FirstOrDefault(r => r.id == id);
                    if (itemToEdit != null)
                        {
                            if (itemFromUser != "") itemToEdit.name = itemFromUser;
                            if (itemPrice != "") itemToEdit.price = itemPrice;
                            if (itemDescription != "")itemToEdit.description = itemDescription;
                        }
              

                var convertedJson = JsonConvert.SerializeObject(result, Formatting.Indented);

                File.WriteAllText(_path, convertedJson);

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Usuwanie danych
        /// </summary>
        /// <param name="id"></param>
        public void removeData(int id)
        {
            string jsonFromFile;
            try
            {
                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var result = JsonConvert.DeserializeObject<List<JsonResult>>(jsonFromFile);
                // delete item by id
                var itemToRemove = result.SingleOrDefault(r => r.id == id);
                if (itemToRemove != null)
                    result.Remove(itemToRemove);
                var convertedJson = JsonConvert.SerializeObject(result, Formatting.Indented);
                File.WriteAllText(_path, convertedJson);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
   
}
