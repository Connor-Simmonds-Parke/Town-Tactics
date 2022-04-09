/*
 * File: BuildingSlot.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-03-12
 * 
 * Purpose: The building slot for which specific buildings take up. Can build, upgrade, or remove buildings. A town only has a limited number of building slots.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class BuildingSlot
    {
        #region Members
        //Members.
        private Building currentBuilding;       //Current Building in the Building Slot.
        #endregion

        #region Constructors
        //Constructors.
        public BuildingSlot()
        {
            this.currentBuilding = null;
        }
        #endregion

        #region Methods
        //Methods.

        /// <summary>
        /// Checks if the Building Slot is empty.
        /// </summary>
        /// <returns>True if empty, false if not.</returns>
        public bool CheckIfEmpty()
        {
            bool isEmpty = false;

            if (this.currentBuilding == null)
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        /// <summary>
        /// First checks if the building slot is empty. If it is, builds
        /// the specified building.
        /// </summary>
        /// <param name="newBuilding"></param>
        public void BuildBuilding(Building newBuilding)
        {
            if (CheckIfEmpty() == true)
            {
                this.currentBuilding = newBuilding;
            }
        }

        /// <summary>
        /// First checks to make sure the building slot isn't empty.
        /// If it isn't, upgrades the current building.
        /// </summary>
        public void UpgradeBuilding()
        {
            if (CheckIfEmpty() == false)
            {
                this.currentBuilding.UpgradeBuilding();
            }
        }

        /// <summary>
        /// Removes the current building.
        /// </summary>
        public void RemoveBuilding()
        {
            this.currentBuilding = null;
        }

        #region Getters and Setters
        //Getters and Setters.

        /// <summary>
        /// Gets the current building in the building slot.
        /// </summary>
        /// <returns></returns>
        public Building GetCurrentBuilding()
        {
            return this.currentBuilding;
        }
        #endregion
        #endregion
    }
}