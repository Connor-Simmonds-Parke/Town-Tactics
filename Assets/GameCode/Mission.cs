using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Mission
    {
        #region Members
        //Members.
        private MissionList name;
        private string description;

        private List<Character> peopleOnMission;
        private int maxPeople;
        private int minPeople;

        private List<KeyValuePair<ResourceList, int>> resourceRewards;
        private List<Item> itemRewards;

        private CharacterStats statRequirements;
        private double baseChance;

        private int missionDuration;
        private int missionAvailability;
        private int missionActive;

        private string missionReport;
        #endregion

        #region Constructors
        //Constructors.
        public Mission()
        {
            this.name = MissionList.TownPatrol;
            this.description = "Default Test Mission";

            this.peopleOnMission = new List<Character>();
            this.maxPeople = 3;
            this.minPeople = 1;

            this.resourceRewards = new List<KeyValuePair<ResourceList, int>>();
            this.itemRewards = new List<Item>();

            this.statRequirements = new CharacterStats(15, 15, 15, 15, 15);
            this.baseChance = 15.0;

            this.missionDuration = 2;
            this.missionAvailability = 10;
            this.missionActive = 0;

            this.missionReport = "";
        }
        
        public Mission(MissionList missionName, MissionDictionary missionDictionary)
        {
            this.name = missionName;
            this.description = missionDictionary.GetDescription(missionName);

            this.peopleOnMission = new List<Character>();
            this.maxPeople = missionDictionary.GetMaxPeople(missionName);
            this.minPeople = missionDictionary.GetMinPeople(missionName);

            this.resourceRewards = missionDictionary.GetResourceRewards(missionName);
            this.itemRewards = missionDictionary.GetItemRewards(missionName);

            this.statRequirements = missionDictionary.GetStatRequirements(missionName);
            this.baseChance = missionDictionary.GetBaseChance(missionName);

            this.missionDuration = missionDictionary.GetDuration(missionName);
            this.missionAvailability = missionDictionary.GetAvailability(missionName);
            this.missionActive = 0;

            this.missionReport = "";
        }
        #endregion

        #region Methods
        //Methods.
        public bool AssignCharacter(Character characterToAdd)
        {
            bool wasAssigned = false;

            if (this.peopleOnMission.Count < this.maxPeople)
            {
                peopleOnMission.Add(characterToAdd);
                wasAssigned = true;
            }

            return wasAssigned;
        }

        public bool RemoveCharacter(Character characterToRemove)
        {
            bool wasRemoved = false;

            foreach (Character character in peopleOnMission)
            {
                if (character == characterToRemove)
                {
                    peopleOnMission.Remove(character);
                    wasRemoved = true;
                }
            }

            return wasRemoved;
        }

        public bool CheckMissionSuccess()
        {
            bool success = false;
            double successChance;
            double requirementLeft = 0;
            double requirementTotal = 0;
            double roll;

            Random randomRoll = new Random();
            CharacterStats totalStats = new CharacterStats(0, 0, 0, 0, 0);

            foreach (Character character in peopleOnMission)
            {
                totalStats.ModifyAllStats(character.GetStats());
            }

            foreach (CharacterStat requirementStat in statRequirements.GetStatsList())
            {
                requirementTotal += requirementStat.GetValue();

                foreach (CharacterStat stat in totalStats.GetStatsList())
                {
                    if (stat.GetName() == requirementStat.GetName())
                    {
                        requirementStat.ModifyValue(stat.GetValue() * -1);
                    }
                }

                requirementLeft += requirementStat.GetValue();
            }

            successChance = (requirementLeft / requirementTotal) * 100;

            if (successChance <= 0.00)
            {
                successChance = 0.00;
            }
            else if (successChance <= 5.00)
            {
                successChance = 25.00;
            }
            else if (successChance <= 15.00)
            {
                successChance = 50.00;
            }
            else if (successChance <= 30.00)
            {
                successChance = 70.00;
            }
            else if (successChance <= 45.00)
            {
                successChance = 90.00;
            }
            else
            {
                successChance = 100.00;
            }

            successChance = 100.00 + this.baseChance - successChance;
            roll = randomRoll.NextDouble() * 100;

            this.missionReport = "\n\nSuccess Chance: " + successChance;
            this.missionReport += "\nSuccess Roll  : " + roll + "\n\n";

            if (roll <= successChance)
            {
                success = true;

                this.missionReport += this.name + " was a success!\n";
                foreach (KeyValuePair<ResourceList, int> resource in this.resourceRewards)
                {
                    this.missionReport += "Resources Gained: " + resource.Key.ToString() + "{" + resource.Value + "} ";
                }
            }
            else
            {
                this.missionReport += this.name + " was a failure!";
            }

            return success;
        }

        public bool TurnEnd()
        {
            bool missionDone = false;

            missionActive += 1;

            if (missionActive >= missionDuration)
            {
                missionDone = true;
            }

            return missionDone;
        }

        #region Getters and Setters
        //Getters and Setters.     
        public MissionList GetName()
        {
            return this.name;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public List<Character> GetPeopleOnMission()
        {
            return this.peopleOnMission;
        }

        public int GetMaxPeople()
        {
            return this.maxPeople;
        }

        public int GetMinPeople()
        {
            return this.minPeople;
        }

        public List<KeyValuePair<ResourceList, int>> GetResourceRewards()
        {
            return this.resourceRewards;
        }

        public List<Item> GetItemRewards()
        {
            return this.itemRewards;
        }

        public CharacterStats GetStatRequirements()
        {
            return this.statRequirements;
        }

        public double GetBaseChance()
        {
            return this.baseChance;
        }

        public int GetMissionDuration()
        {
            return this.missionDuration;
        }

        public int GetMissionAvailability()
        {
            return this.missionAvailability;
        }

        public int GetMissionActive()
        {
            return this.missionActive;
        }

        public string GetMissionReport()
        {
            return this.missionReport;
        }
        #endregion
        #endregion
    }
}