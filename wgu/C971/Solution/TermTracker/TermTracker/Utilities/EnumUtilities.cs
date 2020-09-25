using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;

namespace TermTracker.Utilities
{
    public static class EnumUtilities
    {
        public static string GetDescription<TEnum>(TEnum enumValue)
        {
            // get field info for the provided value
            var field = typeof(TEnum).GetField(enumValue.ToString());

            // get any custom attributes of type DescriptionAttribute
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return the value of the Description if it is present, otherwise, return the enum value as a string
            if (attributes.Length > 0)
            {
                return attributes.ToList<DescriptionAttribute>().FirstOrDefault().Description;
            }

            else
            {
                return enumValue.ToString();
            }

        }
               
    }
}
