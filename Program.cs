// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("STAFF");
            Console.WriteLine("To add data, press 1. To display data, press 2. To quit, press any key");
            string key = Console.ReadLine();
            if (key == "1") AddData();
            if (key == "2") ReadData();
            else Console.WriteLine();
            static void AddData () {
            int lastID = 1;
            string curFile = @"D:\Downloads\6.1 Исходные материалы\Theme_06\Homework\Skillbox_HomeWork_12.07.23\db.csv";
            if (File.Exists(curFile) == true) {
            using (StreamReader db = new StreamReader("db.csv", Encoding.Unicode))
            {
                string checkID;
                while ((checkID = db.ReadLine()) != null)
                {
                    string[] data = checkID.Split('#');
                    lastID = Convert.ToInt32(data[0])+1;
                }
                }
            }
            int id = lastID;
            using (StreamWriter sw = new StreamWriter("db.csv", true, Encoding.Unicode))
            {
                char key = 'y';
                do
                {   
                    string note = string.Empty;
                    note += $"{Convert.ToString(id)}#";
                    string date = DateTime.Now.ToShortDateString();
                    note += $"{date}  ";
                    string now = DateTime.Now.ToShortTimeString();
                    note += $"{now}#";
                    Console.Write("\nInput Name Middlename Surname: ");
                    note += $"{Console.ReadLine()}#";
                    Console.Write("Input Height: ");
                    note += $"{Console.ReadLine()}#";
                    Console.Write("Input Weight: ");
                    note += $"{Console.ReadLine()}#";
                    Console.Write("Input Date of birth(dd.mm.yyyy): ");
                    note += $"{Console.ReadLine()}#";
                    Console.Write("Input Place of birth: ");
                    note += $"{Console.ReadLine()}\t";
                    sw.WriteLine(note);
                    Console.Write("Continue? Press n/y"); key = Console.ReadKey(true).KeyChar;
                    Console.WriteLine();
                    id ++;
                } while (char.ToLower(key) == 'y');
            }
            }
            static void ReadData () {
            using (StreamReader sr = new StreamReader("db.csv", Encoding.Unicode))
            {
                string line;
                Console.WriteLine($" ID  Record date & time        Name Middlename Surname   Height   Weight   Date of birth     Place of birth");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],3}  {data[1],18}  {data[2],29} {data[3],8}  {data[4],7}  {data[5],14} {data[6],19}");
                }
            }
            }
        }
    }
}
