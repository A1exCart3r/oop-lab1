class ArgumentParser
{
        public byte InputByte;
        public int NumberOfBits;
        public string? Direction;
        public bool IsValid;

        public ArgumentParser(string[] args)
        {
            if (IsNumOfArgumentsRight(args) & IsInputByteRight(args) & IsNumOfBitsRight(args) & IsDirectionRight(args))
            {
                IsValid = true;
                InputByte = byte.Parse(args[0]);
                NumberOfBits = int.Parse(args[1]);
                Direction = args[2].ToUpper();
            }
            else
            {
                IsValid = false;
            }
        }

    static bool IsDirectionRight(string[] args)
    {
        if (args[2].ToUpper() == "L" || args[2].ToUpper() == "R")
        {
            return true;
        }
        else
        {
            Console.WriteLine("Введите направление в виде <L / R>");
            return false;
        }
    }

    static bool IsNumOfArgumentsRight(string[] args)
    {
        if (args.Length == 3)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Использование: rotatebyte.exe <byte> <number of bits> <L / R>");
            return false;
        }
    }

    static bool IsNumOfBitsRight(string[] args)
    {
        if (int.TryParse(args[1], out int numberOfBits) && (numberOfBits >= 0) && (numberOfBits <= 2147483647))  
        {
            return true;
        }
        else
        {
            Console.WriteLine("Для коректности работы программы введите число битов в диапазоне 0-2147483647");
            return false;
        }
    }

    static bool IsInputByteRight(string[] args)
    {
        if (byte.TryParse(args[0], out byte inputByte))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Введите для байта значение в диапазоне 0-255");
            return false;
        }
    }
}