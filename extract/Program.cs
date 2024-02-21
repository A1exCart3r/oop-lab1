if (args.Length < 4)
{
    Console.WriteLine("Введите данные в формате: extract.exe <input file> <output file> <start position> <fragment size>");
    return 1;
}

try
{
    string inputFile = args[0];
    string outputFile = args[1];

    if (!File.Exists(inputFile))
    {
        Console.WriteLine("Входной файл не существует");
        return 1;
    }

    using (FileStream input = File.OpenRead(inputFile))
    using (FileStream output = File.Create(outputFile))
    {
        long startPosition = Convert.ToInt64(args[2]);
        long fragmentSize = Convert.ToInt64(args[3]);

        if (startPosition >= input.Length || startPosition < 0)
        {
            Console.WriteLine("Стартовая позиция за пределами файла.");
            return 1;
        }

        if(fragmentSize < 0)
        {
            Console.WriteLine("Размер фрагмента не может быть отрицательным.");
            return 1;
        }

        input.Seek(startPosition, SeekOrigin.Begin);

        byte[] buffer = new byte[4096];
        long bytesLeft = fragmentSize;
        int bytesRead;

        //проверяем оставшиеся байты, потом считываем, и проверяем c помощью Math.Min чтобы не считать лишнего, потом минусуем кол-во прочитанных
        while (bytesLeft > 0 && (bytesRead = input.Read(buffer, 0, (int)Math.Min(buffer.Length, bytesLeft))) > 0)
        {
            output.Write(buffer, 0, bytesRead);
            bytesLeft -= bytesRead;
        }
    }
}
catch (Exception)
{
    Console.WriteLine("Ошибка");
    return 1;
}
Console.WriteLine("Программа успешно выполнена"); //лол неужели додумался сообщать об этом
return 0;