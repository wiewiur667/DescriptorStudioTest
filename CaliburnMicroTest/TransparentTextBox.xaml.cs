using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DescriptorStudioTest
{
    /// <summary>
    /// Interaction logic for TransparentTextBox.xaml
    /// </summary>
    public partial class TransparentTextBox : TextBox
    {
        private string prevText;

        public TransparentTextBox()
        {
            InitializeComponent();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Keyboard.ClearFocus();
                    break;

                case Key.Escape:
                    this.Text = prevText;
                    Keyboard.ClearFocus();
                    break;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            prevText = this.Text;
        }
    }
}
