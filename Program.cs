using System;
using System.IO;

class Program
{
    static void Main()
    {
        string rootDirectory = @"D:\day8assignment10";

        Console.WriteLine("Choose operation you want to perform");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Append");
        Console.WriteLine("4. Delete");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            switch (choice)
            {
                case 1:
                    Console.Write("Enter the filename: ");
                    string createFileName = Console.ReadLine();
                    Console.Write("Enter the content: ");
                    string createContent = Console.ReadLine();
                    CreateFile(rootDirectory, createFileName, createContent);
                    break;

                case 2:
                    Console.Write("Enter the filename to read: ");
                    string readFileName = Console.ReadLine();
                    ReadFile(rootDirectory, readFileName);
                    break;

                case 3:
                    Console.Write("Enter the filename to append: ");
                    string appendFileName = Console.ReadLine();
                    Console.Write("Enter the content to append: ");
                    string appendContent = Console.ReadLine();
                    AppendToFile(rootDirectory, appendFileName, appendContent);
                    break;

                case 4:
                    Console.Write("Enter the filename to delete: ");
                    string deleteFileName = Console.ReadLine();
                    DeleteFile(rootDirectory, deleteFileName);
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void CreateFile(string rootDirectory, string fileName, string content)
    {
        string fullPath = Path.Combine(rootDirectory, fileName);

        try
        {
            using (StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(content);
            }

            Console.WriteLine($"File '{fileName}' created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while creating the file: {ex.Message}");
        }
    }

    static void ReadFile(string rootDirectory, string fileName)
    {
        string fullPath = Path.Combine(rootDirectory, fileName);

        try
        {
            if (File.Exists(fullPath))
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    string content = sr.ReadToEnd();
                    Console.WriteLine($"Content of '{fileName}':");
                    Console.WriteLine(content);
                }
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while reading the file: {ex.Message}");
        }
    }

    static void AppendToFile(string rootDirectory, string fileName, string content)
    {
        string fullPath = Path.Combine(rootDirectory, fileName);

        try
        {
            if (File.Exists(fullPath))
            {
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.WriteLine(content);
                }

                Console.WriteLine($"Content appended to '{fileName}' successfully.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while appending to the file: {ex.Message}");
        }
    }

    static void DeleteFile(string rootDirectory, string fileName)
    {
        string fullPath = Path.Combine(rootDirectory, fileName);

        try
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while deleting the file: {ex.Message}");
        }
    }
}
