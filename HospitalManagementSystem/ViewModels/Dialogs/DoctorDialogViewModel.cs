using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace HospitalManagementSystem.ViewModels.Dialogs;

public class DoctorDialogViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    private int _selectedId;
    public int SelectedId
    {
        get => _selectedId;
        set
        {
            _selectedId = value;
            OnPropertyChanged(nameof(SelectedId));
        }
    }
    private string _selectedfirstName;
    public string SelectedFirstName
    {
        get => _selectedfirstName;
        set
        {
            _selectedfirstName = value;
            OnPropertyChanged(nameof(SelectedFirstName));
        }
    }
    private string _selectedLastName;
    public string SelectedLastName
    {
        get => _selectedLastName;
        set
        {
            _selectedLastName = value;
            OnPropertyChanged(nameof(SelectedLastName));
        }
    }
    private string _selectedPhoneNumber;
    public string SelectedPhoneNumber
    {
        get => _selectedPhoneNumber;
        set
        {
            _selectedPhoneNumber = value;
            OnPropertyChanged(nameof(SelectedPhoneNumber));
        }
    }

    private readonly DoctorsService _doctorsService;
    public ObservableCollection<Specialization> Specializations { get; }
    public ICommand SaveCommand { get; }

    public DoctorDialogViewModel()
    {
        SaveCommand = new Command(OnSaveToCreate);

        _doctorsService = new();
    }


    public DoctorDialogViewModel(Doctor doctor)
    {
        PopulateDate(doctor);

        SaveCommand = new Command(OnSaveToUpdate);

        _doctorsService = new();
    }

    private void OnSaveToUpdate()
    {
        var newPatient = new Doctor()
        {
            Id = SelectedId,
            FirstName = SelectedFirstName,
            LastName = SelectedLastName,
            PhoneNumber = SelectedPhoneNumber,
        };

        bool isSuccess;

        isSuccess = _doctorsService.UpdateDoctor(newPatient);

        if (isSuccess)
        {
            MessageBoxExtension.ShowSuccess($"{SelectedFirstName}  {SelectedLastName} was updated successfully.");
        }
        else
        {
            MessageBoxExtension.ShowError($"Something went wrong to update {SelectedFirstName} {SelectedLastName}");
        }
    }

    private void OnSaveToCreate()
    {
        var newDoctor = new Doctor()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            PhoneNumber = this.PhoneNumber,
        };

        bool isSuccess;

        isSuccess = _doctorsService.Create(newDoctor);

        if (isSuccess)
        {
            MessageBoxExtension.ShowSuccess($"{this.FirstName} {this.LastName} was added successfully");
        }
        else
        {
            MessageBoxExtension.ShowError($"Something went wrong to add {this.FirstName} {this.LastName}");
        }
    }

    private void PopulateDate(Doctor doctor)
    {
        SelectedId = doctor.Id;
        SelectedFirstName = doctor.FirstName;
        SelectedLastName = doctor.LastName;
        SelectedPhoneNumber = doctor.PhoneNumber;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}