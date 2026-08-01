// Question 2: Parking Fee Calculator
// Write a program to calculate parking fees for Cars, Motorcycles and Trucks.
// Car: $3/hr, max $25. Motorcycle: $2/hr, max $15. Truck: $5/hr, max $40.
// First 30 minutes are free. Fee = (hours - 0.5) x hourly rate.
// If fee exceeds daily max, cap it. If parked more than 8 hours, give 10% discount.
// Process a list of parking records and display vehicle, duration, rate, max and total fee.

using System;
using System.Collections.Generic;

class ParkingFeeCalculator
{
    static void Main()
    {
        Console.WriteLine("=== PARKING FEE CALCULATOR ===\n");

        List<(char, double)> parkingRecords = new List<(char, double)>
        {
            ('C', 2.5),
            ('C', 12.0),
            ('M', 4.0),
            ('T', 6.5),
            ('C', 0.25),
            ('M', 10.0)
        };

        foreach (var record in parkingRecords)
        {
            CalculateAndDisplayFee(record.Item1, record.Item2);
            Console.WriteLine("------------------------");
        }
    }

    static void CalculateAndDisplayFee(char vehicleType, double hours)
    {
        double hourlyRate = GetHourlyRate(vehicleType);
        double dailyMax = GetDailyMaximum(vehicleType);
        string vehicleName = GetVehicleName(vehicleType);

        double fee = CalculateParkingFee(hours, hourlyRate, dailyMax);

        Console.WriteLine($"Vehicle: {vehicleName}");
        Console.WriteLine($"Parking Duration: {hours:F2} hours");
        Console.WriteLine($"Hourly Rate: ${hourlyRate:F2}");
        Console.WriteLine($"Daily Maximum: ${dailyMax:F2}");
        Console.WriteLine($"Total Fee: ${fee:F2}");
    }

    static double CalculateParkingFee(double hours, double hourlyRate, double dailyMax)
    {
        if (hours <= 0.5)
            return 0;

        double fee = (hours - 0.5) * hourlyRate;

        if (fee > dailyMax)
            fee = dailyMax;

        if (hours > 8)
            fee = fee * 0.9;

        return fee;
    }

    static double GetHourlyRate(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return 3.0;
            case 'M': return 2.0;
            case 'T': return 5.0;
            default: return 0.0;
        }
    }

    static double GetDailyMaximum(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return 25.0;
            case 'M': return 15.0;
            case 'T': return 40.0;
            default: return 0.0;
        }
    }

    static string GetVehicleName(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return "Car";
            case 'M': return "Motorcycle";
            case 'T': return "Truck";
            default: return "Unknown";
        }
    }
}
