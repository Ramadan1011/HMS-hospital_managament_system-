using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using System.Windows;

namespace HospitalManagementSystem.Views.Dialogs;

/// <summary>
/// Interaction logic for DoctorDialog.xaml
/// </summary>
public partial class DoctorsDialog : Window
{
    private readonly DoctorsService _doctorsService;
    private readonly bool isEditingMode;
    public DoctorsDialog()
    {
        InitializeComponent();

        _doctorsService = new DoctorsService();
        IdInput.Text = 0.ToString();
        IdInput.IsEnabled = false;

        Title = "Add Doctor";
    }

    public DoctorsDialog(Doctor doctor)
        : this()
    {
        Title = "Edit Doctor details";

        isEditingMode = true;
        IdInput.IsEnabled = false;

        PopulateData(doctor);
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
        int id = int.Parse(IdInput.Text);
        string firstName = FirstNameInput.Text;
        string lastName = LastNameInput.Text;
        string phoneNumber = PhoneNumberInput.Text;

        var newDoctor = new Doctor(id, firstName, lastName, phoneNumber);

        bool isSuccess;

        if (isEditingMode)
        {
            isSuccess = _doctorsService.UpdateDoctor(newDoctor);
        }
        else
        {
            isSuccess = _doctorsService.Create(newDoctor);
        }

        if (isSuccess && isEditingMode)
        {
            MessageBoxExtension.ShowSuccess($"{newDoctor.FirstName} {newDoctor.LastName} was successfully updated.");
            Close();
        }
        else
        {
            MessageBoxExtension.ShowSuccess($"{newDoctor.FirstName} {newDoctor.LastName} was successfully added.");
        }
    }

    private void Cancel_Clicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
