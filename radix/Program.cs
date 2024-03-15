try
{
    Arguments arguments = ArgumentParser.Parser(args);
    int intNumber = ConvertStringNumberToInt(arguments.Value, arguments.SourceRadix);
    string res = ConvertNumberToDestRadix(intNumber, arguments.DestinationRadix);

    Console.WriteLine(res);
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

int ConvertStringNumberToInt(string inputNumber, int sourceRadix)
{
    if (sourceRadix < 2 || sourceRadix > 36)
    {
        throw new ArgumentException("Основание СС должно быть в диапазоне от 2 до 36");
    }

    string symbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    bool isNegative = inputNumber[0] == '-';
    int intNumber = 0;
    int grade = 0;
    int startIndex = isNegative ? 1 : 0;

    for (int i = inputNumber.Length - 1; i >= startIndex; i--)
    {
        char symbol = inputNumber[i];

        if (!IsValidSymbol(symbol, symbols.Substring(0, sourceRadix)))
        {
            throw new ArgumentException("Некорректный символ в числе.");
        }

        int num = symbols.IndexOf(symbol);

        if (WillGradeOverflow(grade, sourceRadix) || WillAdditionOverflow(intNumber, num * (int)Math.Pow(sourceRadix, grade)))
        {
            throw new OverflowException("Произошло переполнение при переводеч числа");
        }
        
        intNumber += num * (int)Math.Pow(sourceRadix, grade);
        grade++;
    }

    return isNegative ? -intNumber : intNumber;
}

bool WillGradeOverflow(int grade, int sourceRadix)
{
    return Math.Pow(sourceRadix, grade) > int.MaxValue;
}

bool WillAdditionOverflow(int a, int b)
{
    return b > int.MaxValue - a;
}

bool IsValidSymbol(char symbol, string symbols)
{
    return symbols.Contains(symbol);
}

static string ConvertNumberToDestRadix(int intNumber, int destRadix )
{
    if (destRadix < 2 || destRadix > 36)
    {
        throw new ArgumentException("Основание СС должно быть в диапазоне от 2 до 36");
    }

    string symbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string res = string.Empty;
    bool isNegative = intNumber < 0;

    intNumber = Math.Abs(intNumber);

    while (intNumber > 0)
    {
        res = symbols[intNumber % destRadix] + res;
        intNumber /= destRadix;
    }

    return isNegative ? "-" + res : res;
}