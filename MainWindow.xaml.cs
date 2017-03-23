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

        private void btnPasteAndGo_Click(object sender, RoutedEventArgs e)
        {
            vm.CurrentPath = Clipboard.GetText();

            vm.ShowPath();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(vm.SelectedDirectoryFileInfo.FullName);
        }

        private void btnRevealInExplorer_Click(object sender, RoutedEventArgs e)
        {            
            string argument = "/select, \"" + vm.SelectedDirectoryFileInfo.FullName + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void btnOpenWithCode_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string argument = "\"" + vm.SelectedDirectoryFileInfo.FullName + "\"";

                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Microsoft VS Code\Code.exe", argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FavoritesListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.ShowFavorite();
        }

        private void txtCurrentPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                vm.ShowPath();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
