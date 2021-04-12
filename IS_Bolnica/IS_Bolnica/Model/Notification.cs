// File:    Notification.cs
// Author:  Nikolina Pavkovic
// Created: Saturday, April 10, 2021 5:00:41 PM
// Purpose: Definition of Class Notification

using System;

namespace Model
{
   public class Notification
   {
      public string title { get; set; }
      public string content { get; set; }
      public NotificationType notificationType { get; set; }
   
   }
}