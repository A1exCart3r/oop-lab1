internal class Program
{
    private static int Main(string[] args)
    {
        if (args.Length != 4) 
        {
            Console.WriteLine("Неверное количество аргументов, введите аргументы в формате:");
            Console.WriteLine("replace.exe <input file> <output file> <search string> <replace string>");
            return 1;
        }

        try
        {
            string inputFile = args[0];
            string outputFile = args[1];

            using (StreamReader sr = new StreamReader(inputFile))
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                string lineFromFile;
                string searchText = args[2];
                string replaceText = args[3];
                if (searchText.Length != 0) 
                {
                    while (!sr.EndOfStream)
                    {
                       lineFromFile = sr.ReadLine()!;
                       if (lineFromFile.Contains(searchText)) //ищем подстроку и заменяем, если не нашли, то оставляем без изменений
                       {
                           lineFromFile = lineFromFile.Replace(searchText, replaceText);
                       }
                       sw.WriteLine(lineFromFile);
                    }
                }
                else //длина искомой строки равна нулю значит просто копируем файл без замены подстрок
                {
                    while (!sr.EndOfStream) 
                    {
                        lineFromFile = sr.ReadLine()!;
                        sw.WriteLine(lineFromFile);
                    }
                }
            }
        }

        catch (Exception)
        {
            Console.WriteLine("Ошибка");
            return 1;
        }
        return 0;
    }
}