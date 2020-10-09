using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TermTracker.Utilities
{
    public static class InputValidator
    {
        public static bool InputsNotNull<T>(List<T> inputs)
        {
            int nullInputsCount = 0;
            Type inputType = typeof(T);

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
                        
            return (nullInputsCount == 0); 
        }

        public static bool IsValidEmail(string input)
        {
            Regex emailRegex = new Regex(@"^[a-zA-z0-9_\-\.]+\@[a-zA-z0-9_\-\.]+\.[a-zA-Z\.]+$");
            return emailRegex.IsMatch(input);
        }

        public static bool IsValidPhoneNumber(string input)
        {
            Regex phoneRegex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
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
