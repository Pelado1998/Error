using System.Collections.Generic;
using System;

namespace Proyecto
{
    public class RodOfAsclepius:AbstractItem
    {   
        public RodOfAsclepius(int attack, int magic, int defense, int heal, string name, string description) :base(attack, magic, defense, heal, name, description)
        {
        }
        override public AbstractItem Combine(AbstractItem item, string newName, string newDescription)
        {
            int attack = this.Attack +item.Attack;
            int magic = this.Magic +item.Magic;
            int defense = this.Defense +item.Defense;
            int heal = this.Heal +item.Heal;
            return new RodOfAsclepius(attack, magic,defense,heal,newName,newDescription);
        }
        override public void Equip(String characterName)
        {
            Character SearchedCharacter = Character.Empty;
            foreach (Character character in AllCharacters.Instance.CharacterList)
            {
                if (character.Name == characterName)
                {
                    SearchedCharacter = character;
                }
            }
            if (SearchedCharacter!= Character.Empty)
            {
                foreach (AbstractItem item in SearchedCharacter.Inventory)
                {
                    if (item.Name == this.Name)
                    {
                        return;
                    }
                }
                SearchedCharacter.Inventory.Add(this);
                SearchedCharacter.Attack += this.Attack;
                SearchedCharacter.Magic += this.Magic;
                SearchedCharacter.Defense += this.Defense;
            }
            else 
            {
                return;//Excepcion: no existe el caracter
            }
            
        }
    }
}