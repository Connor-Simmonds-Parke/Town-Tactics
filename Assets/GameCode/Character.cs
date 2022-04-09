/*
 * File: Character.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: A character that is used to send on missions and fulfill objectives. The character is a culmination of a number of different 
 * stats, levels, race and appearance, equipment, and buffs and traits. This file holds much of the specific code for changing a character's
 * stats.
 * 
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Character
    {
        #region Members
        //Members.
        private string name;                    
        private int experience;
        private int level;
        private int statPoints;
        private CharacterStats stats;
        private Race race;
        private CharacterBody body;
        private List<CharacterBuff> buffs;
        private List<Trait> traits;
        private Equipment equipment;
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor, creates a character with default values.
        /// </summary>
        public Character()
        {
            this.name = "No one";
            this.experience = 0;
            this.level = 1;
            this.statPoints = 0;
            this.race = new Race();
            this.stats = new CharacterStats();
            this.stats.ResetAndModifyStats(race.GetRaceStats());
            this.body = new CharacterBody();
            this.buffs = new List<CharacterBuff>();
            this.traits = new List<Trait>();
            this.equipment = new Equipment();

            UpdateItems();
        }

        public Character(bool isRandom)
        {
            TraitList randomTrait = (TraitList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(TraitList)).Length));
            RaceList randomRace = (RaceList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(RaceList)).Length));
            BodyColourList randomBodyColour = (BodyColourList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(BodyColourList)).Length));
            BodySizeList randomBodySize = (BodySizeList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(BodySizeList)).Length));
            HairColourList randomHairColour = (HairColourList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(HairColourList)).Length));
            HairStyleList randomHairStyle = (HairStyleList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(HairStyleList)).Length));
            EyeColourList randomEyeColour = (EyeColourList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(EyeColourList)).Length));
            FacialHairList randomFacialHair = FacialHairList.None;
            GenderList randomGender = (GenderList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(GenderList)).Length));
            Enum randomName;

            if (randomGender == GenderList.Male)
            {
                randomName = (MaleNamesList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(MaleNamesList)).Length));
                randomFacialHair = (FacialHairList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(FacialHairList)).Length));
            }
            else
            {
                randomName = (FemaleNamesList)(UnityEngine.Random.Range(0, Enum.GetNames(typeof(FemaleNamesList)).Length));
            }

            this.name = randomName.ToString();
            this.experience = 0;
            this.level = 1;
            this.statPoints = 0;
            this.race = new Race(randomRace);
            this.stats = new CharacterStats();
            this.stats.ResetAndModifyStats(race.GetRaceStats());
            this.body = new CharacterBody(randomGender, randomBodySize, randomBodyColour, randomHairColour, randomHairStyle, randomFacialHair, randomEyeColour);
            this.buffs = new List<CharacterBuff>();
            this.traits = new List<Trait>();
            this.equipment = new Equipment();

            AddTrait(new Trait(randomTrait));

            UpdateItems();
        }
        #endregion

        #region Methods
        //Methods.
        /// <summary>
        /// Changes the character's Race and stats.
        /// </summary>
        /// <param name="race">Race to change to.</param>
        public void ChangeRace(RaceList race)
        {
            this.race.ChangeRace(race);                                 //Changes the character's race.
            this.stats.ResetAndModifyStats(this.race.GetRaceStats());   //Changes the stats to match the race's base stats.
        }

        /// <summary>
        /// If the character has stant points to spend, the player can spend them to increase 
        /// that character's stats.
        /// </summary>
        /// <param name="stat">Stat to increase.</param>
        /// <param name="newValue">How much to increase the stat value.</param>
        public void SpendStatPoint(StatsList stat, int newValue)
        {
            //Only allow stat increases when there are stat points available.
            if (this.statPoints > 0)
            {
                this.stats.ModifyOneStat(stat, newValue);   //Increases or decreases the specific stat.
                this.statPoints -= 1;
            }
        }

        #region Buff Methods
        /// <summary>
        /// Checks the duration of the buffs on the character and removes them and changes stats if they are expired.
        /// </summary>
        public void CheckBuffs()
        {
            foreach (CharacterBuff buff in this.buffs)
            {
                if (buff.CheckBuffEnded() == true)
                {
                    RemoveBuff(buff);   //Removes the buff from the character and changes the character's stats.
                }
            }
        }

        /// <summary>
        /// Adds a buff to the character's buff list.
        /// </summary>
        /// <param name="buffToAdd">Buff to be added.</param>
        public void AddBuff(CharacterBuff buffToAdd)
        {
            this.buffs.Add(buffToAdd);                          //Adds the buff.
            this.stats.ModifyOneStat(buffToAdd.GetBuffValue()); //Changes the stats.
        }

        /// <summary>
        /// Removes a buff from the character's buff list.
        /// </summary>
        /// <param name="buffToRemove">Buff to be removed.</param>
        public void RemoveBuff(CharacterBuff buffToRemove)
        {
            buffToRemove.InvertBuffValue();                         //Changes the buffs value to the opposite sign.
            this.stats.ModifyOneStat(buffToRemove.GetBuffValue());  //Changes the character's stats.
            this.buffs.Remove(buffToRemove);                        //Removes the buff from the character.
        }
        #endregion

        #region Trait Methods
        /// <summary>
        /// Adds a trait to the character, affects the character's stats.
        /// Will not add duplicate traits.
        /// </summary>
        /// <param name="traitToAdd">Trait to be added.</param>
        /// <returns>Whether the trait was added to the character.</returns>
        public bool AddTrait(Trait traitToAdd)
        {
            bool traitAdded = true;                                 //Bool to be returned if trait is added.

            //Loops through the current traits.
            foreach (Trait trait in this.traits)
            {         
                //If the trait is already on the character don't add it again.
                if (trait.GetTrait() == traitToAdd.GetTrait())
                {
                    traitAdded = false;
                }
            }

            //If no duplicate trait was found.
            if (traitAdded == true)
            {
                this.traits.Add(traitToAdd);                            //Adds the trait to the character.
                this.stats.ModifyOneStat(traitToAdd.GetTraitValue());   //Changes the character's stats.
            }

            return traitAdded;
        }

        /// <summary>
        /// Removes a trait from a character, if they have that trait.
        /// Affects the character's stats.
        /// </summary>
        /// <param name="traitToRemove"></param>
        public void RemoveTrait(TraitList traitToRemove)
        {
            Trait tempTrait = new Trait();                          //Used to store the trait to be removed.
            bool traitFound = false;                                //Holds if the trait is on the character.

            //Loops through the traits to find the trait to be removed.
            foreach (Trait trait in this.traits)
            {
                if (traitToRemove == trait.GetTrait())
                {
                    tempTrait = trait;
                    traitFound = true;
                }
            }

            //If the trait was found, remove it.
            if (traitFound == true)
            {
                tempTrait.InvertTraitValue();                           //Changes to the opposite value of the stat.
                this.stats.ModifyOneStat(tempTrait.GetTraitValue());    //Changes the stat.
                traits.Remove(tempTrait);                               //Removes the Trait.
            }
        }
        #endregion

        #region Equipment Methods
        /// <summary>
        /// Changes a peice of equipment that the character is wearing
        /// and adjusts the stats.
        /// </summary>
        /// <param name="itemToChange">The item being equipped.</param>
        public void ChangeItem(Item itemToChange)
        {
            Item oldItem;                                               //Holds the item being un-equipped.

            //Remove the stats the item gave to the character.
            oldItem = this.equipment.InvertItemValue(itemToChange);
            this.stats.ModifyOneStat(oldItem.GetItemValue());

            //Add the new stats from the new item.
            this.equipment.ChangeItem(itemToChange);
            this.stats.ModifyOneStat(itemToChange.GetItemValue());
        }

        /// <summary>
        /// Just updates all the equipment stats. Only used during a new character creation.
        /// </summary>
        private void UpdateItems()
        {
            this.stats.ModifyOneStat(equipment.GetChestItem().GetItemValue());
            this.stats.ModifyOneStat(equipment.GetFeetItem().GetItemValue());
            this.stats.ModifyOneStat(equipment.GetHandsItem().GetItemValue());
            this.stats.ModifyOneStat(equipment.GetHeadItem().GetItemValue());
            this.stats.ModifyOneStat(equipment.GetLegsItem().GetItemValue());
            this.stats.ModifyOneStat(equipment.GetToolItem().GetItemValue());
        }
        #endregion

        #region Getters and Setters
        //Getters and Setters.

        /// <summary>
        /// Gets the Character's name.
        /// </summary>
        /// <returns>Character's name.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Gets the character's current experience points.
        /// </summary>
        /// <returns>Current Experience points.</returns>
        public int GetExperience()
        {
            return this.experience;
        }
        
        /// <summary>
        /// Gets the character's current level.
        /// </summary>
        /// <returns>Character's level.</returns>
        public int GetLevel()
        {
            return this.level;
        }

        /// <summary>
        /// Gets the character's stat points that can be spent.
        /// </summary>
        /// <returns>Spendable stat points.</returns>
        public int GetStatPoints()
        {
            return this.statPoints;
        }

        /// <summary>
        /// Gets the character's list of stats.
        /// </summary>
        /// <returns>List of stats.</returns>
        public CharacterStats GetStats()
        {
            return this.stats;
        }

        /// <summary>
        /// Gets the character's race.
        /// </summary>
        /// <returns>Character's race object.</returns>
        public Race GetRace()
        {
            return this.race;
        }

        /// <summary>
        /// Gets the character's appearance.
        /// </summary>
        /// <returns>Character's appearance object.</returns>
        public CharacterBody GetBody()
        {
            return this.body;
        }

        /// <summary>
        /// Gets the character's buffs.
        /// </summary>
        /// <returns>List of character's buffs.</returns>
        public List<CharacterBuff> GetBuffs()
        {
            return this.buffs;
        }

        /// <summary>
        /// Gets the character's traits.
        /// </summary>
        /// <returns>List of character's traits.</returns>
        public List<Trait> GetTraits()
        {
            return this.traits;
        }

        /// <summary>
        /// Gets the character's equipped items.
        /// </summary>
        /// <returns>Character's equipment object.</returns>
        public Equipment GetEquipment()
        {
            return this.equipment;
        }
        #endregion

        #endregion
    }
}
