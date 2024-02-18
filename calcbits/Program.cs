if (args.Length != 1)
{
    Console.WriteLine("Не правильное количество аргументов, введите аргументы в в формате calcbits.exe <byte>");
}

try
{
    byte inputByte = Convert.ToByte(args[0]);
    int count = 0;

    while (inputByte > 0)
    {
        count += inputByte & 1;
        inputByte >>= 1;
    }
    Console.WriteLine(count);
}
catch (Exception)
{
    Console.WriteLine("Ошибка");
}
return 0;

