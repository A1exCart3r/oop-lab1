internal class FindText
{
    private static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Неверное количество аргументов - Введите аргументы в формате findtext.exe <file name> <text to search>");
            return 1;
        }

        string file = args[0];
        string searchText = args[1];
        bool textIsFound = false;

        if (searchText == "") 
        {
            Console.WriteLine("Вы ничего не ввели для поиска");
            return 1;
        }

        try
        {
            string lineFromFile;
            int lineNumber = 1;

            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    lineFromFile = sr.ReadLine()!;
                    if (lineFromFile.Contains(searchText))
                    {
                        Console.WriteLine(lineNumber);
                        textIsFound = true;
                    }
                    lineNumber++;
                }
            }
        }

        catch (Exception)
        {
            Console.WriteLine("Ошибка");
            return 1;
        }

        if (!textIsFound) 
        {
            Console.WriteLine("Text Not Found");
        }
        return 0; //возращаю 0 а не 1 для корректности, ибо программа работает исправно
    }
}