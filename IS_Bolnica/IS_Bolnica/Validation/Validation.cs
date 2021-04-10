using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IS_Bolnica.Validation
{
    class ValidationPassword : ValidationRule
    {
        public int Min { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is string)
            {
                string d = (string)value;
                if (d.Length < Min) return new ValidationResult(false, "Morate uneti minimalno 6 karaktera!");
                return new ValidationResult(true, null);
            } 
            else
            {
                return new ValidationResult(false, "Unknow error occured.");
            }
        }
    }
}
