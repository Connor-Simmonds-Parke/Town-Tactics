/*
 * File: ItemChest.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Chest equipment. Affects the character's stats when equipped.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemChest : Item
    {
        //Members.
        private ChestList itemName;

        //Chest Item Descriptions.
        private readonly string LEATHER_VEST = "A leather vest that offers minimal protection but enhanced flexibility. Increases Dexterity by 1";
        private readonly string CLOTH_ROBES = "A robe made of cloth and imbued to increase the wearer's magic affinity. Increases Magic by 1";

        //Chest Item Values.
        private readonly CharacterStat LEATHER_VEST_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat CLOTH_ROBES_VALUE = new CharacterStat(1, StatsList.Magic);

        //Constructors.
        public ItemChest()
        {
            this.itemName = ChestList.LeatherVest;
            UpdateItem();
        }

        public ItemChest(ChestList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == ChestList.LeatherVest)
            {
                base.SetItemDescription(LEATHER_VEST);
                base.SetItemValue(LEATHER_VEST_VALUE);
            }
            else if (this.itemName == ChestList.ClothRobes)
            {
                base.SetItemDescription(CLOTH_ROBES);
                base.SetItemValue(CLOTH_ROBES_VALUE);
            }
        }

        //Getters and Setters.
        public ChestList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(ChestList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
