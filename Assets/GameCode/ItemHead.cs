using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemHead : Item
    {
        //Members.
        private HeadList itemName;

        //Legs Item Descriptions.
        private readonly string LEATHER_CAP = "A leather cap that offers minimal protection but enhanced flexibility. Increases Dexterity by 1";
        private readonly string CLOTH_HOOD = "A hood made of cloth and imbued to increase the wearer's magic affinity. Increases Magic by 1";

        //Legs Item Values.
        private readonly CharacterStat LEATHER_CAP_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat CLOTH_HOOD_VALUE = new CharacterStat(1, StatsList.Magic);

        //Constructors.
        public ItemHead()
        {
            this.itemName = HeadList.LeatherCap;
            UpdateItem();
        }

        public ItemHead(HeadList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == HeadList.LeatherCap)
            {
                base.SetItemDescription(LEATHER_CAP);
                base.SetItemValue(LEATHER_CAP_VALUE);
            }
            else if (this.itemName == HeadList.ClothHood)
            {
                base.SetItemDescription(CLOTH_HOOD);
                base.SetItemValue(CLOTH_HOOD_VALUE);
            }
        }

        //Getters and Setters.
        public HeadList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(HeadList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
