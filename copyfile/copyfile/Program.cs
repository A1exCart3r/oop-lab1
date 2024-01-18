using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
		try
		{
            if (!File.Exists(args[1]))
            {
                Console.WriteLine("Второго файла не существует, будет создан новый файл с этим именем.");
            }
            File.Copy(args[0], args[1], true);
        }
		catch (Exception)
		{
            Console.WriteLine("Ошибка, убедитесь в правильности введеных данных.");
            throw;
		}
    }
}