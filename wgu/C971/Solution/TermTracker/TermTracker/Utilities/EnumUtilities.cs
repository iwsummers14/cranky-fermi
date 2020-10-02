using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

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
                return attributes.ToList<DescriptionAttribute>().First().Description;
            }

            else
            {
                return enumValue.ToString();
            }

        }
               
        public static List<string> EnumDescriptionsToList<TEnum>(Type enumType)
        {
            List<string> stringValues = new List<string>();

            var enumValues = System.Enum.GetValues(enumType).Cast<TEnum>().ToList();

            enumValues.ForEach(ev =>
                stringValues.Add(GetDescription(ev))
            );

            return stringValues;

        }

        public static TEnum EnumValueFromDescription<TEnum>(string description)
        {
            var enumValues = System.Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
            TEnum returnValue = default;

            enumValues.ForEach(ev => 
            {
                // get field info for the provided value
                var field = typeof(TEnum).GetField(ev.ToString());

                // get any custom attributes of type DescriptionAttribute
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                // compare the value of the description attribute to the provided string. if they are equal, set the return value
                if (attributes.Length > 0)
                {
                    if (attributes.ToList<DescriptionAttribute>().First().Description == description)
                    {
                        returnValue = ev;
                    }
                }

            });

            return returnValue;

        }
    }
}
