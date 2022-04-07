using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class QuestDictionary
    {
        #region Members
        //Members.
        private Dictionary<QuestList, string> description;
        private Dictionary<QuestList, List<KeyValuePair<ResourceList, int>>> resourceRequirements;
        private Dictionary<QuestList, List<Item>> itemRequirements;
        #endregion

        #region Constructors
        //Constructors.

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public QuestDictionary()
        {

        }
        #endregion

        #region Methods
        //Methods.

        #region Getters and Setters
        //Getters and Setters.
        #endregion
        #endregion
    }
}
