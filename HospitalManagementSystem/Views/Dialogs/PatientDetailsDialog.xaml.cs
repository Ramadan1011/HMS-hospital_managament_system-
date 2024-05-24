using HospitalManagementSystem.Models;
using HospitalManagementSystem.ViewModels.Dialogs;
using System.Windows;

namespace HospitalManagementSystem.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for PatientDetailsDialog.xaml
    /// </summary>
    public partial class PatientDetailsDialog : Window
    {
        public PatientDetailsDialog(Patient patient)
        {
            InitializeComponent();

            DataContext = new PatientDetailsDialog(patient);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
