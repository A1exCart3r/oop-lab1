ArgumentParser argPar = new ArgumentParser(args);

try
{
    byte resultByte;

    if (argPar.IsValid)
    {
        if (argPar.Direction == "R")
        {
            // дописываю "% 8" чтоб получить корректное число для сдвига
            resultByte = (byte)((argPar.InputByte << argPar.NumberOfBits % 8) | (argPar.InputByte >> (8 - argPar.NumberOfBits % 8)));
            Console.WriteLine(resultByte);
        }

        else if (argPar.Direction == "L")
        {
            resultByte = (byte)((argPar.InputByte >> argPar.NumberOfBits % 8) | (argPar.InputByte << (8 - argPar.NumberOfBits % 8)));
            Console.WriteLine(resultByte);
        }
    }

    else
    {
        Console.WriteLine("Введенные данные не коректны.");
        return 1;
    }
}

catch (Exception ex)
{
    Console.WriteLine("Произошла ошибка" + ex.Message);
    return 1;
}

Console.WriteLine("Сдвиг Байта успешно выполнен.");
return 0;
