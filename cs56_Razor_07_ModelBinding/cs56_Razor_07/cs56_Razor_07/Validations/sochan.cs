using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cs56_Razor_07.Validations
{
    public class sochan : ValidationAttribute
    {
        public sochan()
        {
            ErrorMessage = "{0} phải là số chẵn";
        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            int i = int.Parse(value.ToString());

            return i % 2 == 0;
        }
    }
}
