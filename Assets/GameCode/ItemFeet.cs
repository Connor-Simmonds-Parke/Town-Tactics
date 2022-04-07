using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemFeet : Item
    {
        //Members.
        private FeetList itemName;

        //Legs Item Descriptions.
        private readonly string LEATHER_BOOTS = "A pair of leather boots that offers minimal protection but enhanced flexibility. Increases Dexterity by 1";
        private readonly string CLOTH_SLIPPERS = "A pair of slippers made of cloth and imbued to increase the wearer's magic affinity. Increases Magic by 1";

        //Legs Item Values.
        private readonly CharacterStat LEATHER_BOOTS_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat CLOTH_SLIPPERS_VALUE = new CharacterStat(1, StatsList.Magic);

        //Constructors.
        public ItemFeet()
        {
            this.itemName = FeetList.LeatherBoots;
            UpdateItem();
        }

        public ItemFeet(FeetList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == FeetList.LeatherBoots)
            {
                base.SetItemDescription(LEATHER_BOOTS);
                base.SetItemValue(LEATHER_BOOTS_VALUE);
            }
            else if (this.itemName == FeetList.ClothSlippers)
            {
                base.SetItemDescription(CLOTH_SLIPPERS);
                base.SetItemValue(CLOTH_SLIPPERS_VALUE);
            }
        }

        //Getters and Setters.
        public FeetList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(FeetList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
