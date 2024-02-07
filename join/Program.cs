class Program
{
    static int Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Неверное количество аргументов, введите аргументы в формате  join.exe <input file1> ... <input file N> <output file>");
            return 1;
        }

        string outputFile = args[args.Length - 1]; 
        
        try
        {
            using (FileStream output = new FileStream(outputFile, FileMode.Create))
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    string inputFile = args[i];
                    using (FileStream input = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;

                        while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
            return 0;
        }
        
        catch (Exception)
        {
            Console.WriteLine("Ошибка");
            return 1;
        }
    }
}