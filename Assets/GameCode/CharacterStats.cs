/*
 * File: CharacterStats.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Holds a list of individual stats used by a character.
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

        public CharacterStats(CharacterStats listOfStats)
        {
            //this.statsList = new List<CharacterStat>();
            ResetAndModifyStats(listOfStats);
        }
        #endregion

        #region Methods
        //Methods
        public void ModifyAllStats(CharacterStats listOfStats)
        {
            foreach (CharacterStat newStat in listOfStats.GetStatsList())
            {
                ModifyOneStat(newStat);
            }
        }

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

        public void ResetStats()
        {
            foreach (CharacterStat oldStat in this.statsList)
            {
                oldStat.SetValue(0);
            }
        }

        public void ResetAndModifyStats(CharacterStats listOfStats)
        {
            ResetStats();
            ModifyAllStats(listOfStats);
        }

        public void ResetAndModifyStats(CharacterStat newStat)
        {
            ResetStats();
            ModifyOneStat(newStat);
        }

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
