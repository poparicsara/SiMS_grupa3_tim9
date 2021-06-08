// File:    Notification.cs
// Author:  Nikolina Pavkovic
// Created: Saturday, April 10, 2021 5:00:41 PM
// Purpose: Definition of Class Notification

using System;
using System.Collections.Generic;

namespace Model
{
    public class Notification
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public UserType Sender { get; set; }
        public NotificationType notificationType { get; set; }
        public List<string> PersonId { get; set; }

    }
}