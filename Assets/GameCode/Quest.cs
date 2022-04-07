using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Quest
    {
        #region Members
        //Members.
        private bool isCompleted;
        private bool isActive;

        private QuestList name;
        private string description;

        //Quest Requirements.
        private List<KeyValuePair<ResourceList, int>> resourceRequirements;
        private List<Item> itemRequirements;
        private List<Building> buildingRequirements;
        private List<Mission> missionRequirements;
        private int characterRequirements;
        private int turnRequirements;

        //Quest Activation Requirements.
        private int turnActivation;
        private Quest questActivation;
        private Mission missionActivation;
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Quest()
        {
            this.isCompleted = false;
            this.isActive = false;

            this.name = QuestList.Tutorial1;
            this.description = "";

            this.resourceRequirements = new List<KeyValuePair<ResourceList, int>>();
            this.itemRequirements = new List<Item>();
            this.buildingRequirements = new List<Building>();
            this.missionRequirements = new List<Mission>();
            this.characterRequirements = 0;
            this.turnRequirements = 0;

            this.turnActivation = 0;
            this.questActivation = null;
            this.missionActivation = null;
        }

        public Quest(QuestList questName, QuestDictionary questDictionary)
        {

            this.isCompleted = false;
            this.isActive = false;
        }
        #endregion

        #region Methods
        //Methods.
        public bool CheckQuestCompleted(Town theTown)
        {
            bool isCompete = false;



            return isCompete;
        }

        #region Getters and Setters
        //Getters and Setters.
        public bool GetIsCompleted()
        {
            return this.isCompleted;
        }
        
        public void SetIsCompleted(bool isComplete)
        {
            this.isCompleted = isComplete;
        }

        public bool GetIsActive()
        {
            return this.isActive;
        }

        public void SetIsActive(bool isActive)
        {
            this.isActive = isActive;
        }

        public QuestList GetName()
        {
            return this.name;
        }

        public void SetName(QuestList questName)
        {
            this.name = questName;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void SetDescription(string newDescription)
        {
            this.description = newDescription;
        }
        #endregion
        #endregion
    }
}

#region Members
//Members.

#endregion

#region Constructors
//Constructors.
#endregion

#region Methods
//Methods.

#region Getters and Setters
//Getters and Setters.
#endregion
#endregion