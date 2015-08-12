using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalDictionary.WPFs
{
    using Contracts;
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        private IWriter writer;
        public AddingWindow(IWriter writer)
        {
            InitializeComponent();
            this.writer = writer;
        }

        private void AddToList(object sender, RoutedEventArgs e)
        {
            string word = this.wordTextBox.Text;
            string translation = new TextRange(translationTextBox.Document.ContentStart, translationTextBox.Document.ContentEnd).Text;
            try
            {
                var newObject = new TranslationObject(word, translation);
                writer.Write(newObject);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You can't leave empty boxes!!", "WRONG!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();
        }


    }
}
