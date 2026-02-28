using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VetPrescriptionKiosk.Models;
using VetPrescriptionKiosk.Services;
using VetPrescriptionKiosk.Helpers;

namespace VetPrescriptionKiosk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly PrescriptionCalculator _calculator;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            _calculator = new PrescriptionCalculator();

            StartCommand = new RelayCommand(_ => GoToDetails());
            SubmitCommand = new RelayCommand(_ => Submit());
            PayCommand = new RelayCommand(_ => CompletePayment(), _ => Result != null);
            CancelCommand = new RelayCommand(_ => ReturnHome());
            PrintReceiptCommand = new RelayCommand(_ => PrintReceipt(), _ => Result != null);
        }

        // -------------------------
        // Navigation State
        // -------------------------

        private ScreenState _currentScreen = ScreenState.Home;
        public ScreenState CurrentScreen
        {
            get => _currentScreen;
            set
            {
                _currentScreen = value;
                OnPropertyChanged();
            }
        }

        // -------------------------
        // Dog Inputs
        // -------------------------

        public IEnumerable<DogCondition> DogConditions { get; } = Enum.GetValues<DogCondition>();

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
                    Weight = 0;
            }
        }

        public bool IsPuppy => SelectedCondition == DogCondition.Puppy;

        public bool IsWeightRequired => SelectedCondition == DogCondition.Puppy ? AgeWeeks >= 12 : true;

        // -------------------------
        // Result State
        // -------------------------

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

        // -------------------------
        // Commands
        // -------------------------

        public ICommand StartCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand PrintReceiptCommand { get; }

        // -------------------------
        // Navigation Methods
        // -------------------------

        private void GoToDetails()
        {
            ResetState();
            CurrentScreen = ScreenState.Details;
        }

        private void Submit()
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

            // Always navigate to Output screen after submit
            CurrentScreen = ScreenState.Output;
        }

        private void CompletePayment()
        {
            CurrentScreen = ScreenState.PaymentSuccess;
        }

        private void ReturnHome()
        {
            ResetState();
            CurrentScreen = ScreenState.Home;
        }

        private void ResetState()
        {
            Weight = 0;
            AgeWeeks = 0;
            SelectedCondition = default;
            Result = null;
            ErrorMessage = null;
        }

        // -------------------------
        // Receipt Simulation
        // -------------------------

        private void PrintReceipt()
        {
            if (Result == null) return;

            var receiptText = $"Order ID: {Result.TransactionId}\n\n";

            foreach (var line in Result.Lines)
                receiptText += $"{line.Description} x{line.Quantity} - £{line.LineTotal:F2}\n";

            receiptText += $"\nTotal: £{Result.TotalCost:F2}";

            var path = $"Receipt_{Result.TransactionId}.txt";

            System.IO.File.WriteAllText(path, receiptText);
        }

        // -------------------------
        // Notify
        // -------------------------

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}