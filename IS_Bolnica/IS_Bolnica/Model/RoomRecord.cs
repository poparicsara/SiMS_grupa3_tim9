

using System;

namespace Model
{
    public class RoomRecord
    {
        public String Id { get; set; }
        public String HospitalWard { get; set; }

        //public System.Collections.Generic.List<Inventory> inventory;

        /* public System.Collections.Generic.List<Inventory> Inventory
         {
             get
             {
                 if (inventory == null)
                     inventory = new System.Collections.Generic.List<Inventory>();
                 return inventory;
             }
             set
             {
                 RemoveAllInventory();
                 if (value != null)
                 {
                     foreach (Inventory oInventory in value)
                         AddInventory(oInventory);
                 }
             }
         }

         public void AddInventory(Inventory newInventory)
         {
             if (newInventory == null)
                 return;
             if (this.inventory == null)
                 this.inventory = new System.Collections.Generic.List<Inventory>();
             if (!this.inventory.Contains(newInventory))
                 this.inventory.Add(newInventory);
         }

         public void RemoveInventory(Inventory oldInventory)
         {
             if (oldInventory == null)
                 return;
             if (this.inventory != null)
                 if (this.inventory.Contains(oldInventory))
                     this.inventory.Remove(oldInventory);
         }

         public void RemoveAllInventory()
         {
             if (inventory != null)
                 inventory.Clear();
         }*/
        public RoomPurpose roomPurpose { get; set; }

    }
}