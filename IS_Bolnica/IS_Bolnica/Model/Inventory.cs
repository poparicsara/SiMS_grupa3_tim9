using System;

namespace Model
{
    public class Inventory
    {
        public String Name { get; set; }
        public int CurrentAmount { get; set; }
        public int Minimum { get; set; }
        public String Id { get; set; }

        public void DeleteInventory(String id)
        {
            throw new NotImplementedException();
        }

        public void AddInventory(String name, int currentAmount, int minimum, String id)
        {
            throw new NotImplementedException();
        }

        public void UpdateInventory(String name, int currentAmount, int minimum, String id)
        {
            throw new NotImplementedException();
        }

    }
}