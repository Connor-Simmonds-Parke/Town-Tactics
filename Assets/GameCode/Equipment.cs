/*
 * File: Equipment.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Holds a number of Item objects that represents a character's equipped items. Ensures only the correct items 
 * can be equipped and changed.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Equipment
    {
        #region Members
        //Members.
        private ItemChest chestItem;
        private ItemFeet feetItem;
        private ItemHands handsItem;
        private ItemHead headItem;
        private ItemLegs legItem;
        private ItemTool toolItem;
        #endregion

        #region Constructors
        //Constructors.
        public Equipment()
        {
            this.chestItem = new ItemChest();
            this.feetItem = new ItemFeet();
            this.handsItem = new ItemHands();
            this.headItem = new ItemHead();
            this.legItem = new ItemLegs();
            this.toolItem = new ItemTool();
        }
        #endregion

        #region Methods
        //Methods.
        #region Item Change Methods
        public void ChangeItem(Item itemToChange)
        {
            if (itemToChange.GetType() == chestItem.GetType())
            {
                this.chestItem = itemToChange as ItemChest;
            }
            else if (itemToChange.GetType() == feetItem.GetType())
            {
                this.feetItem = itemToChange as ItemFeet;
            }
            else if (itemToChange.GetType() == handsItem.GetType())
            {
                this.handsItem = itemToChange as ItemHands;
            }
            else if (itemToChange.GetType() == headItem.GetType())
            {
                this.headItem = itemToChange as ItemHead;
            }
            else if (itemToChange.GetType() == legItem.GetType())
            {
                this.legItem = itemToChange as ItemLegs;
            }
            else if (itemToChange.GetType() == toolItem.GetType())
            {
                this.toolItem = itemToChange as ItemTool;
            }
        }

        public Item InvertItemValue(Item itemToChange)
        {
            Item oldItem = itemToChange;

            if (itemToChange.GetType() == chestItem.GetType())
            {
                this.chestItem.GetItemValue().SetValue(chestItem.GetItemValue().GetValue() * -1);
                oldItem = chestItem;
            }
            else if (itemToChange.GetType() == feetItem.GetType())
            {
                this.feetItem.GetItemValue().SetValue(feetItem.GetItemValue().GetValue() * -1);
                oldItem = feetItem;
            }
            else if (itemToChange.GetType() == handsItem.GetType())
            {
                this.handsItem.GetItemValue().SetValue(handsItem.GetItemValue().GetValue() * -1);
                oldItem = handsItem;
            }
            else if (itemToChange.GetType() == headItem.GetType())
            {
                this.headItem.GetItemValue().SetValue(headItem.GetItemValue().GetValue() * -1);
                oldItem = headItem;
            }
            else if (itemToChange.GetType() == legItem.GetType())
            {
                this.legItem.GetItemValue().SetValue(legItem.GetItemValue().GetValue() * -1);
                oldItem = legItem;
            }
            else if (itemToChange.GetType() == toolItem.GetType())
            {
                this.toolItem.GetItemValue().SetValue(toolItem.GetItemValue().GetValue() * -1);
                oldItem = toolItem;
            }

            return oldItem;
        }
        #endregion

        #region Getters and Setters
        //Getters and Setters.
        public ItemChest GetChestItem()
        {
            return this.chestItem;
        }

        public ItemFeet GetFeetItem()
        {
            return this.feetItem;
        }

        public ItemHands GetHandsItem()
        {
            return this.handsItem;
        }

        public ItemHead GetHeadItem()
        {
            return this.headItem;
        }

        public ItemLegs GetLegsItem()
        {
            return this.legItem;
        }

        public ItemTool GetToolItem()
        {
            return this.toolItem;
        }
        #endregion

        #endregion
    }
}
