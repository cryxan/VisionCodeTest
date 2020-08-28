using GuiClient.Http;
using GuiClient.ViewModel;
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

namespace GuiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PatientViewModel _patientViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _patientViewModel = new PatientViewModel();
            DataContext = _patientViewModel;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
