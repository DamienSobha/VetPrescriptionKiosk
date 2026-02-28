🐶 VetPrescriptionKiosk

A modern self-service veterinary worming prescription calculator built in C# (.NET 8) using WPF and MVVM architecture.

This project reimagines a university software design challenge and rebuilds it using structured software engineering practices, clean architecture principles, and real-world UX considerations.

📌 Project Background

This project originated from a university assignment requiring the development of a worming dosage calculator for a veterinary clinic.

Instead of reproducing the original academic solution, this version was redesigned from the ground up to reflect:

Modern UX design thinking

MVVM architecture

Enum-driven state management

Clear separation of concerns

Domain modelling

Defensive programming

Self-service kiosk workflow

The objective was to transform a basic academic exercise into a structured, industry-style desktop application.

💡 Concept Overview

Veterinary clinics must calculate correct worming dosages based on:

Dog weight

Puppy age (special rules under 12 weeks)

Nursing status

Incorrect dosage can pose health risks.

This system allows users to:

Enter dog details

Automatically calculate correct tablet dosage

Handle special conditions (puppies, nursing dogs)

Prevent prescription for overweight dogs (> 40kg)

Generate a receipt with a unique transaction ID

Calculate full cost including prescription fee

Simulate payment and receipt printing

The application is designed to function as a self-service kiosk system.

🏗 Architecture

The application follows the MVVM pattern:

Views        → WPF UI (XAML)
ViewModels   → UI logic, state management, navigation
Services     → Prescription calculation logic
Models       → Domain entities (Prescription, DogCondition)
Helpers      → Constants, shared utilities
Themes       → Centralised styling via ResourceDictionary
Design Principles Applied

Separation of concerns

Enum-driven UI logic

Fail-fast validation

Centralised theming

Command-based navigation

Extensible pricing model

🧠 Technical Features

C# (.NET 8)

WPF Desktop Application

MVVM architecture

Screen-state navigation system

Enum-based conditional UI rendering

Centralised theme styling

Service-layer cost calculation

Defensive validation rules

Receipt generation (text export)

Self-contained publishable executable

🖥 Application Flow
Home Screen
    ↓
Enter Dog Details
    ↓
Prescription Output
    ↓
Payment Simulation
    ↓
Receipt Generation
    ↓
Return to Home
🧪 Running the Project
Requirements

Visual Studio 2022+

.NET 8 SDK

Steps

Clone the repository

Open the solution in Visual Studio

Build and run

Publish Executable
Right Click Project → Publish → Folder → Self-contained → win-x64

The executable will be located in:

bin/Release/net8.0-windows/
📷 Screenshots
<img width="402" height="600" alt="Screenshot 2026-02-28 233920" src="https://github.com/user-attachments/assets/cb16e6a2-f92d-410c-9b78-2a8284a6f754" />
<img width="400" height="598" alt="Screenshot 2026-02-28 234042" src="https://github.com/user-attachments/assets/f43114e1-ef8b-47e1-9da0-a03f7cbd4f24" />
<img width="398" height="600" alt="Screenshot 2026-02-28 234023" src="https://github.com/user-attachments/assets/80509c7d-9da2-4d4d-b035-8558058ff808" />
<img width="398" height="605" alt="Screenshot 2026-02-28 234003" src="https://github.com/user-attachments/assets/b368fabd-e931-4b2a-9479-c689954bd775" />
<img width="399" height="599" alt="Screenshot 2026-02-28 233936" src="https://github.com/user-attachments/assets/1c835d16-5136-4bc7-a34a-2f8fb8d54fa7" />

Home screen

Details screen

Prescription output

Payment confirmation

🚀 Future Enhancements

JSON transaction logging

PDF receipt export

Database integration

Multi-animal prescriptions

Real payment API integration

Touchscreen kiosk optimisation mode

Theme switching (Light/Dark mode)

📈 Purpose

This project demonstrates the evolution of a simple academic exercise into a structured, maintainable, and scalable software system.

It reflects my continued focus on:

Architecture design

Clean C# development

UX flow optimisation

Professional software structuring

🔥 Why This Version Is Stronger

Cleaner structure

Professional tone

No repetition

Clear architecture explanation

Clear feature list

Strong “Purpose” section (important for recruiters)

🎯 Optional (Advanced Polish)

If you really want to elevate it further:

Add:

🔍 Architecture Diagram (PNG)

Simple block diagram of:
View → ViewModel → Service → Model
