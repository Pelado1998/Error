using System.Collections.Generic;
using System;
using System.IO;

namespace Proyecto
{
    public class Encounter
    {
        public static void Exchange(Character nameChar1, Character nameChar2, AbstractItem itemName)
        {
           itemName.Unequip(nameChar1).Equip(nameChar2); //Se debe lanzar una exepcion si no existe el item
        }
        public static void Exchange(Character nameChar1, Character nameChar2, List<AbstractItem> itemNameList)
        {
            foreach (AbstractItem item in itemNameList)
            {
                item.Unequip(nameChar1).Equip(nameChar2); //Se debe lanzar una exepcion si no existe algun item
            }
        }

        public static void Exchange(string nameChar1, string nameChar2, string itemName)
        {
            AllItems.Instance.GetItem(itemName).Unequip(nameChar1).Equip(nameChar2); //Se debe lanzar una exepcion si no existe el item
        }
        public static void Exchange(string nameChar1, string nameChar2, List<string> itemNameList)
        {
            foreach (string item in itemNameList)
            {   
                //Aca se borra el inventario del AllCharacters.Instance.CharacterList[0].Inventory
            }
        }
        public static void Battle (List<string> heroesNames, List<string> villainsNames)
        {
            //Precondicion: no pueden ser nulas las listas, tampoco se deberian de editar las listas... o si?
            List<Character> heroes = new List<Character>();
            List<Character> villains = new List<Character>();
            foreach (string heroe in heroesNames)
            {
                heroes.Add(AllCharacters.Instance.GetCharacter(heroe)); //Debe dar una exepcion en el caso de que alguno no exista en la lista
            }
            foreach (string villain in villainsNames)
            {
                villains.Add(AllCharacters.Instance.GetCharacter(villain)); //Debe dar una exepcion en el caso de que alguno no exista en la lista
            }
            while(true)
            {    
                #region Villain Attack
                    foreach (Character villain in villains)
                    {
                        heroes[villains.IndexOf(villain)%(heroes.Count)].Attacked(villain);
                        if (heroes[villains.IndexOf(villain)%(heroes.Count)].Life == 0)
                        {
                            TreeOfTheThounsandsDays.Instance.AddDeath(heroes[villains.IndexOf(villain)%(heroes.Count)],villain);
                            BookOfWisdom.Instance.AddDeath(heroes[villains.IndexOf(villain)%(heroes.Count)],villain);
                            heroes.Remove(heroes[villains.IndexOf(villain)%(heroes.Count)]);
                            
                        }
                        if (heroes.Count == 0 )
                        {
                            break;
                        }
                    }
                    if (heroes.Count == 0 )
                        {
                            HonorAndGlory<BookOfWisdom>.Instance.WarEnd(villains);
                            HonorAndGlory<TreeOfTheThounsandsDays>.Instance.WarEnd(villains);
                            HonorAndGlory<EternalStone>.Instance.WarEnd(villains);
                            break;
                        }
                #endregion
                #region Heroes Attack
                    foreach (Character heroe in heroes)
                    {
                        villains[heroes.IndexOf(heroe)%(villains.Count)].Attacked(heroe);
                        if (villains[heroes.IndexOf(heroe)%(villains.Count)].Life == 0)
                        {
                            heroe.VictoryPoints += villains[heroes.IndexOf(heroe)%(villains.Count)].VictoryPoints;
                            if (villains[heroes.IndexOf(heroe)%(villains.Count)].VictoryPoints >= 5)
                            {
                                heroe.Healed();
                            }
                            EternalStone.Instance.AddDeath(heroe,villains[villains.IndexOf(heroe)%(villains.Count)]);
                            BookOfWisdom.Instance.AddDeath(villains[villains.IndexOf(heroe)%(villains.Count)],heroe);
                            villains.Remove(villains[villains.IndexOf(heroe)%(villains.Count)]);
                            if (villains.Count == 0 )
                            {
                                break;
                            }
                        }
                    }
                    if (villains.Count == 0 )
                    {
                        HonorAndGlory<BookOfWisdom>.Instance.WarEnd(heroes);
                        HonorAndGlory<TreeOfTheThounsandsDays>.Instance.WarEnd(heroes);
                        HonorAndGlory<EternalStone>.Instance.WarEnd(heroes);
                        break;
                    }
                #endregion
            }

            #region Honor & Glory
            
                    EternalStone.Instance.SaveData();
                    BookOfWisdom.Instance.SaveData();
                    TreeOfTheThounsandsDays.Instance.SaveData();
            #endregion
        }
        public static void Battle (List<Character> heroes, List<Character> villains)
        {
            //Precondicion: no pueden ser nulas las listas, tampoco se deberian de editar las listas... o si?
            while(true)
            {    
                #region Villain Attack
                    foreach (Character villain in villains)
                    {
                        heroes[villains.IndexOf(villain)%(heroes.Count)].Attacked(villain);
                        if (heroes[villains.IndexOf(villain)%(heroes.Count)].Life == 0)
                        {
                            TreeOfTheThounsandsDays.Instance.AddDeath(heroes[villains.IndexOf(villain)%(heroes.Count)],villain);
                            BookOfWisdom.Instance.AddDeath(heroes[villains.IndexOf(villain)%(heroes.Count)],villain);
                            heroes.Remove(heroes[villains.IndexOf(villain)%(heroes.Count)]);
                            
                        }
                        if (heroes.Count == 0 )
                        {
                            break;
                        }
                    }
                    if (heroes.Count == 0 )
                        {
                            HonorAndGlory<BookOfWisdom>.Instance.WarEnd(villains);
                            HonorAndGlory<TreeOfTheThounsandsDays>.Instance.WarEnd(villains);
                            HonorAndGlory<EternalStone>.Instance.WarEnd(villains);
                            break;
                        }
                #endregion
                #region Heroes Attack
                    foreach (Character heroe in heroes)
                    {
                        villains[heroes.IndexOf(heroe)%(villains.Count)].Attacked(heroe);
                        if (villains[heroes.IndexOf(heroe)%(villains.Count)].Life == 0)
                        {
                            heroe.VictoryPoints += villains[heroes.IndexOf(heroe)%(villains.Count)].VictoryPoints;
                            if (villains[heroes.IndexOf(heroe)%(villains.Count)].VictoryPoints >= 5)
                            {
                                heroe.Healed();
                            }
                            EternalStone.Instance.AddDeath(heroe,villains[villains.IndexOf(heroe)%(villains.Count)]);
                            BookOfWisdom.Instance.AddDeath(villains[villains.IndexOf(heroe)%(villains.Count)],heroe);
                            villains.Remove(villains[villains.IndexOf(heroe)%(villains.Count)]);
                            if (villains.Count == 0 )
                            {
                                break;
                            }
                        }
                    }
                    if (villains.Count == 0 )
                    {
                        HonorAndGlory<BookOfWisdom>.Instance.WarEnd(heroes);
                        HonorAndGlory<TreeOfTheThounsandsDays>.Instance.WarEnd(heroes);
                        HonorAndGlory<EternalStone>.Instance.WarEnd(heroes);
                        break;
                    }
                #endregion
            }

            #region Honor & Glory
                    EternalStone.Instance.SaveData();
                    BookOfWisdom.Instance.SaveData();
                    TreeOfTheThounsandsDays.Instance.SaveData();
            #endregion
        }

        public static void LoadEncounter()
        {
            
            string filePath = @"LoadableEncounters";
            DirectoryInfo currentDir = new DirectoryInfo(filePath);
            foreach (FileInfo encounter in currentDir.GetFiles())
            {
                string [] file = File.ReadAllLines(encounter.FullName);
                if (file[0]=="Exchange")
                {
                    Character char1 = AllCharacters.Instance.GetCharacter(file[1]);
                    Character char2 = AllCharacters.Instance.GetCharacter(file[2]);
                    List<string> items = new List<string>();
                    if (char1 != Character.Empty && char2 != Character.Empty)
                    {
                        
                        foreach (string lines in file[3..file.Length])
                        {
                            AbstractItem item = AllItems.Instance.GetItem(lines);
                            if (item != AbstractItem.Empty)
                            {
                                items.Add(item.Name.TrimEnd());
                            }
                        }
                    }
                    else
                    {
                        return; //Deberia dar una excepcion
                    }
                    Encounter.Exchange(char1.Name,char2.Name,items);
                }
                else if (file[0]=="BattleH\n")
                {
                    Character char1 = AllCharacters.Instance.GetCharacter(file[1]);
                    Character char2 = AllCharacters.Instance.GetCharacter(file[2]);
                    List<string> heroes = new List<string>();
                    List<string> villains = new List<string>();
                    if (char1 != Character.Empty && char2 != Character.Empty)
                    {
                        int idx = -1;
                        foreach (string lines in file[3..file.Length])
                        {
                            idx +=1;
                            AbstractItem item = AllItems.Instance.GetItem(lines);
                            if (item != AbstractItem.Empty)
                            {
                                heroes.Add(item.Name.TrimEnd());
                            }
                            else if (lines == "BattleV\n")
                            {
                                break;
                            }
                        }
                        foreach (string lines in file[idx..file.Length])
                        {
                            AbstractItem item = AllItems.Instance.GetItem(lines);
                            if (item != AbstractItem.Empty)
                            {
                                villains.Add(item.Name.TrimEnd());
                            }
                        }
                    }
                    Encounter.Battle(heroes,villains);
                }
            }
        }
    }
}