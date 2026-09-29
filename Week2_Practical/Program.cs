using System;

Main();

void Main()
{
    PrintMenu(
        "1. Hello in French",
        "2. Hello in Spanish",
        "3. Hello in German",
        "4. Hello in Italian",
        "5. Exit Application"
    );
    // Read and convert the user's choice
    int option = InputOption();
    Console.WriteLine($"Option stored in Main: {option}");
    // Determine message for the selected option and display it
    string message = GetMessage(option);
    Console.WriteLine(message);
}

void PrintMenu(params string[] options)
{
    Console.WriteLine();
    Console.WriteLine("--- Menu ---");
    for (int i = 0; i < options.Length; i++)
    {
        Console.WriteLine(options[i]);
    }
    Console.WriteLine();
}

string GetMessage(int option)
{
    // Use a switch statement to determine which greeting to return
    switch (option)
    {
        case -1:
            return "An error occurred while reading your input.";
        case 1:
            return "Bonjour"; // French
        case 2:
            return "Hola"; // Spanish
        case 3:
            return "Guten Tag"; // German
        case 4:
            return "Ciao"; // Italian
        default:
            return "Invalid option selected.";
    }
}

int InputOption()
{
    while (true)
    {
        try
        {
            Console.Write("Select an option and press Enter: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("No input was provided.");

            int option = int.Parse(input);
            return option;
        }
        catch (FormatException fx)
        {
            Console.WriteLine("Input error: please enter a valid integer (e.g., 1).\nDetails: " + fx.Message);
            // loop again to allow the user to retry
        }
        catch (OverflowException ox)
        {
            Console.WriteLine("Input error: the number entered is too large or too small.\nDetails: " + ox.Message);
        }
        catch (ArgumentException ax)
        {
            Console.WriteLine("Input error: " + ax.Message + " Please try again.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred while reading your choice.\nDetails: " + ex.Message);
            Console.WriteLine("The program will return -1 to indicate failure.");
            return -1;
        }
    }
}

void PromptSentenceAndCount()
{
    Console.WriteLine("Please enter a sentence:");
    string? sentence = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(sentence))
    {
        Console.WriteLine("No sentence was provided.");
        return;
    }
    int wordCount = CountWords(sentence);
    Console.WriteLine($"The sentence contains {wordCount} words.");
}
