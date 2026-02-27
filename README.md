🐶 VetPrescriptionKiosk

A modern self-service veterinary worming prescription calculator built in C# using WPF (.NET 8).

This project reimagines a university software design challenge and rebuilds it using modern software engineering principles, clean architecture, and real-world UX considerations.

📌 Project Background

This project originated from a university assignment that required the development of a worming dosage calculator for a veterinary clinic.

Rather than reproducing the original academic solution, this version has been redesigned and optimized to reflect:

Modern UX thinking

Enum-driven state management

Separation of concerns (MVVM architecture)

Domain modelling

Defensive programming

Self-service kiosk concept design

The goal was to transform a basic student exercise into an industry-ready desktop application that demonstrates structured software engineering practices.

💡 Concept Overview

Veterinary clinics often need to calculate correct worming dosages based on:

Dog weight

Age (for puppies)

Nursing status

Incorrect dosage can lead to health risks.

This system allows users to:

Enter dog details

Automatically calculate correct tablet dosage

Handle special cases (puppies, nursing dogs)

Prevent prescription for overweight dogs (> 40kg)

Generate a receipt with a transaction ID

Calculate full cost including prescription fee

The application is designed to function as a self-service kiosk system.

🏗 Architecture

The application follows the MVVM pattern:

Views        → WPF UI (XAML)
ViewModels   → Input validation & orchestration
Services     → Prescription calculation logic
Models       → Domain entities (Prescription, DogCondition)
Helpers      → Constants & shared utilities

Key design principles:

Separation of concerns

Enum-driven logic

Early validation (fail-fast approach)

Single responsibility methods

Extendable pricing model

🧠 Technical Features

C# (.NET 8)

WPF Desktop Application

MVVM architecture

Enum-based conditional UI

Cost calculation service layer

Defensive validation

Self-contained publishable executable

Unit testing (planned / implemented)

🚀 Future Enhancements

JSON transaction logging

PDF receipt export

Database integration

Multi-animal support

Payment system simulation

Touchscreen-optimized kiosk layout

📷 Screenshots

(Add screenshots once UI is built)

🧪 Running the Project

Clone repository

Open in Visual Studio 2022+

Ensure .NET 8 SDK is installed

Build and Run

To publish executable:

Right Click Project → Publish → Folder → Self-contained → win-x64
📈 Purpose

This project demonstrates the evolution of a simple academic exercise into a structured, maintainable, and scalable software system.

It reflects my continued focus on improving architecture design, UX flow, and clean C# development practices.