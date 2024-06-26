﻿using HospitalManagementSystem.Helpers;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace HospitalManagementSystem.ViewModels.Dialogs;

public class PatientDialogViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly PatientsService _patientsService;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? DateTime { get; set; }

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
    private string _selectedDateTime;
    public string SelectedDateTime
    {
        get => _selectedDateTime;
        set
        {
            _selectedDateTime = value;
            OnPropertyChanged(nameof(SelectedDateTime));
        }
    }



    private string _selectedGender;
    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
            OnPropertyChanged(nameof(SelectedGender));
        }
    }

    private bool _isMaleSelected;
    public bool IsMaleSelected
    {
        get => _isMaleSelected;
        set => SetProperty(ref _isMaleSelected, value);
    }

    public ICommand SaveCommand { get; }

    public PatientDialogViewModel()
    {
        SaveCommand = new Command(OnSaveToCreate);

        _patientsService = new PatientsService();
    }


    public PatientDialogViewModel(Patient patient)
    {
        PopulateDate(patient);

        IsMaleSelected = patient.Gender == Gender.Male;

        SaveCommand = new Command(OnSaveToUpdate);

        _patientsService = new PatientsService();
    }

    private void OnSaveToUpdate()
    {
        var newPatient = new Patient()
        {
            Id = SelectedId,
            FirstName = SelectedFirstName,
            LastName = SelectedLastName,
            PhoneNumber = SelectedPhoneNumber,
            Birthdate = DateOnly.FromDateTime(Convert.ToDateTime(SelectedDateTime)),
            Gender = IsMaleSelected ? Gender.Male : Gender.Female,
        };

        bool isSuccess;

        isSuccess = _patientsService.Update(newPatient);

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
        var newPatient = new Patient()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            PhoneNumber = this.PhoneNumber,
            Birthdate = DateOnly.FromDateTime((DateTime)this.DateTime),
            Gender = IsMaleSelected ? Gender.Male : Gender.Female,
        };

        bool isSuccess;

        isSuccess = _patientsService.Create(newPatient);

        if (isSuccess)
        {
            MessageBoxExtension.ShowSuccess($"{this.FirstName} {this.LastName} was added successfully");
        }
        else
        {
            MessageBoxExtension.ShowError($"Something went wrong to add {this.FirstName} {this.LastName}");
        }
    }

    private void PopulateDate(Patient patient)
    {
        SelectedId = patient.Id;
        SelectedFirstName = patient.FirstName;
        SelectedLastName = patient.LastName;
        SelectedPhoneNumber = patient.PhoneNumber;
        SelectedDateTime = patient.Birthdate.ToString();
        IsMaleSelected = patient.Gender == Gender.Male;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
