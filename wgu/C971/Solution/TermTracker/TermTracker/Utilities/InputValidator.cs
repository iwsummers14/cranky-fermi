using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TermTracker.Utilities
{
    /// <summary>
    /// Static class to handle various input validation tasks.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// For input types Entry, DatePicker, and Picker, ensures that the input is not empty or null.
        /// </summary>
        /// <typeparam name="T">The type to evaluate input for.</typeparam>
        /// <param name="inputs">A list of input controls of type T to evaluate.</param>
        /// <returns></returns>
        public static bool InputsNotNull<T>(List<T> inputs)
        {
            int nullInputsCount = 0;
            Type inputType = typeof(T);

            // for each input in the list, the type is converted to the specified type and then evaluated.
            // if the input is empty or null, the null inputs count is incremented.

            foreach (T input in inputs)
            {
                switch (inputType.Name)
                {
                    case nameof(Entry):
                        Entry entry = (Entry)Convert.ChangeType(input, typeof(Entry));
                        if (entry.Text == null || entry.Text == String.Empty)
                        {
                            nullInputsCount++;
                        }
                        break;

                    case nameof(DatePicker):
                        DatePicker dPicker = (DatePicker)Convert.ChangeType(input, typeof(DatePicker));
                        if ( dPicker.Date == null)
                        {
                            nullInputsCount++;
                        }
                        break;

                    case nameof(Picker):
                        Picker picker = (Picker)Convert.ChangeType(input, typeof(Picker));
                        if (picker.SelectedIndex == -1)
                        {
                            nullInputsCount++;
                        }
                        break;

                    default:
                        nullInputsCount++;
                        break;

                }
            }
                        
            // return boolean on expression 
            return (nullInputsCount == 0); 
        }

        /// <summary>
        /// Method to evaluate an email input using a regular expression.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string input)
        {
            Regex emailRegex = new Regex(@"^[a-zA-z0-9_\-\.]+\@[a-zA-z0-9_\-\.]+\.[a-zA-Z\.]+$");
            return emailRegex.IsMatch(input);
        }

        public static bool IsValidPhoneNumber(string input)
        {
            Regex phoneRegex = new Regex(@"^\(\d{3}\)\s\d{3}-\d{4}$");
            return phoneRegex.IsMatch(input);
        }

        public static bool IsValidDateRange(DateTime? start, DateTime? end, bool canBeSameDay = false)
        {
            bool IsValid = false;

            if (start == null || end == null)
            {
                return IsValid;
            }

            if (start > end)
            {
                return IsValid;
            }

            if (canBeSameDay)
            {
                if (start == end || start < end)
                {
                    IsValid = true;
                }
            }
            else if (start < end)
            {
                IsValid = true;
            }

            return IsValid;
        }
    }
}
