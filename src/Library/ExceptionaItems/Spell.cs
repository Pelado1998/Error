namespace Proyecto
{
    public class Spell : IPowerUp
    {
        public int Attack { get;set;}
        public int Defense { get;set; }
        public int Heal { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public Spell(int attack, int defense, int heal, string name, string description)
        {
            this.Attack = attack;
            this.Defense = defense;
            this.Heal = heal;
            this.Name = name;
            this.Description = description;
        }
        #region Default Spells
            public static Spell newAttackSpell()
            {
                return new Spell(40,5,5,"Attack Spell","This is a Attack Spell");
            }
            public static Spell newDefenceSpell()
            {
                return new Spell(5,40,5,"Defence Spell","This is a Defence Spell");
            }
            public static Spell newHealSpell()
            {
                return new Spell(5,5,40,"Heal Spell","This is a Heal Spell");
            }

        #endregion
    }
}