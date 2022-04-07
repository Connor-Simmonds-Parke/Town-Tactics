using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    class QuestRequirements
    {
        #region Members
        //Members.
        private List<KeyValuePair<ResourceList, int>> resourceRequirements;
        private List<Item> itemRequirements;
        private List<Building> buildingRequirements;
        private List<Mission> missionRequirements;
        private int characterRequirements;
        private int turnRequirements;

        //private List<>
        #endregion

        #region Constructors
        //Constructors.
        public QuestRequirements()
        {
            this.resourceRequirements = new List<KeyValuePair<ResourceList, int>>();
            this.itemRequirements = new List<Item>();
            this.buildingRequirements = new List<Building>();
            this.missionRequirements = new List<Mission>();
            this.characterRequirements = 0;
            this.turnRequirements = 0;
        }
        #endregion

        #region Methods
        //Methods.

        #region Getters and Setters
        //Getters and Setters.
        public List<KeyValuePair<ResourceList, int>> GetResourceRequirements()
        {
            return this.resourceRequirements;
        }

        public List<Item> GetItemRequirements()
        {
            return this.itemRequirements;
        }

        public List<Building> GetBuildingRequirements()
        {
            return this.buildingRequirements;
        }

        public List<Mission> GetMissionRequirements()
        {
            return this.missionRequirements;
        }

        public int GetCharacterRequirements()
        {
            return this.characterRequirements;
        }
      
        #endregion
        #endregion
    }
}
