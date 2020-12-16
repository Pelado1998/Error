using System.Collections.Generic;
using System;

namespace Proyecto
{
    public class SpellsBook:AbstractItem, IPowerUpable<Spell>
    {   
        private List<Spell> Spells;
        public SpellsBook(int attack, int magic, int defense, int heal, string name, string description) :base(attack, magic, defense, heal, name, description)
        {
            Spells = new List<Spell>(){};
        }
        public void addPowerUp(Spell spells)
        {
            if (!this.Spells.Contains(spells))
            {
                this.Spells.Add(spells);
                this.Attack += spells.Attack;
                this.Defense += spells.Defense;
                this.Heal += spells.Heal;
            }
            else
            {
                //Deberia de tirar una exepcion
            }
        }

        public void removePowerUp(Spell spells)
        {
            if (this.Spells.Contains(spells))
            {
                this.Spells.Remove(spells);
                this.Attack -= spells.Attack;
                this.Defense -= spells.Defense;
                this.Heal -= spells.Heal;
            }
            else
            {
                //Deberia de tirar una exepcion
            }
        }
    }
}