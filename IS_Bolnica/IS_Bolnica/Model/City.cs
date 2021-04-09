

using System;

namespace Model
{
   public class City
   {
      public string name { get; set; }
      public string postalCode { get; set; }

      public Country Country { get; set; }

    }
}