using System.Collections.Generic;
using System;
using System.IO;

namespace Proyecto
{
    public class EternalStone: HonorAndGlory<EternalStone>
    {
        public new List<string> Deaths;
        public static EternalStone instance;
        public EternalStone(): base("---Eternal Stone---")
        {

        }
        override public void AddDeath(Character dead, Character killer)
        {
            if ((base.Deaths.Count-1)%5==0 && (base.Deaths.Count-1)!=0)
            {
                base.Deaths.Add("|\n");
            }
            else
            {
                base.Deaths.Add("|");
            }
            
        }
        public override void SaveData()
        {
            string data = String.Empty;
            foreach (string line in base.Deaths)
            {
                data+=line;
            }
            string filePath = @"EncountersResults\EternalStone_Enconter-"+DateTime.Now.ToString("dd_MM_yyyy-hh_mm_ss")+".txt";
            File.WriteAllText(filePath,data);
            foreach(string line in File.ReadAllLines(filePath)) //Hay que sacar esto despues
            {
                System.Console.WriteLine(line); //Hay que sacar esto despues
            }
        }
    }
}