/*
 * File: Trait.cs
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
    public class Trait
    {
        //Members.
        private TraitList trait;
        private string traitDescription;
        private CharacterStat traitValue;

        //Trait Descriptions.
        private readonly string STRONG = "Stronger than most. Increases Strength by 1";
        private readonly string WEAK = "Weaker than most. Decreases Strength by 1";
        private readonly string FAST = "Quicker than most. Increases Dexterity by 1";
        private readonly string SLOW = "Slower than most. Decreases Dexterity by 1";

        //Trait Values.
        private readonly CharacterStat STRONG_VALUE = new CharacterStat(1, StatsList.Strength);
        private readonly CharacterStat WEAK_VALUE = new CharacterStat(-1, StatsList.Strength);
        private readonly CharacterStat FAST_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat SLOW_VALUE = new CharacterStat(-1, StatsList.Dexterity);

        //Constructors.
        public Trait()
        {
            this.trait = TraitList.Strong;
            UpdateTrait();
        }

        //Methods.
        private void UpdateTrait()
        {
            if (this.trait == TraitList.Strong)
            {
                this.traitDescription = STRONG;
                this.traitValue = STRONG_VALUE;
            }
            else if (this.trait == TraitList.Weak)
            {
                this.traitDescription = WEAK;
                this.traitValue = WEAK_VALUE;
            }
            else if (this.trait == TraitList.Fast)
            {
                this.traitDescription = FAST;
                this.traitValue = FAST_VALUE;
            }
            else if (this.trait == TraitList.Slow)
            {
                this.traitDescription = SLOW;
                this.traitValue = SLOW_VALUE;
            }
        }

        public void InvertTraitValue()
        {
            this.traitValue.SetValue(traitValue.GetValue() * -1);
        }

        //Getters and Setters.
        public string GetTraitDescription()
        {
            return this.traitDescription;
        }

        public TraitList GetTrait()
        {
            return this.trait;
        }

        public CharacterStat GetTraitValue()
        {
            return this.traitValue;
        }
    }
}
