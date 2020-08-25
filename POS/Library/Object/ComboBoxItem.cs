using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Library.Object
{
    public class ComboBoxItem
    {
        public ComboBoxItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public ComboBoxItem()
        {

        }
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
