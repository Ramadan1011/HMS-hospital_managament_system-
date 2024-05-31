using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using HospitalManagementSystem.ViewModels.Dialogs;
using System.Windows;

namespace HospitalManagementSystem.Views.Dialogs;

/// <summary>
/// Interaction logic for PatientDialog.xaml
/// </summary>
public partial class PatientDialog : Window
{
    public PatientDialog()
    {
        InitializeComponent();

        DataContext = new PatientDialogViewModel();
    }


    //private void Save_Clicked(object sender, RoutedEventArgs e)
    //{
    //   // Close();
    //}

    private void Cancel_Clicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
