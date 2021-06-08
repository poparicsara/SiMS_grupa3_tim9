using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IS_Bolnica.Validation
{
    public class Validations : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                if (int.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite validne cifre!");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
