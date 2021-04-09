

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
   public class InventoryFileStorage
   {
        private string fileName;
        private List<Inventory> inventories;
        public InventoryFileStorage()
        {
            /*inventories = new List<Inventory>();

            Inventory i1 = new Inventory { Name = "Hanzaplast", CurrentAmount = 10, Id = 10, Minimum = 1 };
            Inventory i2 = new Inventory { Name = "Injekcija", CurrentAmount = 10, Id = 10, Minimum = 1 };
            Inventory i3 = new Inventory { Name = "Zavoj", CurrentAmount = 10, Id = 10, Minimum = 1 };

            inventories.Add(i1);
            inventories.Add(i2);
            inventories.Add(i2);*/

        }

        public List<Inventory> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public void AddInventory(Inventory newInventory)
      {
            inventories = loadFromFile("Inventar.json");
            inventories.Add(newInventory);
            saveToFile(inventories, "Inventar.json");
      }
      
      public void DeleteInventory(Inventory selected)
      {
            int index = 0;

            inventories = loadFromFile("Inventar.json");

            //find right index
            foreach (Inventory inventory in inventories)
            {
                if (inventory.Id == selected.Id)
                {
                    break;
                }
                index++;
            }

            inventories.RemoveAt(index);
            saveToFile(inventories, "Inventar.json");
        }
      
      public void EditInventory(Inventory oldInventory, Inventory newInventory)
      {
            int index = 0;

            inventories = loadFromFile("Inventar.json");

            //find right index
            foreach (Inventory inventory in inventories)
            {
                if (inventory.Id == oldInventory.Id)
                {
                    break;
                }
                index++;
            }

            inventories.RemoveAt(index);
            inventories.Insert(index, newInventory);
            saveToFile(inventories, "Inventar.json");
        }
      
      public void saveToFile(List<Inventory> inventories, string fileName)
      {
            string jsonString = JsonConvert.SerializeObject(inventories, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }
      
      public List<Inventory> loadFromFile(string fileName)
      {
            var inventoryList = new List<Inventory>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                inventoryList = (List<Inventory>)serializer.Deserialize(file, typeof(List<Inventory>));
            }

            return inventoryList;
        }
   
   }
}