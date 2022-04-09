/*
 * File: GameScript.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-03-29
 * 
 * Purpose: The game's user interface interaction and game mechanics.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Assets.GameCode
{
    public class GameScript : MonoBehaviour
    {
        #region Members
        //Static and Public Members.
        static Town town = new Town();     
        static bool isFirstStart = true;
        static int i = 0;

        static Text txtFood;
        static Text txtWood;
        static Text txtGold;
        static Text txtStone;
        static TMP_Text tmpTurn;

        public GameObject pnlCharacterList;
        public GameObject pnlBuildingList;
        public GameObject pnlMissionList;
        public GameObject pnlCharacterInfo;

        public Button characterButton;
        public Button buildingButton;
        public Button missionButton;

        public List<GameObject> sideBarPanels;
        #endregion
        #region Methods
        // Start is called before the first frame update
        void Start()
        {
            
            if (isFirstStart == true)
            {
                txtFood = GameObject.Find("txtFood").GetComponent<Text>();
                txtWood = GameObject.Find("txtWood").GetComponent<Text>();
                txtStone = GameObject.Find("txtStone").GetComponent<Text>();
                txtGold = GameObject.Find("txtGold").GetComponent<Text>();
                tmpTurn = GameObject.Find("tmpTurn").GetComponent<TMP_Text>();

                tmpTurn.text = "Week 1";

                town.characters[0] = (new Character(true));
                town.characters[1] = (new Character(true));
                town.characters[2] = (new Character(true));

                town.buildings[0].BuildBuilding(new BuildingTavern());

                for (int c = 0; c < town.buildings.Length; c++)
                {
                    List<TMP_Text> buttonText = new List<TMP_Text>(buildingButton.GetComponentsInChildren<TMP_Text>());

                    buttonText[3].text = (c + 1).ToString();

                    if (c == 0)
                    {
                        buttonText[0].text = town.buildings[c].GetCurrentBuilding().GetName();
                        buttonText[1].text = "Level " + town.buildings[c].GetCurrentBuilding().GetLevel();
                    }
                    else
                    {
                        buttonText[0].text = "Empty Building Slot";
                        buttonText[1].text = "";
                    }

                    Button newBuildingButton = Instantiate(buildingButton);
                    newBuildingButton.transform.SetParent(pnlBuildingList.transform, false);
                    newBuildingButton.onClick.AddListener(BuildingClicked);
                }


                foreach (Mission mission in town.availableMissions)
                {
                    List<TMP_Text> buttonText = new List<TMP_Text>(missionButton.GetComponentsInChildren<TMP_Text>());

                    buttonText[0].text = mission.GetName().ToString();

                    Button newMissionButton = Instantiate(missionButton);
                    newMissionButton.transform.SetParent(pnlMissionList.transform, false);
                }

                UpdateResources();

                isFirstStart = false;
            }
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OpenCharactersMenu()
        {
            bool wasOpened = false;

            if (sideBarPanels[0].activeSelf == true)
            {
                wasOpened = true;
            }

            foreach (GameObject panel in sideBarPanels)
            {
                panel.SetActive(false);
            }

            if (wasOpened == false)
            {
                sideBarPanels[0].SetActive(true);
                pnlCharacterInfo.SetActive(false);
            }


            i = 0;

            Button[] objects = new Button[GameObject.Find("pnlCharacterList").GetComponentsInChildren<Button>().Length];
            foreach (Button btn in GameObject.Find("pnlCharacterList").GetComponentsInChildren<Button>())
            {
                objects[i] = btn;
                i++;
            }
          
            for (int c = 0; c < objects.Length; c++)
            {
                Destroy(objects[c].gameObject);
            }

            i = 0;


            foreach (Character character in town.characters)
            {
                if (character != null)
                {
                    if (i < 14)
                    {
                        List<TMP_Text> buttonText = new List<TMP_Text>(characterButton.GetComponentsInChildren<TMP_Text>());

                        buttonText[0].text = character.GetName();
                        buttonText[1].text = character.GetRace().GetName().ToString();
                        buttonText[2].text = "Level " + character.GetLevel().ToString();

                        Button newCharacterButton = Instantiate(characterButton);
                        newCharacterButton.transform.SetParent(pnlCharacterList.transform, false);
                        newCharacterButton.onClick.AddListener(CharacterClicked);

                        i++;
                    }
                }
            }
        }

        public void OpenBuildingsMenu()
        {
            foreach (GameObject panel in sideBarPanels)
            {
                panel.SetActive(false);
            }

            sideBarPanels[1].SetActive(true);
        }

        public void OpenMissionsMenu()
        {
            foreach (GameObject panel in sideBarPanels)
            {
                panel.SetActive(false);
            }

            sideBarPanels[2].SetActive(true);
        }

        public void OpenQuestsMenu()
        {
            foreach (GameObject panel in sideBarPanels)
            {
                panel.SetActive(false);
            }

            sideBarPanels[3].SetActive(true);
        }

        void CharacterClicked()
        {
            List<TMP_Text> characterInfo = new List<TMP_Text>(pnlCharacterInfo.GetComponentsInChildren<TMP_Text>());
            TMP_Text character = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>();

            foreach (Character chara in town.characters)
            {
                if (chara != null)
                {
                    if (chara.GetName() == character.text)
                    {
                        characterInfo[0].text = chara.GetName();
                        characterInfo[3].text = chara.GetBody().ToString();
                        characterInfo[4].text = "";
                        characterInfo[10].text = "";
                        foreach (CharacterStat stat in chara.GetStats().GetStatsList())
                        {
                            characterInfo[10].text += stat.GetValue() + "\n";
                            characterInfo[4].text += stat.GetName() + "\n";
                        }
                        characterInfo[11].text = "";
                        characterInfo[11].text += chara.GetEquipment().GetHeadItem().GetItemName() + "\n";
                        characterInfo[11].text += chara.GetEquipment().GetChestItem().GetItemName() + "\n";
                        characterInfo[11].text += chara.GetEquipment().GetHandsItem().GetItemName() + "\n";
                        characterInfo[11].text += chara.GetEquipment().GetLegsItem().GetItemName() + "\n";
                        characterInfo[11].text += chara.GetEquipment().GetFeetItem().GetItemName() + "\n";
                        characterInfo[11].text += chara.GetEquipment().GetToolItem().GetItemName() + "\n";
                        characterInfo[8].text = "";
                        foreach (Trait trait in chara.GetTraits())
                        {
                            characterInfo[8].text += trait.GetTrait().ToString() + " ";
                        }
                        characterInfo[9].text = "";
                        foreach (CharacterBuff buff in chara.GetBuffs())
                        {
                            characterInfo[9].text += buff.ToString();
                        }
                    }
                }
            }

            pnlCharacterInfo.SetActive(true);
        }

        void BuildingClicked()
        {
            List<TMP_Text> buildingInfo = new List<TMP_Text>(pnlBuildingList.GetComponentsInChildren<TMP_Text>());
            TMP_Text building = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>();
            int.TryParse(building.GetComponentsInChildren<TMP_Text>()[3].text, out int buildingSlot);
            Debug.Log(buildingSlot);

        }

        public void EndTurn()
        {
            town.EndTurn();
            tmpTurn.text = "Week " + town.GetTurn();
            UpdateResources();
        }

        public void UpdateResources()
        {
            foreach (Resource resource in town.resourceList)
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
        #endregion
    }
}
