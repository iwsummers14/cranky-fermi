using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace TermTracker.Utilities
{
    /// <summary>
    /// Static utility class to handle operations on Enums. 
    /// Contains methods to return a description from an enum value and also to return a list of all value descriptions.
    /// </summary>
    public static class EnumUtilities
    {

        /// <summary>
        /// Returns the description attribute value for the provided enum value.
        /// If no description attribute value exists, the enum value is returned as a string.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="enumValue">The enum value used to locate the description value.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all description attribute values for the provided enum type as a List.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <returns></returns>
        public static List<string> EnumDescriptionsToList<TEnum>(Type enumType)
        {
            
            List<string> stringValues = new List<string>();

            var enumValues = System.Enum.GetValues(enumType).Cast<TEnum>().ToList();

            enumValues.ForEach(ev =>
                stringValues.Add(GetDescription(ev))
            );

            return stringValues;

        }

        /// <summary>
        /// Returns the enum value that contains the provided description value.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="description">The description value used to return the associated enum value.</param>
        /// <returns></returns>
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
