/*
 * File: CharacterStat.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class CharacterStat
    {
        //Members.
        private int value;
        private string description;
        private StatsList name;

        //Constructors.

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public CharacterStat()
        {
            this.value = 0;
            this.name = StatsList.Strength;
            this.description = "No stat description, this was a default stat or mistake";
        }

        public CharacterStat(int statValue, StatsList statName, string statDescription)
        {
            this.value = statValue;
            this.name = statName;
            this.description = statDescription;
        }

        public CharacterStat(int statValue, StatsList statName)
        {
            this.value = statValue;
            this.name = statName;
            this.description = "No stat description, this was a default stat or mistake";
        }

        //Methods.
        public void ModifyValue(int statValue)
        {
            this.value += statValue;
        }

        //Getters and Setters.
        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int newValue)
        {
            this.value = newValue;
        }

        public StatsList GetName()
        {
            return this.name;
        }

        public void SetName(StatsList newName)
        {
            this.name = newName;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string newDescription)
        {
            this.description = newDescription;
        }
    }   
}
