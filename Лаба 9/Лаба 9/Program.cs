using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace Лаба_9
{
    class Program
    {
        static void Main(string[] args)
        {
            //  1 содержится ли в сообщении заданное слово

            //string s = "abfgdc bcgfdgd ads ajgfdsdf sagfdgd";
            //string s1 = "ads";
            //Console.WriteLine(Regex.IsMatch(s, @"\b" + s1 + @"\b", RegexOptions.IgnoreCase));

            // 2 Выведите все слова заданной длины

            //string s = "abbbc bgcd ads ajsdf sd";
            //int n;
            //int.TryParse(Console.ReadLine(), out n);
            //MatchCollection match = Regex.Matches(s, @"\b\w{" + n + @"}\b");
            //foreach (Match m in match)
            //{
            //    Console.WriteLine(m);
            //}

            // 3 Удалите из сообщения все однобуквенные слова

            //string s = "abdfc x xa dsssa xdsfdf b bcd f ahhds d g  ajfhfsdf sahtffhd s d q w";
            //Console.WriteLine(Regex.Replace(s, @"\b\w{1}\b", ""));

            // 4 Удалите из сообщения только те русские слова, которые начинаются на гласную букву

            //string s = "Абв Обг гро ртк лет оыыыдв";
            //Console.WriteLine(Regex.Replace(s, @"\b[аиеёоуыэюя][а-я]+\b", "", RegexOptions.IgnoreCase));

            // 5 Заменить все английские слова на многоточие

            //string s = "Абв asd SDUIhgD афыв фыовлц fdff ааыя zqsffw";
            //Console.WriteLine(Regex.Replace(s, @"\b[a-z]+\b", "...", RegexOptions.IgnoreCase));

            // 6 Найти сумму всех имеющихся в тексте чисел (целых и вещественных)

            //string s = " 100.3  ";
            //double sum = 0;
            //MatchCollection match = Regex.Matches(s, @"\b(\d+\.\d+)\b");
            //foreach (Match m in match)
            //{
            //   sum += double.Parse(m.Value);
            //}
            //String res = Regex.Replace(s, @"\b(\d+\.\d+)\b", "");
            //match = Regex.Matches(res, @"\b\d+.{0}\b");
            //foreach (Match m in match)
            //{
            //    sum += int.Parse(m.Value);
            //}
            //Console.WriteLine(sum);

            // 7 В сообщении могут встречаться номера телефонов, записанные в формате xx-xx-xx, xxx-xxx или xxx-xx-xx. Вывести все номера телефонов, которые содержатся в сообщении

            //string s = "My phone number is 12-12-12, but you can use 123-123 or 124-02-22 instead";
            //MatchCollection match = Regex.Matches(s, @"(\d{2}-\d{2}-\d{2})|(\d{3}-\d{3})|(\d{2,3}-\d{2}-\d{2})");
            //foreach (Match m in match)
            //{
            //    Console.WriteLine(m);
            //}

            // 8 В сообщении может содержаться дата в формате дд.мм.гггг.

            //string s = "22.12.2002, 20.11.1999, 1.1.1923, 1.1.1888,31.11.1911, 23.12.2024";
            //MatchCollection matches = Regex.Matches(s, @"([1-2][0-9]|[1-9]|[3][0-1])\.(1[0-2]|[1-9])\.(19[0-9]{2}|200[0-9]|201[0-2])");
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m);
            //}

            // 9 Выведите на экран все адреса web-сайтов, содержащиеся в сообщении

            //string s = "mail@asdsad.com asdads@asd asda@ sadsasd asdas asdmams@amil.ow asdasd@mas.";
            //MatchCollection matches = Regex.Matches(s, @"\b\w+@\w+\.\w+\b");
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m);
            //}

            // 10 В сообщении может содержаться время в формате чч:мм:сс. 

            //string s = "00:00:00 24:60:60 7:07:07 24:59:59 25:60:50 23:61:00 23:00:61";
            //MatchCollection matches = Regex.Matches(s, @"\b([0-1][0-9]|2[0-4]):([0-5][0-9]|60):([0-5][0-9]|60)\b");
            //foreach (Match m in matches)
            //{
            //    Console.WriteLine(m);
            //}


            // Задача 2


            int n = 1; // lines in page
            string filename = "txt.txt";
            StreamReader reader = new StreamReader(filename);
            string text = reader.ReadToEnd();
            reader.Dispose();
            MatchCollection Matches = Regex.Matches(text, @"(\b\w+(-\w+)*\b|(\.|\?|\!))");
            List<ConcordanceWord> concordance = new List<ConcordanceWord>();
            int ln = 1; //line number
            foreach (Match m in Matches)
            {
                if (m.Value == "." || m.Value == "?" || m.Value == "!")
                    ln++;
                else
                {
                    string S = m.Value.ToLower();
                    int index = concordance.FindIndex(x => x.Content == S);
                    if (index == -1)
                    {
                        concordance.Add(new ConcordanceWord(S, new List<int> { ln / n }, 1));
                    }
                    else
                    {
                        concordance[index].AddEntrencePoint(ln / n);
                    }
                }
            }
            concordance.Sort((x, y) => x.Content.CompareTo(y.Content));
            char b = 'а';
            Console.WriteLine(b.ToString().ToUpper());
            foreach (ConcordanceWord el in concordance)
            {
                if (!el.Content.StartsWith(b.ToString())) { b = el.Content[0]; Console.WriteLine(b.ToString().ToUpper()); }
                Console.WriteLine(el);
            }

        }
    }
}
