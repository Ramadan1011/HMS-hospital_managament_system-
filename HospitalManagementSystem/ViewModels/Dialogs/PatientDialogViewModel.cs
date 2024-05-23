﻿using HospitalManagementSystem.Models;
using HospitalManagementSystem.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalManagementSystem.ViewModels.Dialogs;

public class PatientDialogViewModel : BaseViewModel
{
    private readonly PatientsService _patientsService;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }

    public ICommand SaveCommand { get; }
    
    public PatientDialogViewModel()
    {
        SaveCommand = new Command(OnSave);

        _patientsService = new PatientsService();
    }

    private void OnSave()
    {
        var patient = new Patient()
        {
            FirstName = this.FirstName,
            LastName = this.LastName,
            // other porps
        };

        _patientsService.Create(patient);
    }
}
