using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.ViewModels.Dialogs;
using System.Drawing.Drawing2D;
using System.Windows;

namespace HospitalManagementSystem.Views.Dialogs;

/// <summary>
/// Interaction logic for DoctorDialog.xaml
/// </summary>
public partial class DoctorsDialog : Window
{
    private readonly DoctorsService _doctorsService;
    private readonly bool IsEditingMode;
    public DoctorsDialog()
    {
        InitializeComponent();

        Title = "Add Doctor";

        _doctorsService = new DoctorsService();
    }

    public DoctorsDialog(Doctor doctor)
        : this()
    {
        Title = "Edit Doctor";

        DataContext = new DoctorDialogViewModel(doctor);
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
