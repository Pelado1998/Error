using System.Collections.Generic;
using System;

namespace Proyecto
{
    public class Item: AbstractItem
    {
        public Item(int attack, int magic, int defense, int heal, string name, string description): base (attack,magic,defense,heal,name,description)
        {

        }
        
        #region Default Items
            public static Item newGandalfStaff()
            {
                Item gandalfStaff = new Item(15,35,5,15,"Gandalf's Staff", "\"...he held his staff aloft, and from its tip there came a feint radiance.\" -The Fellowship of the Ring");

                AllItems.Instance.ItemList.Add(gandalfStaff);
                return gandalfStaff;
            }
            public static Item newElvenJeweler()
            {
                Item elvenJeweler = new Item(10,15,10,25,"\"Elven Jeweler", "...to the Elven-smiths they were but trifles...\" -Gandalf, The Fellowship of the Ring");
                AllItems.Instance.ItemList.Add(elvenJeweler);
                return elvenJeweler;
            } 
            public static Item newDwarvenAxe()
            {
                Item dwarvenAxe = new Item(10,15,10,25,"Dwarven Axe","\"But keep your bow ready to hand, and I will keep my axe loose in my belt.\" -Gimli, The Two Towers");

                AllItems.Instance.ItemList.Add(dwarvenAxe);
                return dwarvenAxe;
            } 
            public static Item newDragonArmor()
            {
                Item dragonArmor = new Item(10,15,10,25,"Dragon Armor","\"...but alone in the porch upon the topmost step stood Beregond, clad in the black and silver of the Guard; and he held the door against them.\" - The Return of the King");
                AllItems.Instance.ItemList.Add(dragonArmor);
                return dragonArmor;
            }
            public static Item newBrokenSword()
            {
                Item brokenSword = new Item(10,15,10,25,"Broken Sword","\"For the Sword that was Broken is the Sword of Elendil that broke beneath him when he fell.\" -Aragorn, The Fellowship of the Ring");
                AllItems.Instance.ItemList.Add(brokenSword);
                return brokenSword;
            }      
            public static Item newMirkwoodKnife()
            {
                Item mirkwoodKnife = new Item(10,15,10,25,"Mirkwood Long-knife","\"Legolas had a bow and a quiver, and at his belt a long white knife.\" - The Return of the King");
                AllItems.Instance.ItemList.Add(mirkwoodKnife);
                return mirkwoodKnife;
            }       
            public static Item newSoldierSheld()
            {
                Item soldierSheld = new Item(5,0,30,0,"Soldier Sheld","\"Just a normal Sheld\"");
                AllItems.Instance.ItemList.Add(soldierSheld);
                return soldierSheld;
            }        
            public static Item newGhostScare()
            {
                Item ghostScar = new Item(0,50,10,0,"Ghost Scare","\"Does anybody have fear to Ghosts? Cause you should...\"");
                AllItems.Instance.ItemList.Add(ghostScar);
                return ghostScar;
            }         
        #endregion
        #region Exeptional Items
            public static SpellsBook newSpellsBook()
            {
                SpellsBook spellBook = new SpellsBook(50,85,40,60,"Spells Book","The most agent book of all history");
                AllItems.Instance.ItemList.Add(spellBook);
                return spellBook;
            }
            public static DarkSword newDarkSword()
            {
                DarkSword darkSword = new DarkSword(50,85,40,60,"Dark Sword","The most agent sword of all history");
                AllItems.Instance.ItemList.Add(darkSword);
                return darkSword;
            }
            public static RodOfAsclepius newRodOfAsclepius()
            {
                RodOfAsclepius rodOfAsclepius = new RodOfAsclepius(0,0,0,0,"Dark Sword","Just a simple rod... or not?");
                AllItems.Instance.ItemList.Add(rodOfAsclepius);
                return rodOfAsclepius;
            }
        
        #endregion
        #region Composited Items
             public static AbstractItem newCoolSword()
            {
                AbstractItem coolSword = newBrokenSword().Combine(newMirkwoodKnife(),"Cool Sword", "\"This is the best sword ever made \"");
                AllItems.Instance.ItemList.Add(coolSword);
                return coolSword;
            }
            public static AbstractItem newCoolArmor()
            {
                AbstractItem coolArmor = newDragonArmor().Combine(newSoldierSheld(),"Cool Armor"," \"Prety cool armor\"");
                AllItems.Instance.ItemList.Add(coolArmor);
                return coolArmor;
            }
            public static AbstractItem newStaffOfAsclepius()
            {
                AbstractItem staffOfAsclepius = newRodOfAsclepius().Combine(newGandalfStaff(),"Staff of Asclepius", "\"This weapon can be used by anyone\"");
                AllItems.Instance.ItemList.Add(staffOfAsclepius);
                return staffOfAsclepius;
            }
        #endregion
    }
}