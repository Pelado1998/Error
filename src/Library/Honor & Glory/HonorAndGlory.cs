using System.Collections.Generic;
using System;

namespace Proyecto
{
    abstract public class HonorAndGlory<T>:ISaver where T: new()
    {
        public List<string> Deaths;
        private static T instance;
        public HonorAndGlory(string header)
        {
            this.Deaths = new List<string>(){header+"\n"};
        }
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
        abstract public void AddDeath(Character dead, Character killer);
        virtual public void WarEnd(List<Character> survivors)
        {
            string survivorList = String.Empty;
            foreach (Character character in survivors)
            {
                if (survivors.IndexOf(character)!= (survivors.Count-1))
                {
                    survivorList += character.Name+", ";
                }
                else 
                {
                    survivorList += character.Name+".";
                }
            }
            this.Deaths.Add("\nSurvivor Winers: "+ survivorList);
        }
        abstract public void SaveData();
    }
}