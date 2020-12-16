using System;
using System.Collections.Generic;

namespace Proyecto
{
    public class AllCharacters
    {
        public List<Character> CharacterList;
        private static AllCharacters instance;
        private AllCharacters()
        {
            this.CharacterList = new List<Character>();
        }
        public static AllCharacters Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AllCharacters();
                }

                return instance;
            }
        }
        public Character GetCharacter(String characterName)
        {
            foreach (Character character in this.CharacterList)
            {
                if(character.Name == characterName)
                {
                    return character;
                }
            }
            return Character.Empty;//Se debe dar una excepcion
        }
        public Character GetCharacter(Character characterName)
        {
            foreach (Character character in this.CharacterList)
            {
                if(character == characterName)
                {
                    return character;
                }
            }
            return Character.Empty;//Se debe dar una excepcion
        }
    }
}