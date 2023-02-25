using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

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

            //Выбираем весь текст, кроме пунктуаци
            List<string> noPunctuationText = new string(sentence.ToList().Where(c => !char.IsPunctuation(c)).ToArray()).Split(' ').ToList();

            //Сформируем новую коллекцию List
            var words = noPunctuationText.Where(x => !string.IsNullOrEmpty(x))
                .GroupBy(x => x)
                .Select(s => new { Word = s.Key, Count = s.Count() })
                .OrderByDescending(s => s.Count).ToList().Take(10);

            //Смотрим результат
            foreach (var item in words)
            {
                Console.WriteLine($"Слово \"{item.Word}\" в тексте повторяется {item.Count} раз.");
            }
            Console.ReadKey();
            
        }
    }
}