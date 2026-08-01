// ============================================================
// ASSESSMENT 2 - REFRESHER
// Question 2: Parking Fee Calculator
// Status: ✅ DONE
// Note: TopBrains was not working, solution implemented manually
// ============================================================

/*
 * QUESTION:
 * Write a C# console program called `ParkingFeeCalculator` that calculates
 * parking fees for different types of vehicles.
 *
 * Requirements:
 *   1. Support three vehicle types:
 *        - Car  (C) → Hourly rate: $3.00, Daily max: $25.00
 *        - Motorcycle (M) → Hourly rate: $2.00, Daily max: $15.00
 *        - Truck (T) → Hourly rate: $5.00, Daily max: $40.00
 *
 *   2. Fee Calculation Rules:
 *        - If parked for 0.5 hours or less → fee is $0 (free).
 *        - Fee = (hours - 0.5) × hourly rate.
 *        - If the calculated fee exceeds the daily maximum → cap it at the daily max.
 *        - If parked more than 8 hours → apply a 10% discount on the fee.
 *
 *   3. Process the following parking records and display details for each:
 *        ('C', 2.5), ('C', 12.0), ('M', 4.0), ('T', 6.5), ('C', 0.25), ('M', 10.0)
 *
 *   4. For each record, display:
 *        - Vehicle type name
 *        - Parking duration in hours
 *        - Hourly rate
 *        - Daily maximum
 *        - Total fee charged
 *
 * Expected Output (sample for first record - Car, 2.5 hrs):
 *   Vehicle: Car
 *   Parking Duration: 2.50 hours
 *   Hourly Rate: $3.00
 *   Daily Maximum: $25.00
 *   Total Fee: $6.00
 */

// ============================================================
// SOLUTION
// ============================================================

using System;
using System.Collections.Generic;

class ParkingFeeCalculator
{
    static void Main()
    {
        Console.WriteLine("=== PARKING FEE CALCULATOR ===\n");

        // List of parking records: (vehicleType, hoursParked)
        List<(char, double)> parkingRecords = new List<(char, double)>
        {
            ('C', 2.5),   // Car for 2.5 hours
            ('C', 12.0),  // Car for 12 hours (over 8 → discount applies)
            ('M', 4.0),   // Motorcycle for 4 hours
            ('T', 6.5),   // Truck for 6.5 hours
            ('C', 0.25),  // Car for 0.25 hours (≤ 0.5 → free)
            ('M', 10.0)   // Motorcycle for 10 hours (over 8 → discount applies)
        };

        // Process each parking record
        foreach (var record in parkingRecords)
        {
            CalculateAndDisplayFee(record.Item1, record.Item2);
            Console.WriteLine("------------------------");
        }
    }

    // Retrieves vehicle details, calculates the fee, and prints the result
    static void CalculateAndDisplayFee(char vehicleType, double hours)
    {
        double hourlyRate  = GetHourlyRate(vehicleType);
        double dailyMax    = GetDailyMaximum(vehicleType);
        string vehicleName = GetVehicleName(vehicleType);

        double fee = CalculateParkingFee(hours, hourlyRate, dailyMax);

        Console.WriteLine($"Vehicle: {vehicleName}");
        Console.WriteLine($"Parking Duration: {hours:F2} hours");
        Console.WriteLine($"Hourly Rate: ${hourlyRate:F2}");
        Console.WriteLine($"Daily Maximum: ${dailyMax:F2}");
        Console.WriteLine($"Total Fee: ${fee:F2}");
    }

    // Core fee calculation logic applying all business rules
    static double CalculateParkingFee(double hours, double hourlyRate, double dailyMax)
    {
        // Rule 1: Free parking for 30 minutes or less
        if (hours <= 0.5)
            return 0;

        // Rule 2: Charge for time beyond the first 30 minutes
        double fee = (hours - 0.5) * hourlyRate;

        // Rule 3: Cap fee at daily maximum
        if (fee > dailyMax)
            fee = dailyMax;

        // Rule 4: Apply 10% discount for stays longer than 8 hours
        if (hours > 8)
            fee = fee * 0.9;

        return fee;
    }

    // Returns the hourly rate based on vehicle type
    static double GetHourlyRate(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return 3.0;   // Car
            case 'M': return 2.0;   // Motorcycle
            case 'T': return 5.0;   // Truck
            default:  return 0.0;   // Unknown vehicle
        }
    }

    // Returns the daily maximum charge based on vehicle type
    static double GetDailyMaximum(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return 25.0;  // Car
            case 'M': return 15.0;  // Motorcycle
            case 'T': return 40.0;  // Truck
            default:  return 0.0;   // Unknown vehicle
        }
    }

    // Returns the human-readable vehicle name based on vehicle type code
    static string GetVehicleName(char vehicleType)
    {
        switch (char.ToUpper(vehicleType))
        {
            case 'C': return "Car";
            case 'M': return "Motorcycle";
            case 'T': return "Truck";
            default:  return "Unknown";
        }
    }
}
