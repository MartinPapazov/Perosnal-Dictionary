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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IReader reader;

        public MainWindow()
        {
            this.InitializeComponent();
            this.reader = new Reader();
            this.LoadItems();
        }

        private void AddNewWord(object sender, RoutedEventArgs e)
        {
            var addingWordWindow = new AddingWindow(new Writer());
            addingWordWindow.ShowDialog();
            this.LoadItems();
        }

        private void SortItemsInTheList(object sender, RoutedEventArgs e)
        {

        }

        private void LoadItems()
        {
            this.listWithEnglsihWords.Items.Clear();
            var words = reader.Words();
            foreach (var word in words)
	        {
                this.listWithEnglsihWords.Items.Add(word.Word);
	        }
        }

    }
}
