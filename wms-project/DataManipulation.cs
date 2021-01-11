﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace wms_project
{
    public class Items
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }

        public Items(int itemid, string itemname)
        {
            id = itemid;
            name = itemname;
        }

    }

    public class JsonResult 
    { 
        public int id { get; set; }
        public string name { get; set; }
    }
    class DataManipulation
    {
        public string _path = $"C:\\Users\\Majkelo\\source\\repos\\wms-proj\\wms-project\\data.json";
        public void addData(string itemFromUser)
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
                list.Add(new Items(itemId, itemFromUser));
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

                File.WriteAllText(_path, convertedJson);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

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
    }
   
}