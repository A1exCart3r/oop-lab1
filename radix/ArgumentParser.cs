static class ArgumentParser
{
    public static Arguments Parser(string[] args)
    {
        if (args.Length != 3) 
        {
            throw new ArgumentException("Использование: radix.exe <source notation> <destination notation> <value>");
        }

        if (!int.TryParse(args[0], out int srcRadix) || 
            !int.TryParse(args[1], out int destRadix))
        {
            throw new ArgumentException("Неверный тип данных для системы счисления");
        }

        return new Arguments
        {
            DestinationRadix = destRadix,
            SourceRadix = srcRadix,
            Value = args[2].ToUpper()
        };
    }
}

public struct Arguments
{
    public int SourceRadix;
    public int DestinationRadix;
    public string Value;
}
