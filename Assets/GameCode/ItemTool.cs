/*
 * File: ItemTool.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Tool or weapon equipment. Affects the character's stats when equipped.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemTool : Item
    {
        //Members.
        private ToolList itemName;

        //Legs Item Descriptions.
        private readonly string DAGGERS = "A pair of iron daggers for quick, close, and dirty work. Increases Dexterity by 1";
        private readonly string SHORT_SWORD = "An iron sword short enough to be agile and deadly. Increases Strength by 1";
        private readonly string STAFF = "A wooden staff imbued to increase the weilder's magic affinity. Increases Magic by 1";
        private readonly string MAGIC_CHARM = "A charm said to make even the most uncouth approchable. Increase Charisma by 1";

        //Legs Item Values.
        private readonly CharacterStat DAGGERS_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat SHORT_SWORD_VALUE = new CharacterStat(1, StatsList.Strength);
        private readonly CharacterStat STAFF_VALUE = new CharacterStat(1, StatsList.Magic);
        private readonly CharacterStat MAGIC_CHARM_VALUE = new CharacterStat(1, StatsList.Charisma);

        //Constructors.
        public ItemTool()
        {
            this.itemName = ToolList.Daggers;
            UpdateItem();
        }

        public ItemTool(ToolList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == ToolList.Daggers)
            {
                base.SetItemDescription(DAGGERS);
                base.SetItemValue(DAGGERS_VALUE);
            }
            else if (this.itemName == ToolList.ShortSword)
            {
                base.SetItemDescription(SHORT_SWORD);
                base.SetItemValue(SHORT_SWORD_VALUE);
            }
            else if (this.itemName == ToolList.Staff)
            {
                base.SetItemDescription(STAFF);
                base.SetItemValue(STAFF_VALUE);
            }
            else if (this.itemName == ToolList.MagicCharm)
            {
                base.SetItemDescription(MAGIC_CHARM);
                base.SetItemValue(MAGIC_CHARM_VALUE);
            }
        }

        //Getters and Setters.
        public ToolList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(ToolList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
