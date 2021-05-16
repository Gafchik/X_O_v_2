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
using X_O_v_2.Control;
using X_O_v_2.ModelView;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using X_O_v_2.View.ViewModel;
namespace X_O_v_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
           /* foreach (var i in (DataContext as ViewModel).Cells)
                Grid.Children.Add(i);*/
            
            foreach (UIElement el in Grid.Children)
            {
                if (el is Cell)
                {
                    (el as Cell).btn.Command = (DataContext as ViewModel).ChekRezult;
                    (el as Cell).btn.CommandParameter = (Grid.Children);
                    (el as Cell).btn.Click += Btn_Click;

                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e) => (DataContext as ViewModel).Click(sender as Button);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement el in Grid.Children)
            {
                if (el is Cell)
                {
                    (el as Cell).btn.IsEnabled = true;                 
                    (el as Cell).btn.Content = "";
                }
            }
        }
    }
}
