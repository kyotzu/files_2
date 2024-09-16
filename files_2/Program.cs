using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите путь к директории:");
        string directoryPath = Console.ReadLine();

        try
        {
            long folderSize = GetDirectorySize(directoryPath);
            Console.WriteLine($"Размер папки: {folderSize} байт");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static long GetDirectorySize(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Директория по пути {directoryPath} не найдена.");
        }

        long totalSize = 0;

        DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
        FileInfo[] files = dirInfo.GetFiles();
        foreach (FileInfo file in files)
        {
            totalSize += file.Length;
        }

        DirectoryInfo[] directories = dirInfo.GetDirectories();
        foreach (DirectoryInfo directory in directories)
        {
            totalSize += GetDirectorySize(directory.FullName);
        }

        return totalSize;
    }
}
