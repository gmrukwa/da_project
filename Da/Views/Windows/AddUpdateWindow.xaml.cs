using System.Windows;
using Da.ViewModels.AddEntityVms;

namespace Da
{
    /// <summary>
    /// Interaction logic for AddUpdateWindow.xaml
    /// </summary>
    public partial class AddUpdateWindow : Window
    {
        public AddUpdateWindow(IAddEntityVm vm)
        {
            InitializeComponent();

            DataContext = vm;
        }

        private void AcceptChanges(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DiscardChanges(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
