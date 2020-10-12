using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TermTracker.Behaviors
{
    /// <summary>
    /// Behavior to define a mask that can be applied
    /// </summary>
    public class PhoneMaskBehavior : Behavior<Entry>
    {
        private string _mask = "";

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
            }
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            var inputText = entry.Text;

            if (!string.IsNullOrWhiteSpace(Mask))
            {
                // set max length based on mask provided
                if (inputText.Length == _mask.Length)
                {
                    entry.MaxLength = _mask.Length;
                }
            }

            // check for operations where the entry was empty, or user is removing text 
            if ((e.OldTextValue == null) || (e.OldTextValue.Length <= e.NewTextValue.Length))
            {
                // evaluate positions and apply mask
                for (int i = Mask.Length; i >= inputText.Length; i--)
                {
                    if (Mask[(inputText.Length - 1)] != 'X')
                    {
                        inputText = inputText.Insert((inputText.Length - 1), Mask[(inputText.Length - 1)].ToString());
                    }
                }
            }
                                
            entry.Text = inputText;

        }

        // event handler method for attaching to entry
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        // event handler method for detaching from entry
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
