using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows;
using System.Windows.Input;

namespace HospitalManagementSystem.ViewModels.Dialogs;

public class PatientDialogViewModel : BaseViewModel
{
    private readonly PatientsService _patientsService;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? DateTime { get; set; }

    private bool _isMaleSelected;
    public bool IsMaleSelected
    {
        get => _isMaleSelected;
        set => SetProperty(ref _isMaleSelected, value);
    }

    public ICommand SaveCommand { get; }

    public PatientDialogViewModel()
    {
        SaveCommand = new Command(OnSave);

        _patientsService = new PatientsService();
    }

    private void OnSave()
    {
        bool isSuccess;
        var patient = new Patient()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            PhoneNumber = this.PhoneNumber,
            Birthdate = DateOnly.FromDateTime((DateTime)DateTime),
            Gender = IsMaleSelected ? Gender.Male : Gender.Female,
        };



        isSuccess = _patientsService.Create(patient);

        if (isSuccess)
        {
            MessageBoxExtension.ShowSuccess($"{})
        }
    }
}
