/*
 * File: MissionDictionary.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-04-15
 * 
 * Purpose: Holds all the information for every mission. To be loaded at the start of the game and used as reference. 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class MissionDictionary
    {
        #region Members
        //Members.
        private Dictionary<MissionList, string> description;
        private Dictionary<MissionList, int> maxPeople;
        private Dictionary<MissionList, int> minPeople;
        private Dictionary<MissionList, List<KeyValuePair<ResourceList, int>>> resourceRewards;
        private Dictionary<MissionList, List<Item>> itemRewards;
        private Dictionary<MissionList, CharacterStats> statRequirements;
        private Dictionary<MissionList, double> baseChance;
        private Dictionary<MissionList, int> duration;
        private Dictionary<MissionList, int> availability;

        //Mission Descriptions.
        private readonly string TOWN_PATROL = "A boring job, but someone has to do it.";
        private readonly string SCOUTING = "Information is key. It's always wise to keep someone on lookout for potential threats and opportunities.";
        private readonly string LISTENING_TO_WHISPERS = "A keen ear here, some nudges there. Let's see what those too drunk or careless have to say.";
        private readonly string LOCAL_BANDITS = "The campsite of a group of local bandits has been discovered. Time to round them up.";

        //Mission Max Characters.
        private readonly int TOWN_PATROL_MAX = 2;
        private readonly int SCOUTING_MAX = 1;
        private readonly int LISTENING_TO_WHISPERS_MAX = 1;
        private readonly int LOCAL_BANDITS_MAX = 3;

        //Mission Min Characters.
        private readonly int TOWN_PATROL_MIN = 1;
        private readonly int SCOUTING_MIN = 1;
        private readonly int LISTENING_TO_WHISPERS_MIN = 1;
        private readonly int LOCAL_BANDITS_MIN = 2;

        //Mission Resource Rewards.

        //Town Patrol Mission Resource Rewards.
        private readonly ResourceList TOWN_PATROL_RESOURCE1 = ResourceList.Gold;
        private readonly int TOWN_PATROL_REWARD1 = 100;

        //Scouting Mission Resource Rewards.
        private readonly ResourceList SCOUTING_RESOURCE1 = ResourceList.Food;
        private readonly int SCOUTING_REWARD1 = 20;

        //Listening To Whispers Mission Resource Rewards.
        private readonly ResourceList LISTENING_TO_WHISPERS_RESOURCE1 = ResourceList.Gold;
        private readonly int LISTENING_TO_WHISPERS_REWARD1 = 25;

        //Local Bandits Mission Resource Rewards.
        private readonly ResourceList LOCAL_BANDITS_RESOURCE1 = ResourceList.Gold;
        private readonly int LOCAL_BANDITS_REWARD1 = 150;

        private readonly ResourceList LOCAL_BANDITS_RESOURCE2 = ResourceList.Stone;
        private readonly int LOCAL_BANDITS_REWARD2 = 25;

        private readonly ResourceList LOCAL_BANDITS_RESOURCE3 = ResourceList.Wood;
        private readonly int LOCAL_BANDITS_REWARD3 = 50;

        private readonly ResourceList LOCAL_BANDITS_RESOURCE4 = ResourceList.Food;
        private readonly int LOCAL_BANDITS_REWARD4 = 50;

        //Mission Item Rewards.

        //Town Patrol Mission Item Rewards.
        //None.

        //Scouting Mission Item Rewards.
        //None.

        //Listening To Whispers Mission Item Rewards.
        private readonly ToolList LISTENING_TO_WHISPERS_ITEM1 = ToolList.MagicCharm;

        //Local Bandits Mission Item Rewards.
        private readonly ToolList LOCAL_BANDITS_ITEM1 = ToolList.Daggers;
        private readonly ToolList LOCAL_BANDITS_ITEM2 = ToolList.ShortSword;
        private readonly ChestList LOCAL_BANDITS_ITEM3 = ChestList.LeatherVest;
        private readonly HandsList LOCAL_BANDITS_ITEM4 = HandsList.LeatherGloves;

        //Mission Stat Requirements.
        private readonly CharacterStats TOWN_PATROL_STATS = new CharacterStats(15, 5, 15, 10, 10);
        private readonly CharacterStats SCOUTING_STATS = new CharacterStats(5, 5, 5, 10, 10);
        private readonly CharacterStats LISTENING_TO_WHISPERS_STATS = new CharacterStats(3, 5, 10, 5, 10);
        private readonly CharacterStats LOCAL_BANDITS_STATS = new CharacterStats(30, 20, 15, 20, 10);

        //Mission Base Chance.
        private readonly double TOWN_PATROL_BASE = 15.0;
        private readonly double SCOUTING_BASE = 20.0;
        private readonly double LISTENING_TO_WHISPERS_BASE = 15.0;
        private readonly double LOCAL_BANDITS_BASE = 10.0;

        //Mission Duration.
        private readonly int TOWN_PATROL_DURATION = 1;
        private readonly int SCOUTING_DURATION = 2;
        private readonly int LISTENING_TO_WHISPERS_DURATION = 3;
        private readonly int LOCAL_BANDITS_DURATION = 3;

        //Mission Availability.
        private readonly int TOWN_PATROL_AVAILABLE = 8;
        private readonly int SCOUTING_AVAILABLE = 8;
        private readonly int LISTENING_TO_WHISPERS_AVAILABLE = 4;
        private readonly int LOCAL_BANDITS_AVAILABLE = 6;
        #endregion

        #region Constructors
        //Constructors.
        public MissionDictionary()
        {
            //Initialize Members.
            description = new Dictionary<MissionList, string>();
            maxPeople = new Dictionary<MissionList, int>();
            minPeople = new Dictionary<MissionList, int>();
            resourceRewards = new Dictionary<MissionList, List<KeyValuePair<ResourceList, int>>>();
            itemRewards = new Dictionary<MissionList, List<Item>>();
            statRequirements = new Dictionary<MissionList, CharacterStats>();
            baseChance = new Dictionary<MissionList, double>();
            duration = new Dictionary<MissionList, int>();
            availability = new Dictionary<MissionList, int>();

            List<KeyValuePair<ResourceList, int>> resourceList;
            List<Item> itemList;

            //Add Mission Descriptions to Dictionary.
            this.description.Add(MissionList.TownPatrol, TOWN_PATROL);
            this.description.Add(MissionList.Scouting, SCOUTING);
            this.description.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS);
            this.description.Add(MissionList.LocalBandits, LOCAL_BANDITS);

            //Add Mission Max Characters to Dictionary.
            this.maxPeople.Add(MissionList.TownPatrol, TOWN_PATROL_MAX);
            this.maxPeople.Add(MissionList.Scouting, SCOUTING_MAX);
            this.maxPeople.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_MAX);
            this.maxPeople.Add(MissionList.LocalBandits, LOCAL_BANDITS_MAX);

            //Add Mission Min Characters to Dictionary.
            this.minPeople.Add(MissionList.TownPatrol, TOWN_PATROL_MIN);
            this.minPeople.Add(MissionList.Scouting, SCOUTING_MIN);
            this.minPeople.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_MIN);
            this.minPeople.Add(MissionList.LocalBandits, LOCAL_BANDITS_MIN);

            //Add Mission Resource Rewards to Dictionary.

            //Town Patrol Mission Resource Rewards.
            resourceList = new List<KeyValuePair<ResourceList, int>>();

            resourceList.Add(new KeyValuePair<ResourceList, int>(TOWN_PATROL_RESOURCE1, TOWN_PATROL_REWARD1));

            resourceRewards.Add(MissionList.TownPatrol, resourceList);

            //Scouting Mission Resource Rewards.
            resourceList = new List<KeyValuePair<ResourceList, int>>();

            resourceList.Add(new KeyValuePair<ResourceList, int>(SCOUTING_RESOURCE1, SCOUTING_REWARD1));

            resourceRewards.Add(MissionList.Scouting, resourceList);

            //Listening To Whispers Mission Resource Rewards.
            resourceList = new List<KeyValuePair<ResourceList, int>>();

            resourceList.Add(new KeyValuePair<ResourceList, int>(LISTENING_TO_WHISPERS_RESOURCE1, LISTENING_TO_WHISPERS_REWARD1));

            resourceRewards.Add(MissionList.ListeningToWhispers, resourceList);

            //Local Bandits Mission Resource Rewards.
            resourceList = new List<KeyValuePair<ResourceList, int>>();

            resourceList.Add(new KeyValuePair<ResourceList, int>(LOCAL_BANDITS_RESOURCE1, LOCAL_BANDITS_REWARD1));
            resourceList.Add(new KeyValuePair<ResourceList, int>(LOCAL_BANDITS_RESOURCE2, LOCAL_BANDITS_REWARD2));
            resourceList.Add(new KeyValuePair<ResourceList, int>(LOCAL_BANDITS_RESOURCE3, LOCAL_BANDITS_REWARD3));
            resourceList.Add(new KeyValuePair<ResourceList, int>(LOCAL_BANDITS_RESOURCE4, LOCAL_BANDITS_REWARD4));

            resourceRewards.Add(MissionList.LocalBandits, resourceList);

            //Add Mission Item Rewards to Dictionary.

            //Town Patrol Mission Item Rewards.
            //None.

            //Scouting Mission Item Rewards.
            //None.

            //Listening To Whispers Mission Item Rewards.
            itemList = new List<Item>();

            itemList.Add(new ItemTool(LISTENING_TO_WHISPERS_ITEM1));

            itemRewards.Add(MissionList.ListeningToWhispers, itemList);

            //Local Bandits Mission Item Rewards.
            itemList = new List<Item>();

            itemList.Add(new ItemTool(LOCAL_BANDITS_ITEM1));
            itemList.Add(new ItemTool(LOCAL_BANDITS_ITEM2));
            itemList.Add(new ItemChest(LOCAL_BANDITS_ITEM3));
            itemList.Add(new ItemHands(LOCAL_BANDITS_ITEM4));

            itemRewards.Add(MissionList.LocalBandits, itemList);

            //Add Mission Stat Requirements to Dictionary.
            statRequirements.Add(MissionList.TownPatrol, TOWN_PATROL_STATS);
            statRequirements.Add(MissionList.Scouting, SCOUTING_STATS);
            statRequirements.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_STATS);
            statRequirements.Add(MissionList.LocalBandits, LOCAL_BANDITS_STATS);

            //Add Mission Base Chance to Dictionary.
            baseChance.Add(MissionList.TownPatrol, TOWN_PATROL_BASE);
            baseChance.Add(MissionList.Scouting, SCOUTING_BASE);
            baseChance.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_BASE);
            baseChance.Add(MissionList.LocalBandits, LOCAL_BANDITS_BASE);

            //Add Mission Duration to Dictionary.
            duration.Add(MissionList.TownPatrol, TOWN_PATROL_DURATION);
            duration.Add(MissionList.Scouting, SCOUTING_DURATION);
            duration.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_DURATION);
            duration.Add(MissionList.LocalBandits, LOCAL_BANDITS_DURATION);

            //Add Mission Availability to Dictionary.
            availability.Add(MissionList.TownPatrol, TOWN_PATROL_AVAILABLE);
            availability.Add(MissionList.Scouting, SCOUTING_AVAILABLE);
            availability.Add(MissionList.ListeningToWhispers, LISTENING_TO_WHISPERS_AVAILABLE);
            availability.Add(MissionList.LocalBandits, LOCAL_BANDITS_AVAILABLE);

        }
        #endregion

        #region Methods
        //Methods.

        #region Getters and Setters
        //Getters and Setters.
        public string GetDescription(MissionList missionName)
        {
            return this.description[missionName];
        }

        public int GetMaxPeople(MissionList missionName)
        {
            return this.maxPeople[missionName];
        }

        public int GetMinPeople(MissionList missionName)
        {
            return this.minPeople[missionName];
        }

        public List<KeyValuePair<ResourceList, int>> GetResourceRewards(MissionList missionName)
        {
            return this.resourceRewards[missionName];
        }

        public List<Item> GetItemRewards(MissionList missionName)
        {
            List<Item> tempItemList = new List<Item>();

            if (itemRewards.ContainsKey(missionName))
            {
                tempItemList = itemRewards[missionName];
            }

            return tempItemList;
        }

        public CharacterStats GetStatRequirements(MissionList missionName)
        {
            return this.statRequirements[missionName];
        }

        public double GetBaseChance(MissionList missionName)
        {
            return this.baseChance[missionName];
        }

        public int GetDuration(MissionList missionName)
        {
            return this.duration[missionName];
        }

        public int GetAvailability(MissionList missionName)
        {
            return this.availability[missionName];
        }
        #endregion
        #endregion       
    }
}
