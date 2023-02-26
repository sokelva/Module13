using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CountWords
{
    class Program
    {
        static void Main(string[] args)
        {

            // Укажем путь к текстовому файлу из задания "Задание 13.6.2" 
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Text2.txt";

            // Открываем файл и читаем из него весь текст.
            string sentence = string.Empty;

            // Создаем объект класса FileInfo.
            var fileInfo = new FileInfo(path);
            using (StreamReader sr = fileInfo.OpenText())
            {
                sentence = sr.ReadToEnd().Replace("\n", "");
            }

            //Объявим коллекции список и связанный список
            List<string> listText = new List<string>();
            LinkedList<string> linkText = new LinkedList<string>();//string(sentence.ToList().Where(c => !char.IsPunctuation(c)).ToArray()).Split(' ').ToList();


            // Запустим таймер для listText
            var listTextWatch = Stopwatch.StartNew();
            // Выполним вставку
            listText.Add(sentence);
            // Выведем время вставки
            Console.WriteLine($"Вставка в список: {listTextWatch.Elapsed.TotalMilliseconds}  мс");


            // Запустим таймер для linkText
            var linkTextWatch = Stopwatch.StartNew();
            // Выполним вставку
            linkText.AddLast(sentence);
            // Выведем время вставки
            Console.WriteLine($"Вставка в связанный список LinkedList<T>: {linkTextWatch.Elapsed.TotalMilliseconds}  мс");

            //Смотрим результат
            Console.ReadKey();
        }
    }
}