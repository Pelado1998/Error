using System.Collections.Generic;
using System;
using static Proyecto.Item;

namespace Proyecto
{
    public class Character
    {
        public string Name {get;set;}
        public int Life {get;set;}
        public int Attack {get;set;}
        public int Magic {get;set;}
        public int Defense {get;set;}
        public int VictoryPoints {get;set;}
        public bool MagicKnowledge {get;set;}
        public List<AbstractItem> Inventory {get;set;}
        public static Character Empty { get; internal set; }

        // public void Equip(int attack, int magic, int defense, int heal, string name, string description)
        // {
        //     Item equiped = new Item(attack,magic,defense,heal,name,description);
        //     foreach (Item item in this.Inventory)
        //     {
        //         if (item.Name == equiped.Name)
        //         {
        //             return;
        //         }
        //     }
        //     Inventory.Add(equiped);
        //     this.Attack += equiped.Attack;
        //     this.Magic += equiped.Magic;
        //     this.Defense += equiped.Defense;
        // }
        // public void Equip(Item equiped)
        // {
        //     if (equiped == Item.Empty)
        //     {
        //         return;
        //     }
        //     foreach (Item item in this.Inventory)
        //     {
        //         if (item.Name == equiped.Name )
        //         {
        //             return;
        //         }
        //     }
        //     Inventory.Add(equiped);
        //     this.Attack += equiped.Attack;
        //     this.Magic += equiped.Magic;
        //     this.Defense += equiped.Defense;
        // }

        // public Item Unequip(string name)
        // {
        //     foreach (Item removed in this.Inventory)
        //     {
        //         if(removed.Name==name)
        //         {
        //             this.Inventory.Remove(removed);
        //             this.Attack -= removed.Attack;
        //             this.Magic -= removed.Magic;
        //             this.Defense -= removed.Defense;
        //             return removed;
        //         }
        //     }
        //     return Item.Empty;  //Aca debe lanzar una excepcion
        // }
        public void Attacked(Character attacker)
        {
            int dif = attacker.Attack+attacker.Magic-this.Defense;
            if (dif>=0)
            {
                if (dif<=this.Life)
                {
                    this.Life -= dif;
                }
                else
                {
                    this.Life = 0;
                }
            }
        }
        public void Healed()
        {

            foreach (Item item in this.Inventory)
            {
                this.Life+=item.Heal;
            }
        }
        public Character(string name, int life, int attack, int magic, int defense,int victoryPoints)
        {
            this.Name = name;
            this.Life = life;  
            this.Attack = attack;
            this.Magic = magic;
            this.Defense = defense;
            this.MagicKnowledge = magic!=0;
            this.VictoryPoints = victoryPoints;
            this.Inventory = new List<AbstractItem>();
            AllCharacters.Instance.CharacterList.Add(this);
        }

        #region Default Heroes
            public static Character newWizard(string name)
            {
                Character wizzard = new Character(name,100,20,70,30,1);
                newGandalfStaff().Equip(name);
                return wizzard;
            }
            public static Character newElve(string name)
            {
                Character elve = new Character(name,120,30,40,40,1);
                newElvenJeweler().Equip(name);
                return elve;
            }
            public static Character newDwarve(string name)
            {
                Character dwarve = new Character(name,150,20,0,60,1);
                newDwarvenAxe().Equip(name);
                return dwarve; 
            }
            public static Character newSoldier(string name)
            {
                Character soldier = new Character(name,65,20,0,30,1);
                newSoldierSheld().Equip(name);
                return soldier; 
            }
        #endregion
        #region Default Villains
            public static Character newDragon(string name)
            {
                Character dragon = new Character(name,300,50,0,20,3);
                newDragonArmor().Equip(name);
                return dragon;
            }
            public static Character newDemon(string name)
            {
                Character demon = new Character(name,80,15,0,40,2);
               newBrokenSword().Equip(name);
                return demon;
            }
            public static Character newOrc(string name)
            {
                Character orc = new Character(name,20,5,0,5,1);    
                newMirkwoodKnife().Equip(name);
                return orc;
            }
            public static Character newGhost(string name)
            {
                Character ghost = new Character(name,15,0,60,100,1);
                newGhostScare().Equip(name);
                return ghost; 
            }
        #endregion
    }
}