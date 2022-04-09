/*
 * File: CharacterBuff.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Temporary buffs/debuffs that affect a character. Temporarily alters stats, and can affect a mission depending on the mission's requirements.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class CharacterBuff
    {
        #region Members
        //Members.
        private CharacterBuffList buffName;
        private int buffDuration;
        private CharacterStat buffValue;
        private string buffDescription;

        //Buff Descriptions.
        private readonly string ENHANCED = "enhanced by magic, increasing their strength by 1";
        private readonly string WEAKENED = "crippled by magic, decreasing their strenght by 1";

        //Buff Durations.
        private readonly int ENHANCED_DURATION = 1;
        private readonly int WEAKENED_DURATION = 1;

        //Buff Values.
        private readonly CharacterStat ENHANCED_VALUE = new CharacterStat(1, StatsList.Strength);
        private readonly CharacterStat WEAKENED_VALUE = new CharacterStat(-1, StatsList.Strength);
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor. Creates a standard buff and updates its default information.
        /// </summary>
        public CharacterBuff()
        {
            this.buffName = CharacterBuffList.Enhanced;
            UpdateBuff();
        }
        #endregion

        #region Methods
        //Methods.

        /// <summary>
        /// Updates the buff's default information.
        /// </summary>
        private void UpdateBuff()
        {
            if (this.buffName == CharacterBuffList.Enhanced)
            {
                this.buffDescription = ENHANCED;
                this.buffDuration = ENHANCED_DURATION;
                this.buffValue = ENHANCED_VALUE;
            }
            else if (this.buffName == CharacterBuffList.Weakened)
            {
                this.buffDescription = WEAKENED;
                this.buffDuration = WEAKENED_DURATION;
                this.buffValue = WEAKENED_VALUE;
            }
        }

        /// <summary>
        /// Checks the turn duration left on the buff and returns whether it needs
        /// to be removed or not.
        /// </summary>
        /// <returns>If the buff duration is finished as a Boolean</returns>
        public bool CheckBuffEnded()
        {
            bool buffEnded = false;

            //If the buff duration is done.
            if (this.buffDuration <= 0)
            {
                buffEnded = true;
                InvertBuffValue();                      //Flips the buff value to the opposite sign.
            }

            return buffEnded;
        }

        /// <summary>
        /// When a buff is removed it's stats are taken away, so the buff value is flipped to the opposite sign.
        /// </summary>
        public void InvertBuffValue()
        {
            this.buffValue.SetValue(buffValue.GetValue() * -1);
        }

        #region Getters and Setters
        //Getters and Setters.

        /// <summary>
        /// Gets the description of the buff.
        /// </summary>
        /// <returns>Buff description as a string</returns>
        public string GetBuffDescription()
        {
            return this.buffDescription;
        }

        /// <summary>
        /// Gets the stat value of the buff.
        /// </summary>
        /// <returns>Buff value as a character stat</returns>
        public CharacterStat GetBuffValue()
        {
            return this.buffValue;
        }
        #endregion

        #endregion
    }
}
