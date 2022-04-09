/*
 * File: Race.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: The race of a character. Can be changed (for now, just for character creation) and affects starting stats.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Race
    {
        #region Members
        //Members.
        private RaceList name;
        private string description;
        private CharacterStats raceStats;

        //Race Descriptions.
        private readonly string HUMANS = "the most diverse and populus of the races, and the median for which all others are compared to";
        private readonly string ELVES = "a long living and elegant race. Elves are generally more dexterious and born with innate magical affinity";
        private readonly string DWARVES = "a short and stout race. Dwarves prefer the solitude of their mountains and are a naturally hardy and jovial people";
        private readonly string ORCS = "a hulking and violent people. Their warlike nature has largely ostracized them from the other races";
        #endregion

        #region Constructors
        //Constructors.
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Race()
        {
            this.name = RaceList.Human;
            this.description = "No Race description given, this was a default race or mistake";
            raceStats = new CharacterStats();
        }
        
        /// <summary>
        /// Creates a race and updates the information.
        /// </summary>
        /// <param name="race">Race to be created.</param>
        public Race(RaceList race)
        {
            ChangeRace(race);       
        }
        #endregion

        #region Methods
        //Methods.

        /// <summary>
        /// Changes the race and updates the base stats and information.
        /// </summary>
        /// <param name="race">Race to change to.</param>
        public void ChangeRace(RaceList race)
        {
            this.name = race;
            UpdateRace(race);
        }

        /// <summary>
        /// Updates the base stats and information of the race.
        /// </summary>
        /// <param name="race">Race to update to.</param>
        public void UpdateRace(RaceList race)
        {
            if (race == RaceList.Human)
            {
                this.description = HUMANS;
                raceStats = new CharacterStats(5, 5, 5, 5, 5);
            }
            else if (race == RaceList.Elf)
            {
                this.description = ELVES;
                raceStats = new CharacterStats(3, 7, 5, 7, 3);
            }
            else if (race == RaceList.Dwarf)
            {
                this.description = DWARVES;
                raceStats = new CharacterStats(6, 3, 7, 2, 7);
            }
            else if (race == RaceList.Orc)
            {
                this.description = ORCS;
                raceStats = new CharacterStats(9, 5, 4, 5, 2);
            }
        }

        #region Getters and Setters
        //Getters and Setters.

        /// <summary>
        /// Gets the race name.
        /// </summary>
        /// <returns>Race name.</returns>
        public RaceList GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Sets a new race.
        /// </summary>
        /// <param name="newRace">New race.</param>
        public void SetName(RaceList newRace)
        {
            this.name = newRace;
        }

        /// <summary>
        /// Gets the race's description.
        /// </summary>
        /// <returns>String of race's description.</returns>
        public string GetDescription()
        {
            return this.description;
        }

        /// <summary>
        /// Gets the base stats of the race.
        /// </summary>
        /// <returns>Stats list of the base race stats.</returns>
        public CharacterStats GetRaceStats()
        {
            return this.raceStats;
        }
        #endregion

        #endregion
    }
}
