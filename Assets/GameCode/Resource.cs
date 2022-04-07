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
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="initialValue"></param>
        /// <param name="turnValue"></param>
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

        public void ChangeValue(int addValue)
        {
            this.value += addValue;
        }

        public void ChangeTurnValue(int addTurnValue)
        {
            this.turnValue += addTurnValue;
        }

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
