namespace Proyecto
{
    public class ElementalGem : IPowerUp
    {
        public int Attack { get;set;}
        public int Magic { get;set; }
        public int Defense { get;set; }
        public int Heal { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public ElementalGem(int attack, int magic, int defense, int heal, string name, string description)
        {
            this.Attack = attack;
            this.Magic = magic;
            this.Defense = defense;
            this.Heal = heal;
            this.Name = name;
            this.Description = description;
        }
         #region Default Elemental Gems
            public static Spell newAttackGem()
            {
                return new Spell(40,5,5,"Attack Gem","This is a Attack Gem");
            }
            public static Spell newDefenceGem()
            {
                return new Spell(5,40,5,"Defence Gem","This is a Defence Gem");
            }
            public static Spell newHealGem()
            {
                return new Spell(5,5,40,"Heal Gem","This is a Heal Gem");
            }

        #endregion
    }
}