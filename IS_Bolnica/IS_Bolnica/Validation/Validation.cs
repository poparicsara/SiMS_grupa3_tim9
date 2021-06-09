using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IS_Bolnica.Validation
{
    public class ValidationRuleJMBG : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexJMBG = new Regex(@"[0-9]{13}$");
            var jmbg = value as string;
            if (regexJMBG.IsMatch(jmbg.Trim()))
            {
                return new ValidationResult(true, null);
            }

            if (jmbg.Trim().Length != 13)
            {
                return new ValidationResult(false, "JMBG mora da sadrži 13 cifara.");
            }

            return new ValidationResult(false, "JMBG ne sme da sadrži ništa osim cifara");
        }

    }

    public class ValidationRulePhone : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexPhone = new Regex(@"[0-9]{6,14}");
            var phone = value as string;
            if (regexPhone.IsMatch(phone.Trim()))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Telefon sme da sadrži samo od 6 do 14 cifara.");
        }
    }

    public class ValidationRuleAddress : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexAddress = new Regex(@"[A-Za-z]+\s[0-9]{1,3}\/[0-9]{1,3}\/[0-9]{1,3}");
            var address = value as string;
            if (regexAddress.IsMatch(address.Trim()))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Format adrese je [Ulica broj/sprat/stan].");
        }
    }

    public class ValidationRuleEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexAddress = new Regex(@"[a-z\.0-9]+@[a-z\.]+\.[a-z]{1,4}");
            var address = value as string;
            if (regexAddress.IsMatch(address.Trim()))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "E-mail je naispravnog formata.");
        }
    }

    public class ValidationRuleRequired : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var name = value as string;
            if (!name.Trim().Equals(""))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Polje je obavezno.");
        }
    }

    public class ValidationRuleCity : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regexCity = new Regex(@"[A-Za-z]+\s[0-9]{5,8}");
            var city = value as string;
            if (regexCity.IsMatch(city))
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Grad unesti u formatu [Ime postanski broj]");
        }
    }
}
