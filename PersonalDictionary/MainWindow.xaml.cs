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

        private void SortItemsInTheList(object sender, RoutedEventArgs e)
        {
            //TODO: Sort items in the list
        }


        private void LoadItemsToList()
        {
            var list = factory.GetData();
            this.listWithEnglsihWords.Items.Clear();
            foreach (var data in list)
            {
                this.listWithEnglsihWords.Items.Add(data.Word);
            }
        }

        private void GetWordTranslationOnSelectionChangeEvent(object sender, SelectionChangedEventArgs e)
        {
            //TODO: Get the translation from clicking on word in the list.
        }

    }
}
