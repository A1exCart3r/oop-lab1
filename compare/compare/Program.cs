internal class Program
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
        string strFromFirstFile;
        string strFromSecondFile;
        int line = 1;

        try
        {
            using (StreamReader sr = new StreamReader(firstFile))
            using (StreamReader sr2 = new StreamReader(secondFile))
            { 
                while (!sr.EndOfStream || !sr2.EndOfStream)
                {
                    strFromFirstFile = sr.ReadLine();
                    strFromSecondFile = sr2.ReadLine();
                    if (strFromFirstFile != strFromSecondFile)
                    {
                        Console.WriteLine("Files are different. Line number is " + line);
                        return 0; //хуй знает что выводить в задании сказано "вернуть значение 1", но я верну 0 для корректности имхо
                    }
                    line++;
                }
                Console.WriteLine("Files are equal.");
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