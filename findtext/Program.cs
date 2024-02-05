internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Неверное количество аргументов - Введите аргументы в формате \"findtext.exe \"Евгений Онегин.txt\" \"Я к Вам пишу\"\"");
            return 1;
        }

        string file = args[0];
        string lineFromFile;
        string searchText = args[1];
        int lineNumber = 1;
        bool textIsFound = false;

        if (searchText == "") 
        {
            Console.WriteLine("Вы ничего не ввели для поиска");
            return 1;
        }

        try
        {
            using(StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    lineFromFile = sr.ReadLine();
                    if (lineFromFile.Contains(searchText))
                    {
                        Console.WriteLine(lineNumber);
                        textIsFound = true;
                    }
                    lineNumber++;
                }
            }
            if (!textIsFound) Console.WriteLine("Text Not Found");
            return 0; //возращаю 0 а не 1 для корректности, ибо программа работает исправно
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка");
            return 1;
        }
    }
}