using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiplomnaCarProject
{
    public class NotEmptyValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            /*return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Моля попълнете полето! ")
                : ValidationResult.ValidResult;*/

            if (value.ToString() == "")
            {
                return new ValidationResult(false, "Моля попълнете полето! ");
            }
            else return ValidationResult.ValidResult;
        }

    }
}
