using System.Collections.Generic;
using System;
using System.IO;

namespace Proyecto
{
    public class BookOfWisdom: HonorAndGlory<BookOfWisdom>
    {
        public new List<string> Deaths;
        public static BookOfWisdom instance;
        public BookOfWisdom(): base("---Book Of Wisdom---")
        {

        }
        override public void AddDeath(Character dead, Character killer)
        {
            base.Deaths.Add(dead.Name+" was kill by "+killer.Name+"\n");
        }
        public override void SaveData()
        {
            string data = String.Empty;
            foreach (string line in base.Deaths)
            {
                data+=line;
            }
            string filePath = @"EncountersResults\BookOfWisdom_Enconter-"+DateTime.Now.ToString("dd_MM_yyyy-hh_mm_ss")+".txt";
            File.WriteAllText(filePath,data);
            foreach(string line in File.ReadAllLines(filePath)) //Hay que sacar esto despues
            {
                System.Console.WriteLine(line); //Hay que sacar esto despues
            }
        }
    }
}