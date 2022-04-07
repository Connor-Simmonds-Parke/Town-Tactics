/*
 * File: Building.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-27
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
    public class Building
    {
        #region Members
        //Members.
        protected string name;
        protected string pictureName;
        protected string description;
        protected int level;
        protected int maxLevel;
        protected List<KeyValuePair<int, List<KeyValuePair<ResourceList, int>>>> costsList;
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Building()
        {

        }
        #endregion

        #region Methods
        //Methods.
        virtual public void UpgradeBuilding()
        {

        }

        #region Getters and Setters
        //Getters and Setters.
        public List<KeyValuePair<ResourceList, int>> GetCostsList(int buildingLevel)
        {
            List<KeyValuePair<ResourceList, int>> tempList = new List<KeyValuePair<ResourceList, int>>();

            foreach (KeyValuePair<int, List<KeyValuePair<ResourceList, int>>> buildingList in costsList)
            {
                if (buildingList.Key == buildingLevel)
                {
                    tempList = buildingList.Value;
                }
            }

            return tempList;
        }

        public int GetLevel()
        {
            return this.level;
        }

        public int GetMaxLevel()
        {
            return this.maxLevel;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetPictureName()
        {
            return this.pictureName; 
        }

        public string GetDescription()
        {
            return this.description;
        }
        #endregion
        #endregion
    }
}
