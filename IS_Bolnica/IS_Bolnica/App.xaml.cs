
﻿using System.Threading;

﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace IS_Bolnica
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            EventManager.RegisterClassHandler(typeof(DatePicker),
                DatePicker.PreviewKeyDownEvent,
                new KeyEventHandler(DatePicker_PreviewKeyDown));

        }

        private void DatePicker_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var dp = sender as DatePicker;
            if (dp == null) return;

            if (e.Key == Key.D && Keyboard.Modifiers == ModifierKeys.Control)
            {
                e.Handled = true;
                dp.SetValue(DatePicker.SelectedDateProperty, DateTime.Today);
                return;
            }

            if (!dp.SelectedDate.HasValue) return;

            var date = dp.SelectedDate.Value;
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                dp.SetValue(DatePicker.SelectedDateProperty, date.AddDays(1));
            }
            else if (e.Key == Key.Down)
            {
                if (date >= DateTime.Now)
                {
                    e.Handled = true;
                    dp.SetValue(DatePicker.SelectedDateProperty, date.AddDays(-1));
                }
            }
        }
    }

}
