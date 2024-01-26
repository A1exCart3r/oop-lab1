using System.IO;
using System.Runtime.ExceptionServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string firstFile = args[0];
        string secondFile = args[1];
        string readedtext;
        try
        {
            StreamReader sr = new StreamReader(firstFile);
            StreamWriter sw = new StreamWriter(secondFile);
            readedtext = sr.ReadToEnd();
            sw.Write(readedtext);
            sr.Close();
            sw.Close();
        }
        catch (Exception)
        {
            Console.WriteLine("пошел нахер ошибка");
        }
    }
}