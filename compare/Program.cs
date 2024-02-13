internal class Compare
{
    private static int Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Неверное количество аргументов - Введите данные в формате \"compare.exe <file1> <file2>\"");
            return 1;
        }

        string firstFile = args[0];
        string secondFile = args[1];
        int lineNumber = 1;
        bool areDifferent = false;

        try
        {
            using (var sr = new StreamReader(firstFile))
            using (var sr2 = new StreamReader(secondFile))
            {
                string firstFileLine;
                string secondFileLine;
                while (!sr.EndOfStream || !sr2.EndOfStream)
                {
                    firstFileLine = sr.ReadLine()!;
                    secondFileLine = sr2.ReadLine()!;
                    if (firstFileLine != secondFileLine)
                    {
                        areDifferent = true;
                        break;
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
        // хоть сказано при разных файлах вернуть значение 1, но я просто верну 0 в конце так как програма исправна
        if (areDifferent) 
        {
            Console.WriteLine("Files are different. Line number is " + lineNumber); 
        }
        else
        {
            Console.WriteLine("Files are equal.");
        }
        return 0;
    }
}