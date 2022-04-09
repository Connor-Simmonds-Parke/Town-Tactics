/*
 * File: CharacterStats.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Holds a list of individual stats used by a character or used to alter a list of character stats.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class CharacterStats
    {
        #region Members
        //Members.
        private List<CharacterStat> statsList;

        //Character Stat descriptions.
        private readonly string STRENGTH = "The physical power of the character";
        private readonly string MAGIC = "How adept the character is with magic";
        private readonly string INTELLIGENCE = "The character's mental ability";
        private readonly string DEXTERITY = "How precice and agile the character is";
        private readonly string CHARISMA = "The character's social ability";
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor. Just fills out a stats list with 0 in all.
        /// </summary>
        public CharacterStats()
        {

            this.statsList = new List<CharacterStat>();

            //Add Character Stats to the Stat list.
            statsList.Add(new CharacterStat(0, StatsList.Strength, STRENGTH));
            statsList.Add(new CharacterStat(0, StatsList.Magic, MAGIC));
            statsList.Add(new CharacterStat(0, StatsList.Intelligence, INTELLIGENCE));
            statsList.Add(new CharacterStat(0, StatsList.Dexterity, DEXTERITY));
            statsList.Add(new CharacterStat(0, StatsList.Charisma, CHARISMA));
        }

        /// <summary>
        /// Creates a list of all the stats and assigns them the values.
        /// </summary>
        /// <param name="strength">Strength value.</param>
        /// <param name="magic">Magic value.</param>
        /// <param name="intelligence">Intelligence value.</param>
        /// <param name="dexterity">Dexterity value.</param>
        /// <param name="charisma">Charisma value.</param>
        public CharacterStats(int strength, int magic, int intelligence, int dexterity, int charisma)
        {

            this.statsList = new List<CharacterStat>();

            //Add Character Stats to the Stat list.
            statsList.Add(new CharacterStat(strength, StatsList.Strength, STRENGTH));
            statsList.Add(new CharacterStat(magic, StatsList.Magic, MAGIC));
            statsList.Add(new CharacterStat(intelligence, StatsList.Intelligence, INTELLIGENCE));
            statsList.Add(new CharacterStat(dexterity, StatsList.Dexterity, DEXTERITY));
            statsList.Add(new CharacterStat(charisma, StatsList.Charisma, CHARISMA));
        }

        /// <summary>
        /// Creates a list of stats with the values of
        /// another list of stats.
        /// </summary>
        /// <param name="listOfStats">List of stats.</param>
        public CharacterStats(CharacterStats listOfStats)
        {
            //this.statsList = new List<CharacterStat>();
            ResetAndModifyStats(listOfStats);
        }
        #endregion

        #region Methods
        //Methods

        /// <summary>
        /// Runs through each stat in the list and alters the value.
        /// Checks to make sure the stats match up.
        /// </summary>
        /// <param name="listOfStats">List of stats to alter current stats with.</param>
        public void ModifyAllStats(CharacterStats listOfStats)
        {
            foreach (CharacterStat newStat in listOfStats.GetStatsList())
            {
                ModifyOneStat(newStat);
            }
        }

        /// <summary>
        /// Alters the single stat value based on the given stat object.
        /// </summary>
        /// <param name="newStat">Single stat to alter current stat with.</param>
        public void ModifyOneStat(CharacterStat newStat)
        {
            foreach (CharacterStat oldStat in this.statsList)
            {
                if (oldStat.GetName() == newStat.GetName())
                {
                    oldStat.ModifyValue(newStat.GetValue());
                }
            }
        }

        /// <summary>
        /// Alters a single stat value without using a stat object.
        /// </summary>
        /// <param name="stat">Name of the stat to alter.</param>
        /// <param name="newValue">Value to alter the stat with.</param>
        public void ModifyOneStat(StatsList stat, int newValue)
        {
            foreach (CharacterStat oldStat in this.statsList)
            {
                if (oldStat.GetName() == stat)
                {
                    oldStat.ModifyValue(newValue);
                }
            }
        }

        /// <summary>
        /// Sets the stat value of every stat in the list to zero.
        /// </summary>
        public void ResetStats()
        {
            foreach (CharacterStat oldStat in this.statsList)
            {
                oldStat.SetValue(0);
            }
        }

        /// <summary>
        /// Resets the stats values to zero and then calls the 
        /// method that sets the values of all the stats to the given list of stats.
        /// </summary>
        /// <param name="listOfStats">Stats to set the value to.</param>
        public void ResetAndModifyStats(CharacterStats listOfStats)
        {
            ResetStats();
            ModifyAllStats(listOfStats);
        }

        /// <summary>
        /// Resets the stats values to zero and then calls the 
        /// method that sets the value of a single stat. Used on in specific situations.
        /// </summary>
        /// <param name="newStat">Single stat to set the value to.</param>
        public void ResetAndModifyStats(CharacterStat newStat)
        {
            ResetStats();
            ModifyOneStat(newStat);
        }

        /// <summary>
        /// Overrides the default ToString() to give both the stat name
        /// and the stat value.
        /// </summary>
        /// <returns>String of stat name and stat value.</returns>
        public override string ToString()
        {
            string tempString = "";

            foreach (CharacterStat stat in this.statsList)
            {
                tempString += stat.GetName() + ": " + stat.GetValue() + "\n";
            }

            return tempString;
        }

        #region Getters and Setters
        //Getters and Setters
        public List<CharacterStat> GetStatsList()
        {
            return this.statsList;
        }

        public void SetStatsList(List<CharacterStat> newStatsList)
        {
            this.statsList = newStatsList;
        }
        #endregion

        #endregion
    }
}
