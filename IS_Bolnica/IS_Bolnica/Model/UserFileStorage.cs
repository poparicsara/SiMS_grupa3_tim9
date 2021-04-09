// File:    UserFileStorage.cs
// Author:  Sara
// Created: Tuesday, April 6, 2021 11:21:50 PM
// Purpose: Definition of Class UserFileStorage

using System;

namespace Model
{
   public class UserFileStorage
   {
      public ObservableCollection<User> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public void SaveToFile(ObservableCollection<User> users, string fileName)
      {
         throw new NotImplementedException();
      }
      
      public ObservableCollection<User> LoadFromFile(string fileName)
      {
         throw new NotImplementedException();
      }
   
   }
}