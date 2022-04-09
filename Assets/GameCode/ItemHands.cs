/*
 * File: ItemHands.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Hands equipment. Affects the character's stats when equipped.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemHands : Item
    {
        //Members.
        private HandsList itemName;

        //Legs Item Descriptions.
        private readonly string LEATHER_GLOVES = "A pair of leather gloves that offers minimal protection but enhanced flexibility. Increases Dexterity by 1";
        private readonly string CLOTH_GLOVES = "A pair of gloves made of cloth and imbued to increase the wearer's magic affinity. Increases Magic by 1";

        //Legs Item Values.
        private readonly CharacterStat LEATHER_GLOVES_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat CLOTH_GLOVES_VALUE = new CharacterStat(1, StatsList.Magic);

        //Constructors.
        public ItemHands()
        {
            this.itemName = HandsList.LeatherGloves;
            UpdateItem();
        }

        public ItemHands(HandsList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == HandsList.LeatherGloves)
            {
                base.SetItemDescription(LEATHER_GLOVES);
                base.SetItemValue(LEATHER_GLOVES_VALUE);
            }
            else if (this.itemName == HandsList.ClothGloves)
            {
                base.SetItemDescription(CLOTH_GLOVES);
                base.SetItemValue(CLOTH_GLOVES_VALUE);
            }
        }

        //Getters and Setters.
        public HandsList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(HandsList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
