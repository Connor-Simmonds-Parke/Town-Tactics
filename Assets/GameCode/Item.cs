/*
 * File: Item.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Base code for a peice of equipment. Meant to be inherited from. 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class Item
    {
        //Members.
        private string itemDescription;
        private CharacterStat itemValue;

        //Constuctors.
        public Item()
        {

        }

        //Methods.

        //Getters and Setters.
        public CharacterStat GetItemValue()
        {
            return this.itemValue;
        }

        public void SetItemValue(CharacterStat newItemValue)
        {
            this.itemValue = newItemValue;
        }

        public string GetItemDescription()
        {
            return this.itemDescription;
        }

        public void SetItemDescription(string newItemDescription)
        {
            this.itemDescription = newItemDescription;
        }
    }
}
