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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalDictionary
{
    using Contracts;
    using WPFs;
    using Factory;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window addingWordWindow;
        private ITranslationObjectsFactory factory;

        public MainWindow()
        {
            this.InitializeComponent();
            this.addingWordWindow = new AddingWindow();
            factory = TranslationObjectsFactory.GetFactoryInstance();
            this.LoadItemsToList();
            
        }

        private void AddNewWord(object sender, RoutedEventArgs e)
        {
            this.addingWordWindow.ShowDialog();
            this.LoadItemsToList();
        }

        private void LoadItemsToList()
        {
            this.listWithEnglsihWords.Items.Clear();
            var translationObjrctCollection = factory.GetData();
            if (!(bool)ascendingRadioButton.IsChecked)
            {
                translationObjrctCollection = translationObjrctCollection.OrderBy(obj => obj.Word).ToList();
            }
            else
            {
                translationObjrctCollection = translationObjrctCollection.OrderByDescending(obj => obj.Word).ToList();
            }

            foreach (var data in translationObjrctCollection)
            {
                this.listWithEnglsihWords.Items.Add(data.Word);
            }
        }

        private void GetWordTranslationOnSelectionChangeEvent(object sender, SelectionChangedEventArgs e)
        {
            var translationObjectCollection = factory.GetData();
            var item = this.listWithEnglsihWords.SelectedItem;
            if (item != null)
            {
                string word = item.ToString();
                var translationObject = translationObjectCollection.Where(obj => obj.Word == word).FirstOrDefault();
                this.translationText.Text = translationObject.Translation;
                this.wordLabel.Content = translationObject.Word;
                if (translationObject.Status)
                {
                    this.wordLabel.Foreground = Brushes.Green;
                }
                else
                {
                    this.wordLabel.Foreground = Brushes.Red;
                }
            }
            
        }

        private void SortList(object sender, RoutedEventArgs e)
        {
            this.LoadItemsToList();
        }

    }
}
