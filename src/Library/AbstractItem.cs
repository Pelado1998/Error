using System.Collections.Generic;
using System;

namespace Proyecto
{
    abstract public class AbstractItem
    {
        public int Attack {get;set;}
        public int Magic {get;set;}
        public int Defense {get;set;}
        public int Heal {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public static AbstractItem Empty { get; internal set; }

        public AbstractItem(int attack, int magic, int defense, int heal, string name, string description)
        {
            this.Attack = attack;
            this.Magic = magic;
            this.Defense = defense;
            this.Heal = heal;
            this.Name = name;
            this.Description = description;
            AllItems.Instance.ItemList.Add(this);
        }
        virtual public AbstractItem Combine(AbstractItem item, string newName, string newDescription)
        {
            int attack = this.Attack +item.Attack;
            int magic = this.Magic +item.Magic;
            int defense = this.Defense +item.Defense;
            int heal = this.Heal +item.Heal;
            return new Item(attack, magic,defense,heal,newName,newDescription);
        }
        virtual public void Equip(Character SearchedCharacter)
        {
            if (SearchedCharacter!= Character.Empty)
            {
                foreach (AbstractItem item in SearchedCharacter.Inventory)
                {
                    if (item.Name == this.Name)
                    {
                        return;
                    }
                }
                if(SearchedCharacter.Magic==0 || SearchedCharacter.MagicKnowledge)
                {
                    SearchedCharacter.Inventory.Add(this);
                    SearchedCharacter.Attack += this.Attack;
                    SearchedCharacter.Magic += this.Magic;
                    SearchedCharacter.Defense += this.Defense;
                }
            }
            else 
            {
                return;//Excepcion: no existe el caracter
            }
        }
        virtual public void Equip(String characterName)
        {
            int idx = -1;
            Character SearchedCharacter = Character.Empty;
            foreach (Character character in AllCharacters.Instance.CharacterList)
            {
                idx+=1;
                if (character.Name == characterName)
                {
                    break;
                }
            }
            if (AllCharacters.Instance.CharacterList[idx]!= Character.Empty)
            {
                foreach (AbstractItem item in AllCharacters.Instance.CharacterList[idx].Inventory)
                {
                    if (item.Name == this.Name)
                    {
                        return; //Deberia lanzar una excepcion
                    }
                }
                if(AllCharacters.Instance.CharacterList[idx].Magic==0 || AllCharacters.Instance.CharacterList[idx].MagicKnowledge)
                {
                    AllCharacters.Instance.CharacterList[idx].Inventory.Add(this);
                    AllCharacters.Instance.CharacterList[idx].Attack += this.Attack;
                    AllCharacters.Instance.CharacterList[idx].Magic += this.Magic;
                    AllCharacters.Instance.CharacterList[idx].Defense += this.Defense;
                }
            }
            else 
            {
                return;//Excepcion: no existe el caracter
            }
        }

        virtual public AbstractItem Unequip(Character SearchedCharacter)
        {
            if (SearchedCharacter!= Character.Empty)
            {
                foreach (AbstractItem removed in SearchedCharacter.Inventory)
                {
                    if(this.Name==removed.Name)
                    {
                        SearchedCharacter.Inventory.Remove(this);
                        SearchedCharacter.Attack -= this.Attack;
                        SearchedCharacter.Magic -= this.Magic;
                        SearchedCharacter.Defense -= this.Defense;
                        return this;
                    }
                }
                return Item.Empty;  //Aca debe lanzar una excepcion
            }
            else
            {
                return AbstractItem.Empty;//Excepcion: no existe el caracter
            }
        }

        virtual public AbstractItem Unequip(String characterName)
        {
            Character SearchedCharacter = Character.Empty;
            int idx = -1;
            foreach (Character character in AllCharacters.Instance.CharacterList)
            {
                idx+=1;
                if (character.Name == characterName)
                {
                    break;
                }
            }
            if (AllCharacters.Instance.CharacterList[idx]!= Character.Empty)
            {
                foreach (AbstractItem removed in AllCharacters.Instance.CharacterList[idx].Inventory)
                {
                    if(this.Name==removed.Name)
                    {
                        AllCharacters.Instance.CharacterList[idx].Inventory.Remove(this);
                        AllCharacters.Instance.CharacterList[idx].Attack -= this.Attack;
                        AllCharacters.Instance.CharacterList[idx].Magic -= this.Magic;
                        AllCharacters.Instance.CharacterList[idx].Defense -= this.Defense;
                        return this;
                    }
                }
                return AbstractItem.Empty;  //Aca debe lanzar una excepcion
            }
            else
            {
                return AbstractItem.Empty;//Excepcion: no existe el caracter
            }
        }
    }
}