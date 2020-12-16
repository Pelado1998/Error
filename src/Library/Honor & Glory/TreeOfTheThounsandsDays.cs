using System.Collections.Generic;
using System;
using System.IO;

namespace Proyecto
{
    internal class TreeOfTheThounsandsDays: HonorAndGlory<TreeOfTheThounsandsDays>
    {
        public new List<string> Deaths;
        public static TreeOfTheThounsandsDays instance;
        public TreeOfTheThounsandsDays(): base("---Tree of the Thousands Days---")
        {

        }
        override public void AddDeath(Character dead, Character killer)
        {
            base.Deaths.Add("We have killed " +dead.Name+"\n");
        }
        public override void SaveData()
        {
            string data = String.Empty;
            foreach (string line in base.Deaths)
            {
                data+=line;                
            }
            string filePath = @"EncountersResults\TreeOfTheThounsandsDays_Enconter-"+DateTime.Now.ToString("dd_MM_yyyy-hh_mm_ss")+".txt";
            File.WriteAllText(filePath,data);
            foreach(string line in File.ReadAllLines(filePath)) //Hay que sacar esto despues
            {
                System.Console.WriteLine(line); //Hay que sacar esto despues
            }
        }
    }
}