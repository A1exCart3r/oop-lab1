using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {        
        string path = Directory.GetCurrentDirectory();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ФОРМАТ ФАЙЛА УКАЗЫВАТЬ НЕ НУЖНО");
            Console.ResetColor();
            Console.WriteLine("Назовите имя исходного текстового файла в директории с программой");
            string firstFileName = Console.ReadLine() + ".txt";

            Console.WriteLine("Назовите имя файла - копии");
            string secondFileName = Console.ReadLine() + ".txt";

            if ((File.Exists(secondFileName)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Копия будет перезаписана при копировании.");
                Console.ResetColor();
            }
            try
            {
                File.Copy(firstFileName, secondFileName, true);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Файл успешно скопирован!");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую кнопку для сброса...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Исходный файл не был найден, проверьте имя и попробуйте еще раз.");
                Console.WriteLine("Нажмите любую кнопку для сброса...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}