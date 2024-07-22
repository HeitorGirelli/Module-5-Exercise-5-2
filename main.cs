using System;

class Program
{
    public static void Main(string[] args) {
   
        const int MinTemp = -30;
        const int MaxTemp = 130;
        const int NumTemps = 5;

        int[] temperatures = new int[NumTemps];
        int index = 0;

        while (index < NumTemps)
        {
            Console.Write($"Enter temperature {index + 1} (between {MinTemp} and {MaxTemp}): ");
            if (int.TryParse(Console.ReadLine(), out int temp) && temp >= MinTemp && temp <= MaxTemp)
            {
                temperatures[index] = temp;
                index++;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a temperature within the specified range.");
            }
        }

        bool isGettingWarmer = true;
        bool isGettingCooler = true;

        for (int i = 1; i < NumTemps; i++)
        {
            if (temperatures[i] < temperatures[i - 1]) // Corrected: use '<' for getting warmer
            {
                isGettingWarmer = false;
            }
            if (temperatures[i] > temperatures[i - 1]) // Corrected: use '>' for getting cooler
            {
                isGettingCooler = false;
            }
        }

        if (isGettingWarmer)
        {
            Console.WriteLine("Getting warmer");
        }
        else if (isGettingCooler)
        {
            Console.WriteLine("Getting cooler");
        }
        else
        {
            Console.WriteLine("It's a mixed bag");
        }

        Console.WriteLine("Temperatures entered: " + string.Join(", ", temperatures));
        double average = CalculateAverage(temperatures);
        Console.WriteLine("Average temperature: " + average);
    }

    static double CalculateAverage(int[] temps)
    {
        int sum = 0;
        foreach (int temp in temps)
        {
            sum += temp;
        }
        return (double)sum / temps.Length;
    }
}
