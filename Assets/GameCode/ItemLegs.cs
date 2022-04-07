using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class ItemLegs : Item
    {
        //Members.
        private LegsList itemName;

        //Legs Item Descriptions.
        private readonly string LEATHER_LEGGINGS = "A leather leggings that offers minimal protection but enhanced flexibility. Increases Dexterity by 1";
        private readonly string CLOTH_PANTS = "A pair of pants made of cloth and imbued to increase the wearer's magic affinity. Increases Magic by 1";

        //Legs Item Values.
        private readonly CharacterStat LEATHER_LEGGINGS_VALUE = new CharacterStat(1, StatsList.Dexterity);
        private readonly CharacterStat CLOTH_PANTS_VALUE = new CharacterStat(1, StatsList.Magic);

        //Constructors.
        public ItemLegs()
        {
            this.itemName = LegsList.LeatherLeggings;
            UpdateItem();
        }

        public ItemLegs(LegsList item)
        {
            this.itemName = item;
            UpdateItem();
        }

        //Methods.
        private void UpdateItem()
        {
            if (this.itemName == LegsList.LeatherLeggings)
            {
                base.SetItemDescription(LEATHER_LEGGINGS);
                base.SetItemValue(LEATHER_LEGGINGS_VALUE);
            }
            else if (this.itemName == LegsList.ClothPants)
            {
                base.SetItemDescription(CLOTH_PANTS);
                base.SetItemValue(CLOTH_PANTS_VALUE);
            }
        }

        //Getters and Setters.
        public LegsList GetItemName()
        {
            return this.itemName;
        }

        public void SetItemName(LegsList newItem)
        {
            this.itemName = newItem;
            UpdateItem();
        }
    }
}
