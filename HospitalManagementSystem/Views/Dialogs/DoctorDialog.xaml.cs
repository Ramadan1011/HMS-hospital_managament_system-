using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.ViewModels.Dialogs;
using System.Windows;

namespace HospitalManagementSystem.Views.Dialogs;

/// <summary>
/// Interaction logic for DoctorDialog.xaml
/// </summary>
public partial class DoctorsDialog : Window
{
    public DoctorsDialog()
    {
        InitializeComponent();

        DataContext = new DoctorDialogViewModel();

        Title = "Add Doctor";
    }

    public DoctorsDialog(Doctor doctor)
        : this()
    {
        Title = "Edit Doctor";

        PopulateData(doctor);

        DataContext = new DoctorDialogViewModel(doctor);
    }

    private void PopulateData(Doctor doctor)
    {
        IdInput.Text = doctor.Id.ToString();
        FirstNameInput.Text = doctor.FirstName.ToString();
        LastNameInput.Text = doctor.LastName.ToString();
        PhoneNumberInput.Text = doctor.PhoneNumber.ToString();
    }

    private void Save_Clicked(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Cancel_Clicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
