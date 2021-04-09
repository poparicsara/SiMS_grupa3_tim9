

using System;
using System.Collections.Generic;

namespace Model
{
   public class InventoryFileStorage
   {
        private string fileName;
        private List<Inventory> inventories;
        public InventoryFileStorage()
        {
            inventories = new List<Inventory>();

            Inventory i1 = new Inventory { Name = "Hanzaplast", CurrentAmount = 10, Id = "H10", Minimum = 1 };
            Inventory i2 = new Inventory { Name = "Injekcija", CurrentAmount = 10, Id = "I10", Minimum = 1 };
            Inventory i3 = new Inventory { Name = "Zavoj", CurrentAmount = 10, Id = "Z10", Minimum = 1 };

            inventories.Add(i1);
            inventories.Add(i2);
            inventories.Add(i2);

        }

        public List<Inventory> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public void AddInventory(Inventory newInventory)
      {
         throw new NotImplementedException();
      }
      
      public void DeleteInventory(int inventory)
      {
         throw new NotImplementedException();
      }
      
      public void EditInventory(int selectedInventory, Inventory newInventory)
      {
         throw new NotImplementedException();
      }
      
      public void SaveToFile(List<Inventory> inventories, string fileName)
      {
         throw new NotImplementedException();
      }
      
      public List<Inventory> LoadFromFile(string fileName)
      {
         throw new NotImplementedException();
      }
   
   }
}