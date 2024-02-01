internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 2) 
        {
            Console.WriteLine("Нужно 2 аргумента для работы программы: имя исходного файла и имя выходного файла с указанием расширения.");
            return 1;
        }

        string firstFile = args[0];
        string secondFile = args[1];
        string readstring;

        try 
        {
            using (StreamReader sr = new StreamReader(firstFile))
            using (StreamWriter sw = new StreamWriter(secondFile))
            { 
                while (!sr.EndOfStream)
                {
                    readstring = sr.ReadLine();
                    sw.WriteLine(readstring);
                }
            Console.WriteLine("Файл успешно скопирован");
            return 0;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка");
            return 1;
        }
    }
}