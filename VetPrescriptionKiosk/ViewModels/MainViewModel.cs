using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VetPrescriptionKiosk.Models;
using VetPrescriptionKiosk.Services;
using VetPrescriptionKiosk.Helpers;
using System.Collections.Generic;

namespace VetPrescriptionKiosk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly PrescriptionCalculator _calculator;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsWeightRequired
        {
            get
            {
                if (SelectedCondition == DogCondition.Puppy)
                    return AgeWeeks >= 12; // only require weight if puppy is 12+ weeks

                return true; // Normal + Nursing always require weight
            }
        }

        public IEnumerable<DogCondition> DogConditions { get; } = Enum.GetValues<DogCondition>();

        private float _weight;
        public float Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private int _ageWeeks;
        public int AgeWeeks
        {
            get => _ageWeeks;
            set
            {
                _ageWeeks = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsWeightRequired));
                if (SelectedCondition == DogCondition.Puppy && AgeWeeks < 12)
                {
                    Weight = 0;
                }
            }
        }

        private DogCondition _selectedCondition;
        public DogCondition SelectedCondition
        {
            get => _selectedCondition;
            set
            {
                _selectedCondition = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPuppy));
                OnPropertyChanged(nameof(IsWeightRequired));
            }
        }

        public enum ScreenState { Home, Details, Receipt, PaymentSuccess }

        public ScreenState CurrentScreen { get; set; } = ScreenState.Home;

        public ICommand StartCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand PrintReceiptCommand { get; }

        public bool IsPuppy => SelectedCondition == DogCondition.Puppy;

        private Prescription? _result;
        public Prescription? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            _calculator = new PrescriptionCalculator();
            CalculateCommand = new RelayCommand(_ => Calculate());
        }

        private void Calculate()
        {
            try
            {
                ErrorMessage = null;
                Result = _calculator.Calculate(Weight, AgeWeeks, SelectedCondition);
            }
            catch (Exception ex)
            {
                Result = null;
                ErrorMessage = ex.Message;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}