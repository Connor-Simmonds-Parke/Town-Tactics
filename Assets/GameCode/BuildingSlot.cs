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
        private Building currentBuilding;
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
        public bool CheckIfEmpty()
        {
            bool isEmpty = false;

            if (this.currentBuilding == null)
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        public void BuildBuilding(Building newBuilding)
        {
            if (CheckIfEmpty() == true)
            {
                this.currentBuilding = newBuilding;
            }
        }

        public void UpgradeBuilding()
        {
            if (CheckIfEmpty() == false)
            {
                this.currentBuilding.UpgradeBuilding();
            }
        }

        public void RemoveBuilding()
        {
            this.currentBuilding = null;
        }

        #region Getters and Setters
        //Getters and Setters.
        public Building GetCurrentBuilding()
        {
            return this.currentBuilding;
        }
        #endregion
        #endregion
    }
}