/*
 * File: Game.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-03-12
 * 
 * Purpose: Testing for the game's UI and mechanics.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.GameCode
{
    public class Game : MonoBehaviour
    {
        static Town mainTown = new Town();
        Dropdown ddlCharacters;
        Dropdown ddlMissions;
        Dropdown ddlBuildings;
        TMP_Text tmpBuildings;
        TMP_Text txtCharacterInfo;
        TMP_Text tmpMission;
        TMP_Text tmpTurn;
        TMP_Text tmpInfo;
        Text txtFood;
        Text txtGold;
        Text txtWood;
        Text txtStone;
        static List<Button> buildingSlots;
        static List<Button> upgradeBtns;

        static int first = 0;

        /*static TMP_Text tmpToolTip;
        static RectTransform imgToolTipTransform;
        static GameObject imgToolTip;*/

        // Start is called before the first frame update
        void Start()
        {
            ddlCharacters = GameObject.Find("ddlCharacters").GetComponent<Dropdown>();
            ddlMissions = GameObject.Find("ddlMissions").GetComponent<Dropdown>();
            ddlBuildings = GameObject.Find("ddlBuildings").GetComponent<Dropdown>();
            txtCharacterInfo = GameObject.Find("txtCharacter").GetComponent<TMP_Text>();
            tmpMission = GameObject.Find("tmpMission").GetComponent<TMP_Text>();
            tmpBuildings = GameObject.Find("tmpBuildings").GetComponent<TMP_Text>();
            tmpInfo = GameObject.Find("tmpInfo").GetComponent<TMP_Text>();
            tmpTurn = GameObject.Find("tmpTurn").GetComponent<TMP_Text>();
            txtFood = GameObject.Find("txtFood").GetComponent<Text>();
            txtWood = GameObject.Find("txtWood").GetComponent<Text>();
            txtStone = GameObject.Find("txtStone").GetComponent<Text>();
            txtGold = GameObject.Find("txtGold").GetComponent<Text>();
            /*imgToolTip = GameObject.Find("imgToolTip").GetComponent<GameObject>();
            tmpToolTip = GameObject.Find("tmpToolTip").GetComponent<TMP_Text>();
            imgToolTipTransform = GameObject.Find("imgToolTip").GetComponent<RectTransform>();*/

            //ShowToolTip("Some Random Tool Tip Text");
            if (first == 0)
            {
                buildingSlots = new List<Button>();
                upgradeBtns = new List<Button>();

                foreach (Button btn in GameObject.Find("pnlBuildings").GetComponentsInChildren<Button>(true))
                {
                    if (btn.GetComponentInChildren<Text>() != null)
                    {
                        buildingSlots.Add(btn);
                    }
                    else
                    {
                        upgradeBtns.Add(btn);
                        btn.gameObject.SetActive(false);
                    }
                }
            }

            first++;
            UpdateResources();        
        }

        private void Awake()
        {
           
        }

        /*[RuntimeInitializeOnLoadMethod]
        public void Test()
        {
            
        }*/

        // Update is called once per frame
        void Update()
        {

        }

        public void AddCharacter()
        {
            for (int i = 0; i < 10; i++)
            {
                if (mainTown.characters[i] == null)
                {
                    mainTown.characters[i] = new Character(true);
                    ddlCharacters.options.Add(new Dropdown.OptionData() { text = mainTown.characters[i].GetName() });
                    i = 10;
                }
            }           
        }

        public void SelectCharacter()
        {
            int value = ddlCharacters.value;
            string selectedCharacter = ddlCharacters.options[value].text;

            for (int i = 0; i < 10; i++)
            {
                if (mainTown.characters[i] != null)
                {
                    if (mainTown.characters[i].GetName() == selectedCharacter)
                    {
                        txtCharacterInfo.text = mainTown.characters[i].GetName();
                        txtCharacterInfo.text += "\n" + mainTown.characters[i].GetRace().GetName().ToString();
                        txtCharacterInfo.text += "\n" + mainTown.characters[i].GetBody().GetGenderDescription();
                        txtCharacterInfo.text += "\n" + mainTown.characters[i].GetBody().ToString();
                        txtCharacterInfo.text += "\n\n" + mainTown.characters[i].GetStats().ToString();
                    }
                }
            }
        }

        public void SelectMission()
        {
            int value = ddlMissions.value;
            string selectedMission = ddlMissions.options[value].text;

            foreach (Mission mission in mainTown.availableMissions)
            {
                if (mission.GetName().ToString() == selectedMission)
                {
                    tmpMission.text = mission.GetName().ToString();
                    tmpMission.text += "\n\n" + mission.GetDescription();
                    tmpMission.text += "\n\nStat Requirements: ";
                    foreach (CharacterStat stat in mission.GetStatRequirements().GetStatsList())
                    {
                        tmpMission.text += stat.GetName() + "{" + stat.GetValue() + "}, ";
                    }
                    tmpMission.text += "\n\nMinmum|Maximum Characters: " + mission.GetMinPeople() + "|" + mission.GetMaxPeople();
                    tmpMission.text += "\n\nMission Length|Availability: " + mission.GetMissionDuration() + "|" + mission.GetMissionAvailability();
                }
            }
        }

        public void UpdateResources()
        {
            foreach (Resource resource in mainTown.resourceList)
            {
                if (resource.GetName() == ResourceList.Gold)
                {
                    txtGold.text = resource.GetValue().ToString();
                }
                else if (resource.GetName() == ResourceList.Wood)
                {
                    txtWood.text = resource.GetValue().ToString();
                }
                else if (resource.GetName() == ResourceList.Food)
                {
                    txtFood.text = resource.GetValue().ToString();
                }
                else if (resource.GetName() == ResourceList.Stone)
                {
                    txtStone.text = resource.GetValue().ToString();
                }
            }
        }

        public void GetAvailableMissions()
        {
            foreach (Mission mission in mainTown.availableMissions)
            {
                ddlMissions.options.Add(new Dropdown.OptionData() { text = mission.GetName().ToString() });
            }
        }

        public void SelectBuilding()
        {
            int value = ddlBuildings.value;
            string selectedBuilding = ddlBuildings.options[value].text;

            if (selectedBuilding == "Tavern")
            {
                BuildingTavern tempTavern = new BuildingTavern();

                tmpBuildings.text = tempTavern.GetName();
                tmpBuildings.text += "\n\n" + tempTavern.GetDescription();
                tmpBuildings.text += "\n\nCost: ";
                foreach(KeyValuePair<ResourceList, int> cost in tempTavern.GetCostsList(1))
                {
                    tmpBuildings.text += cost.Key.ToString() + "{" + cost.Value + "}, ";
                }
            }
        }

        public void BuildBuilding()
        {
            if (this.GetComponentInChildren<Text>().text != "Free Building Slot")
            {
                int value = ddlBuildings.value;
                string selectedBuilding = ddlBuildings.options[value].text;
                int buildingSlot = 0;
                int index = 0;
                bool done = false;

                foreach (Button btn in buildingSlots)
                {                 
                    if (done == false)
                    {
                        if (this.GetComponent<Button>() == btn)
                        {
                            buildingSlot += index;
                            done = true;
                        }
                        else
                        {
                            index += 1;
                        }
                    }
                }

                if (selectedBuilding == "Tavern")
                {
                    BuildingTavern tempTavern = new BuildingTavern();

                    if (mainTown.BuildBuilding(tempTavern, buildingSlot) == true)
                    {
                        this.GetComponentInChildren<Text>().text = tempTavern.GetName();
                        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Pictures/Tavern");
                        Debug.Log(buildingSlot + " " + selectedBuilding);                       
                        upgradeBtns[buildingSlot].gameObject.SetActive(true);

                        UpdateResources();
                    }
                }
            }
        }

        public void UpgradeBuilding()
        {
            int buildingSlot = 0;
            int index = 0;

            foreach (Button btn in upgradeBtns)
            {               
                if (this.GetComponent<Button>() == btn)
                {
                    buildingSlot = index;
                }
                else
                {
                    index += 1;
                }
            }

            if (mainTown.UpgradeBuilding(buildingSlot) == true)
            {
                buildingSlots[buildingSlot].GetComponentInChildren<Text>().text = mainTown.buildings[buildingSlot].GetCurrentBuilding().GetName();
                buildingSlots[buildingSlot].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Pictures/" + mainTown.buildings[buildingSlot].GetCurrentBuilding().GetPictureName());
                UpdateResources();

                if (mainTown.buildings[buildingSlot].GetCurrentBuilding().GetMaxLevel() == mainTown.buildings[buildingSlot].GetCurrentBuilding().GetLevel())
                {
                    upgradeBtns[buildingSlot].gameObject.SetActive(false);
                }
            }
        }

        public void AssignCharacter()
        {
            int value = ddlCharacters.value;
            string selectedCharacter = ddlCharacters.options[value].text;
            value = ddlMissions.value;
            string selectedMission = ddlMissions.options[value].text;

            Character character = new Character();
            Mission townMission = new Mission();

            for (int i = 0; i < 10; i++)
            {
                if (mainTown.characters[i] != null)
                {
                    if (mainTown.characters[i].GetName() == selectedCharacter)
                    {
                        character = mainTown.characters[i];
                    }
                }
            }
            
            foreach (Mission mission in mainTown.availableMissions)
            {
                if (mission.GetName().ToString() == selectedMission)
                {
                    townMission = mission;
                }
            }

            if (mainTown.AssignToMission(character, townMission))
            {
                tmpInfo.text = character.GetName() + " was assigned to " + townMission.GetName();
                tmpInfo.text += "\n" + townMission.GetPeopleOnMission().Count + " out of " + townMission.GetMaxPeople() + " positions assigned.";
            }

        }

        public void StartMission()
        {
            int value = ddlMissions.value;
            string selectedMission = ddlMissions.options[value].text;

            Mission townMission = new Mission();

            foreach (Mission mission in mainTown.availableMissions)
            {
                if (mission.GetName().ToString() == selectedMission)
                {
                    townMission = mission;                  
                }
            }

            if (mainTown.StartMission(townMission) == true)
            {
                tmpInfo.text = townMission.GetName() + " has started.\n";
                tmpInfo.text += "Mission will end in " + townMission.GetMissionDuration() + " days.";
                ddlMissions.options.Remove(ddlMissions.options[value]);
            }
            else
            {
                tmpInfo.text = "Mission not started";
            }
        }

        public void EndTurn()
        {
            string turnReport = mainTown.EndTurn();
            tmpInfo.text = turnReport;
            tmpTurn.text = "Turn: " + mainTown.GetTurn();
            UpdateResources();
        }

        /*public static void ShowToolTip(string toolTipString)
        {
            imgToolTip.SetActive(true);

            tmpToolTip.text = toolTipString;
            float textPaddingSize = 4f;
            Vector2 backgroundSize = new Vector2(tmpToolTip.preferredWidth + textPaddingSize * 2f, tmpToolTip.preferredHeight + textPaddingSize * 2f);
            imgToolTipTransform.sizeDelta = backgroundSize;
        }

        public static void HideToolTip()
        {
            imgToolTip.SetActive(false);
        }*/
    }
}

//Talk about the project and why it is interesting
//Slidedeck about nature and decions, polymorphism.
//Create a char, let them do something 

//Week 4 recording