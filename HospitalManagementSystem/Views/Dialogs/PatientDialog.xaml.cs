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
    private readonly PatientDialogViewModel viewModel;
    public PatientDialog()
    {
        InitializeComponent();

        viewModel = new PatientDialogViewModel();
        DataContext = viewModel;
    }
    public PatientDialog(Patient patient)
        :this()
    {
        viewModel = new PatientDialogViewModel(patient);
        DataContext = viewModel;
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
