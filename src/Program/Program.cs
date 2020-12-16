using System.Collections.Generic;

namespace Proyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            Character champ = new Character("champ1",100,15,10,3,30);
            System.Console.WriteLine(champ.Attack);
            System.Console.WriteLine(champ.Defense);
            System.Console.WriteLine(champ.Inventory);
            System.Console.WriteLine(champ.Life);
            System.Console.WriteLine(champ.Magic);
            System.Console.WriteLine(champ.VictoryPoints);
            
            Character champ2 = new Character("champ2",100,15,10,20,30);
            System.Console.WriteLine(champ.Attack);
            System.Console.WriteLine(champ.Defense);
            System.Console.WriteLine(champ.Inventory);
            System.Console.WriteLine(champ.Life);
            System.Console.WriteLine(champ.Magic);
            System.Console.WriteLine(champ.VictoryPoints);
            champ.Attacked(champ2);
            System.Console.WriteLine(champ.Life);

            Item item = new Item(10,10,10,15,"item1","es el item1");
            item.Equip(champ);
            champ.Healed();
            System.Console.WriteLine(champ.Life);
            item.Unequip(champ);
            System.Console.WriteLine(champ.Inventory.Count);
            //champ.Unequip("item1");
            System.Console.WriteLine(champ.Inventory.Count);

            AbstractItem item2 = new Item(10,10,10,15,"item2","es el item2");
            AbstractItem item3 = item2.Combine(item,"Item3","Este es el item3");
            System.Console.WriteLine(item3.Attack);
            System.Console.WriteLine(champ2.Inventory.Count);
            item3.Equip(champ);
            Encounter.Exchange(champ,champ2,item3);
            System.Console.WriteLine(champ2.Inventory.Count);
            System.Console.WriteLine(champ.Inventory.Count);

            List<Character> villants = new List<Character>(){champ,champ2};
            List<Character> heroes = new List<Character>(){champ2,champ};
            
            Encounter.Battle(heroes,villants);
            System.Console.WriteLine();

            Character gandalf = Character.newWizard("Gandalf");
            Character orcFather = Character.newOrc("Orc Father");
            Character legolas = Character.newElve("Legolas");
            Character dopey = Character.newDwarve("Dopey");
            Character godDragon = Character.newDragon("God Dragon");
            Character lucifer = Character.newDemon("Sir. Lucifer");

            Character characterTest = Character.newOrc("OrcTest");
            Item.newDarkSword();
            Item.newSpellsBook().Equip(characterTest);
            (Item.newRodOfAsclepius().Combine(Item.newSpellsBook(),"Nuevo Idem","Descripcion")).Equip(characterTest);
            
            item.Equip(champ);
            item.Unequip(champ2);
            Encounter.LoadEncounter();
            System.Console.WriteLine("llego");


        }
    } 


}