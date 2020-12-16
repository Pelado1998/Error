using System.Collections.Generic;
using System;

namespace Proyecto
{
    public class DarkSword:AbstractItem, IPowerUpable<ElementalGem>
    {   private List<ElementalGem> ElementalGems;
        public DarkSword(int attack, int magic, int defense, int heal, string name, string description) :base(attack, magic, defense, heal, name, description)
        {
            ElementalGems = new List<ElementalGem>(){};
        }
        public void addPowerUp(ElementalGem elementalGem)
        {
            if (!this.ElementalGems.Contains(elementalGem))
            {
                this.ElementalGems.Add(elementalGem);
                this.Attack += elementalGem.Attack;
                this.Defense += elementalGem.Defense;
                this.Heal += elementalGem.Heal;
            }
            else
            {
                //Deberia de tirar una exepcion
            }
        }
        public void removePowerUp(ElementalGem elementalGem)
        {
            if (this.ElementalGems.Contains(elementalGem))
            {
                this.ElementalGems.Remove(elementalGem);
                this.Attack -= elementalGem.Attack;
                this.Defense -= elementalGem.Defense;
                this.Heal -= elementalGem.Heal;
            }
            else
            {
                //Deberia de tirar una exepcion
            }
        }
    }
}