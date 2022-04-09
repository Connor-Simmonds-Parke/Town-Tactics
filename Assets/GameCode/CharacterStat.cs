/*
 * File: CharacterStat.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: A single character stat. Has methods to alter its value, and various ways to create the class.
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
        #region Members
        //Members.
        private int value;
        private string description;
        private StatsList name;
        #endregion

        #region Constructors
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

        /// <summary>
        /// Creates a stat based on the name, value, and description given.
        /// </summary>
        /// <param name="statValue">Value of the stat.</param>
        /// <param name="statName">Name of the stat.</param>
        /// <param name="statDescription">Description of the stat.</param>
        public CharacterStat(int statValue, StatsList statName, string statDescription)
        {
            this.value = statValue;
            this.name = statName;
            this.description = statDescription;
        }

        /// <summary>
        /// Creates a stat based on the name and value given.
        /// </summary>
        /// <param name="statValue">Value of the stat.</param>
        /// <param name="statName">Name of the stat.</param>
        public CharacterStat(int statValue, StatsList statName)
        {
            this.value = statValue;
            this.name = statName;
            this.description = "No stat description, this was a default stat or mistake";
        }
        #endregion

        #region Methods         
        //Methods.
        /// <summary>
        /// Modifies the value of the stat.
        /// </summary>
        /// <param name="statValue">The stat to add or subtract.</param>
        public void ModifyValue(int statValue)
        {
            this.value += statValue;
        }

        #region Getters and Setters
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
        #endregion
        #endregion
    }
}
