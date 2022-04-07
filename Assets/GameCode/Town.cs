using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Town
    {
        #region Members
        //Members.
        public BuildingSlot[] buildings;
        public Character[] characters;

        int buildingSlots;
        private int turn;

        private readonly int CHARACTER_LIMIT = 10;
        private readonly int BUILDING_SLOTS = 5;

        Resource gold;
        Resource stone;
        Resource wood;
        Resource food;
        public List<Resource> resourceList;

        public List<Mission> availableMissions;
        public List<Mission> activeMissions;

        private List<Quest> quests;

        MissionDictionary missionDictionary;
        #endregion

        #region Constructors
        //Constructors.
        public Town()
        {
            buildings = new BuildingSlot[BUILDING_SLOTS];
            characters = new Character[CHARACTER_LIMIT];

            resourceList = new List<Resource>();

            availableMissions = new List<Mission>();
            activeMissions = new List<Mission>();

            missionDictionary = new MissionDictionary();

            for (int counter = 0; counter < buildings.Length; counter++)
            {
                buildings[counter] = new BuildingSlot();
            }

            gold = new Resource(ResourceList.Gold, 1000, 20);
            stone = new Resource(ResourceList.Stone, 1000, 20);
            wood = new Resource(ResourceList.Wood, 1000, 20);
            food = new Resource(ResourceList.Food, 1000, 20);

            resourceList.Add(gold);
            resourceList.Add(stone);
            resourceList.Add(wood);
            resourceList.Add(food);

            availableMissions.Add(new Mission(MissionList.TownPatrol, missionDictionary));
            availableMissions.Add(new Mission(MissionList.ListeningToWhispers, missionDictionary));
            availableMissions.Add(new Mission(MissionList.Scouting, missionDictionary));
            availableMissions.Add(new Mission(MissionList.LocalBandits, missionDictionary));

            turn = 1;
        }
        #endregion

        #region Methods
        //Methods.
        public bool BuildBuilding(Building newBuilding, int buildingSlot)
        {
            bool isBuilt = false;

            BuildingSlot slotToBuild = buildings.ElementAt(buildingSlot);

            if (slotToBuild.CheckIfEmpty() == true)
            {
                if (CheckBuildingCosts(newBuilding, buildingSlot) == true)
                {
                    PayBuildingCosts(newBuilding, buildingSlot);
                    slotToBuild.BuildBuilding(newBuilding);
                    isBuilt = true;
                }
            }

            return isBuilt;
        }

        public bool UpgradeBuilding(int buildingSlot)
        {
            bool isUpgraded = false;

            BuildingSlot slotToBuild = buildings.ElementAt(buildingSlot);

            if (slotToBuild.CheckIfEmpty() == false)
            {
                if (CheckBuildingCosts(slotToBuild.GetCurrentBuilding(), buildingSlot) == true)
                {
                    PayBuildingCosts(slotToBuild.GetCurrentBuilding(), buildingSlot);
                    slotToBuild.UpgradeBuilding();
                    isUpgraded = true;
                }
            }

            return isUpgraded;
        }

        private bool CheckBuildingCosts(Building building, int buildingSlot)
        {
            List<KeyValuePair<ResourceList, int>> costsList;
            bool canPay = true;

            int buildingLevel = CheckBuildingLevel(building, buildingSlot);
            costsList = building.GetCostsList(buildingLevel);

            foreach (KeyValuePair<ResourceList, int> cost in costsList)
            {
                foreach (Resource resource in resourceList)
                {
                    if (cost.Key == resource.GetName())
                    {
                        if (resource.GetValue() < cost.Value)
                        {
                            canPay = false;
                        }
                    }
                }
            }

            return canPay;
        }

        private int CheckBuildingLevel(Building building, int buildingSlot)
        {
            int buildingLevel = 0;

            if (buildings[buildingSlot].CheckIfEmpty() == true)
            {
                buildingLevel = 1;
            }
            else if (building.GetLevel() < building.GetMaxLevel())
            {
                buildingLevel = building.GetLevel() + 1;
            }

            return buildingLevel;
        }

        private void PayBuildingCosts(Building building, int buildingSlot)
        {
            List<KeyValuePair<ResourceList, int>> costsList;

            int buildingLevel = CheckBuildingLevel(building, buildingSlot);
            costsList = building.GetCostsList(buildingLevel);

            foreach (KeyValuePair<ResourceList, int> cost in costsList)
            {
                foreach (Resource resource in resourceList)
                {
                    if (cost.Key == resource.GetName())
                    {
                        resource.ChangeValue(cost.Value * -1);
                    }
                }
            }
        }

        public bool RemoveBuilding(int buildingSlot)
        {
            bool buildingRemoved = false;

            if (buildings[buildingSlot].CheckIfEmpty() == false)
            {
                buildings[buildingSlot] = new BuildingSlot();
                buildingRemoved = true;
            }

            return buildingRemoved;
        }

        public bool AssignToMission(Character character, Mission mission)
        {
            bool wasAssigned = false;

            if(mission.AssignCharacter(character) == true)
            {
                wasAssigned = true;
            }

            return wasAssigned;
        }

        public bool StartMission(Mission mission)
        {
            bool wasStarted = false;

            if (mission.GetPeopleOnMission().Count >= mission.GetMinPeople())
            {
                activeMissions.Add(mission);
                availableMissions.Remove(mission);
                wasStarted = true;
            }

            return wasStarted;
        }

        public string EndTurn()
        {
            string turnReport = "";
            List<Mission> removeMissions = new List<Mission>();

            this.turn += 1;

            foreach (Resource resource in resourceList)
            {
                resource.TurnEnd();
            }

            foreach (Mission mission in activeMissions)
            {
                if (mission.TurnEnd() == true)
                {
                    if (mission.CheckMissionSuccess() == true)
                    {
                        foreach (KeyValuePair<ResourceList, int> resource in mission.GetResourceRewards())
                        {
                            foreach (Resource townResource in this.resourceList)
                            {
                                if (resource.Key == townResource.GetName())
                                {
                                    townResource.ChangeValue(resource.Value);
                                }
                            }
                        }
                    }

                    turnReport += mission.GetMissionReport();
                    removeMissions.Add(mission);                  
                }
            }

            foreach (Mission mission in removeMissions)
            {
                this.activeMissions.Remove(mission);
            }

            return turnReport;
        }

        #region Getters and Setters
        //Getters and Setters.
        public int GetTurn()
        {
            return this.turn;
        }

        public List<Quest> GetQuests()
        {
            return this.quests;
        }
        #endregion
        #endregion
    }
}
