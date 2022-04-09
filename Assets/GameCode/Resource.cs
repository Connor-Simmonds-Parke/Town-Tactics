/*
 * File: Resource.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-03-17
 * 
 * Purpose: A resource and its acompanying value. Also holds and checks the turn end value as well.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Resource
    {
        #region Members
        //Members.
        private ResourceList name;
        private int value;
        private int turnValue;
        private string description;

        //Resource Descriptions.
        private readonly string GOLD = "";
        private readonly string STONE = "";
        private readonly string WOOD = "";
        private readonly string FOOD = "";
        private readonly string POPULATION = "";
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Resource()
        {
            this.name = ResourceList.Gold;
            this.value = 0;
            this.turnValue = 0;
            this.description = GOLD;
        }

        /// <summary>
        /// Creates a resource, its current value, and how much it changes at the end of a turn.
        /// </summary>
        /// <param name="resource">Resource to be created.</param>
        /// <param name="initialValue">The initial value of the resource.</param>
        /// <param name="turnValue">The turn value of the resource.</param>
        public Resource(ResourceList resource, int initialValue, int turnValue)
        {
            this.name = resource;
            this.value = initialValue;
            this.turnValue = turnValue;
            UpdateDescription();
        }
        #endregion

        #region Methods
        //Methods.

        /// <summary>
        /// Updates the description of the resource.
        /// </summary>
        private void UpdateDescription()
        {
            if (this.name == ResourceList.Gold)
            {
                this.description = GOLD;
            }
            else if (this.name == ResourceList.Stone)
            {
                this.description = STONE;
            }
            else if (this.name == ResourceList.Wood)
            {
                this.description = WOOD;
            }
            else if (this.name == ResourceList.Food)
            {
                this.description = FOOD;
            }
            else if (this.name == ResourceList.Population)
            {
                this.description = POPULATION;
            }
        }

        /// <summary>
        /// Alters the value of the resource.
        /// </summary>
        /// <param name="addValue">Value to add or subract.</param>
        public void ChangeValue(int addValue)
        {
            this.value += addValue;
        }

        /// <summary>
        /// Alters the amount the resource changes at the end of a turn.
        /// </summary>
        /// <param name="addTurnValue">Turn value to alter.</param>
        public void ChangeTurnValue(int addTurnValue)
        {
            this.turnValue += addTurnValue;
        }

        /// <summary>
        /// On turn end updates the resource value based on the
        /// amount it changes at the end of a turn.
        /// </summary>
        public void TurnEnd()
        {
            ChangeValue(this.turnValue);
        }
        #region
        //Getters and Setters.

        public ResourceList GetName()
        {
            return this.name;
        }

        public void SetName(ResourceList newResourceName)
        {
            this.name = newResourceName;
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int newValue)
        {
            this.value = newValue;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public int GetTurnValue()
        {
            return this.turnValue;
        }
        #endregion
        #endregion
    }
}
