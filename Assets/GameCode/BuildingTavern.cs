/*
 * File: BuildingTavern.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-03-12
 * 
 * Purpose: This class is a building, the Tavern, and it's two upgrades. It also holds the information for initial costs and upgrades.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class BuildingTavern : Building
    {
        #region Members
        //Members.
        private List<KeyValuePair<ResourceList, int>> tavernCost;
        private List<KeyValuePair<ResourceList, int>> innCost;
        private List<KeyValuePair<ResourceList, int>> stablesCost;

        //Building Names.
        private readonly string TAVERN_NAME = "Tavern";
        private readonly string INN_NAME = "Inn";
        private readonly string STABLES_NAME = "Inn & Stables";

        //Picture Names.
        private readonly string TAVERN_PICTURE = "Tavern";
        private readonly string INN_PICTURE = "Inn";
        private readonly string STABLES_PICTURE = "Stables";

        //Building Descriptions.
        private readonly string TAVERN = "A simple place for food and drinks.";
        private readonly string INN = "Lodgings, meals, and drinks.";
        private readonly string STABLES = "Lodgings, meals, and drinks, and they'll even take care of your horses.";

        //Tavern Costs.
        private readonly ResourceList TAVERN_RESOURCE_1 = ResourceList.Gold;
        private readonly int TAVERN_COST_1 = 100;

        private readonly ResourceList TAVERN_RESOURCE_2 = ResourceList.Stone;
        private readonly int TAVERN_COST_2 = 50;

        private readonly ResourceList TAVERN_RESOURCE_3 = ResourceList.Wood;
        private readonly int TAVERN_COST_3 = 100;

        //Inn Updrage Costs. 
        private readonly ResourceList INN_RESOURCE_1 = ResourceList.Gold;
        private readonly int INN_COST_1 = 200;

        private readonly ResourceList INN_RESOURCE_2 = ResourceList.Stone;
        private readonly int INN_COST_2 = 100;

        private readonly ResourceList INN_RESOURCE_3 = ResourceList.Wood;
        private readonly int INN_COST_3 = 200;

        //Stables Upgrade Costs.
        private readonly ResourceList STABLES_RESOURCE_1 = ResourceList.Gold;
        private readonly int STABLES_COST_1 = 400;

        private readonly ResourceList STABLES_RESOURCE_2 = ResourceList.Stone;
        private readonly int STABLES_COST_2 = 200;

        private readonly ResourceList STABLES_RESOURCE_3 = ResourceList.Wood;
        private readonly int STABLES_COST_3 = 300;

        private readonly ResourceList STABLES_RESOURCE_4 = ResourceList.Food;
        private readonly int STABLES_COST_4 = 200;
        #endregion

        #region Constructors
        //Constructors.
        public BuildingTavern()
        {
            base.level = 1;
            base.maxLevel = 3;
            base.name = TAVERN_NAME;
            base.pictureName = TAVERN_PICTURE;
            base.description = TAVERN;
            UpdateCosts();
        }
        #endregion

        #region Methods
        //Methods.

        /// <summary>
        /// Updates the costs for each building.
        /// </summary>
        public void UpdateCosts()
        {
            tavernCost = new List<KeyValuePair<ResourceList, int>>();
            innCost = new List<KeyValuePair<ResourceList, int>>();
            stablesCost = new List<KeyValuePair<ResourceList, int>>();
            base.costsList = new List<KeyValuePair<int, List<KeyValuePair<ResourceList, int>>>>();
            KeyValuePair<int, List<KeyValuePair<ResourceList, int>>> tempPair;

            //Tavern.
            this.tavernCost.Add(new KeyValuePair<ResourceList, int>(TAVERN_RESOURCE_1, TAVERN_COST_1));
            this.tavernCost.Add(new KeyValuePair<ResourceList, int>(TAVERN_RESOURCE_2, TAVERN_COST_2));
            this.tavernCost.Add(new KeyValuePair<ResourceList, int>(TAVERN_RESOURCE_3, TAVERN_COST_3));

            tempPair = new KeyValuePair<int, List<KeyValuePair<ResourceList, int>>>(1, tavernCost);
            base.costsList.Add(tempPair);

            //Inn.
            this.innCost.Add(new KeyValuePair<ResourceList, int>(INN_RESOURCE_1, INN_COST_1));
            this.innCost.Add(new KeyValuePair<ResourceList, int>(INN_RESOURCE_2, INN_COST_2));
            this.innCost.Add(new KeyValuePair<ResourceList, int>(INN_RESOURCE_3, INN_COST_3));

            tempPair = new KeyValuePair<int, List<KeyValuePair<ResourceList, int>>>(2, innCost);
            base.costsList.Add(tempPair);

            //Stables.
            this.stablesCost.Add(new KeyValuePair<ResourceList, int>(STABLES_RESOURCE_1, STABLES_COST_1));
            this.stablesCost.Add(new KeyValuePair<ResourceList, int>(STABLES_RESOURCE_2, STABLES_COST_2));
            this.stablesCost.Add(new KeyValuePair<ResourceList, int>(STABLES_RESOURCE_3, STABLES_COST_3));
            this.stablesCost.Add(new KeyValuePair<ResourceList, int>(STABLES_RESOURCE_4, STABLES_COST_4));

            tempPair = new KeyValuePair<int, List<KeyValuePair<ResourceList, int>>>(3, stablesCost);
            base.costsList.Add(tempPair);
        }

        /// <summary>
        /// Upgrades the building by increasing the building level and calling
        /// the method for upgrading to the (now) current building level.
        /// </summary>
        public override void UpgradeBuilding()
        {
            if (base.level < base.maxLevel)
            {
                base.level += 1;
            }

            if (base.level == 2)
            {
                UpgradeToInn();
            }
            else if (base.level == 3)
            {
                UpgradeToStables();
            }
        }

        /// <summary>
        /// Upgrades and updates the building to be an Inn.
        /// </summary>
        public void UpgradeToInn()
        {
            base.name = INN_NAME;
            base.pictureName = INN_PICTURE;
            base.description = INN;
        }

        /// <summary>
        /// Upgrades and updaates the building to be a Stables.
        /// </summary>
        public void UpgradeToStables()
        {
            base.name = STABLES_NAME;
            base.pictureName = STABLES_PICTURE;
            base.description = STABLES;
        }

        #region Getters and Setters
        //Getters and Setters.
        public List<KeyValuePair<ResourceList, int>> GetTavernCosts()
        {
            return this.tavernCost;
        }

        public List<KeyValuePair<ResourceList, int>> GetInnCosts()
        {
            return this.innCost;
        }

        public List<KeyValuePair<ResourceList, int>> GetStablesCosts()
        {
            return this.stablesCost;
        }
        #endregion
        #endregion
    }
}
