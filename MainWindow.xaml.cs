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

namespace DarkExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.Show();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            vm.Back();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowPath();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            vm.Up();
        }
    }
}
