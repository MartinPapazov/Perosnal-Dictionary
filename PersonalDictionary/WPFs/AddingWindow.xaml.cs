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
    using Factory;
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        private ITranslationObjectsFactory factory;

        public AddingWindow()
        {
            InitializeComponent();
            this.factory = TranslationObjectsFactory.GetFactoryInstance();
        }

        private void AddToList(object sender, RoutedEventArgs e)
        {
            string word = this.wordTextBox.Text;
            string translation = new TextRange(this.translationTextBox.Document.ContentStart, this.translationTextBox.Document.ContentEnd).Text;
            try
            {
                var newObject = new TranslationObject(word, translation, false);
                factory.AddNewData(newObject);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("You can't leave empty boxes!!", "WRONG!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.ClearTextFields();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.ClearTextFields();
            
        }


        private void ClearTextFields()
        {
            this.wordTextBox.Text = string.Empty;
            this.translationTextBox.Document.Blocks.Clear();
            this.Hide();
        }
    }
}
