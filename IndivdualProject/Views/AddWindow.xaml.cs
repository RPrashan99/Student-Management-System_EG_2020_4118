using IndivdualProject.ViewModels;
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

namespace IndivdualProject.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(AddWindowVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            vm.closeAction = () => this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            idBox.Clear();
            rsltBox.Clear();
            //rsltBox.SelectedItem = null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
