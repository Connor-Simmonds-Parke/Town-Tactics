/*
 * File: CharacterBody.cs
 * Author: Connor Simmonds-Parke
 * Date: 2022-02-12
 * 
 * Purpose: Creates a character's appearance and allows for it to be changed. Holds the descriptions for each.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GameCode
{
    public class CharacterBody
    {
        #region Members
        //Members.
        private GenderList gender;
        private BodySizeList bodySize;
        private BodyColourList bodyColour;
        private HairColourList hairColour;
        private HairStyleList hairStyle;
        private FacialHairList facialHair;
        private EyeColourList eyeColour;

        private string genderDescription;
        private string bodySizeDescription;
        private string bodyColourDescription;
        private string hairColourDescription;
        private string hairStyleDescription;
        private string facialHairDescription;
        private string eyeColourDescription;

        //Gender Descriptions.
        private readonly string MALE = "male";
        private readonly string FEMALE = "female";

        //Body Size Descriptions.
        private readonly string GIANT = "a hulking giant who towers over others";
        private readonly string TALL = "taller than most";
        private readonly string AVERGE = "of average height";
        private readonly string SHORT = "shorter than most";
        private readonly string TINY = "so short that even those of average height appear as giants to them";

        //Body Colour Descriptions.
        private readonly string PALE = "incredibly pale skin that is usually the effect of very little exposure to sun";
        private readonly string LIGHT = "a light, pinkish skin colour";
        private readonly string TANNED = "brownish bronze skin colour";
        private readonly string DARK = "a darker skin colour usually found amongst those who dwell in the lands where the sun is harshest";
        private readonly string GREEN = "a green skin colour found only amongst orcs or those tainted by magic";

        //Hair Colour Descriptions.
        private readonly string BROWN_HAIR = "brown";
        private readonly string BLACK_HAIR = "raven black";
        private readonly string WHITE_HAIR = "white";
        private readonly string GRAY_HAIR = "gray";
        private readonly string BLONDE_HAIR = "blonde";
        private readonly string RED_HAIR = "red";

        //Hair Style Descriptions.
        private readonly string LONG = "unkept, long hair";
        private readonly string SHORT_HAIR = "short, messy hair";
        private readonly string SHAVED = "shaved hair";
        private readonly string PONYTAIL = "long hair tied up in a ponytail";
        private readonly string BRAIDED = "long hair tied into a single braid";

        //Facial Hair Style Descriptions.
        private readonly string NONE = "a smooth, hairless face";
        private readonly string MUSTACHE = "a trimmed mustache";
        private readonly string GOATEE = "facial hair in the goatee style";
        private readonly string STUBBLE = "rough stuble around their face";

        //Eye Colour Descriptions.
        private readonly string RED_EYE = "red eyes";
        private readonly string GREEN_EYE = "green eyes";
        private readonly string HAZEL_EYE = "hazel eyes";
        private readonly string BROWN_EYE = "brown eyes";
        private readonly string BLUE_EYE = "blue eyes";
        private readonly string YELLOW_EYE = "yellow eyes";
        private readonly string PURPLE_EYE = "purple eyes";
        private readonly string SILVER_EYE = "clear, silver eyes";
        #endregion

        #region Constructors
        //Constructors.
        /// <summary>
        /// Default Constructor. Uses default values to create a character appearance and updates the descriptions.
        /// </summary>
        public CharacterBody()
        {
            this.gender = GenderList.Male;
            this.bodySize = BodySizeList.Average;
            this.bodyColour = BodyColourList.Light;
            this.hairColour = HairColourList.Black;
            this.hairStyle = HairStyleList.Shaved;
            this.facialHair = FacialHairList.None;
            this.eyeColour = EyeColourList.Brown;

            UpdateAll();
        }

        /// <summary>
        /// Creates a the specified character appearance and updates the descriptions. 
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <param name="bodySize">The body size (height).</param>
        /// <param name="bodyColour">The skin colour.</param>
        /// <param name="hairColour">The hair colour.</param>
        /// <param name="hairStyle">The hair style.</param>
        /// <param name="facialHair">The facial hair.</param>
        /// <param name="eyeColour">The eye colour.</param>
        public CharacterBody(GenderList gender, BodySizeList bodySize, BodyColourList bodyColour, HairColourList hairColour, HairStyleList hairStyle, FacialHairList facialHair,
            EyeColourList eyeColour)
        {
            this.gender = gender;
            this.bodySize = bodySize;
            this.bodyColour = bodyColour;
            this.hairColour = hairColour;
            this.hairStyle = hairStyle;
            this.facialHair = facialHair;
            this.eyeColour = eyeColour;

            UpdateAll();
        }
        #endregion

        #region Methods
        //Methods.

        #region Appearance Change Methods
        /// <summary>
        /// Changes the gender and updates the description.
        /// </summary>
        /// <param name="newGender">New character gender.</param>
        public void ChangeGender(GenderList newGender)
        {
            this.gender = newGender;
            UpdateGender();
        }

        /// <summary>
        /// Changes the body colour and updates the description.
        /// </summary>
        /// <param name="newBodyColour">New body colour.</param>
        public void ChangeBodyColour(BodyColourList newBodyColour)
        {
            this.bodyColour = newBodyColour;
            UpdateBodyColour();
        }

        /// <summary>
        /// Changes the body size and updates the description.
        /// </summary>
        /// <param name="newBodySize">New body size.</param>
        public void ChangeBodySize(BodySizeList newBodySize)
        {
            this.bodySize = newBodySize;
            UpdateBodySize();
        }

        /// <summary>
        /// Changes the eye colour and updates the description.
        /// </summary>
        /// <param name="newEyeColour">New eye colour.</param>
        public void ChangeEyeColour(EyeColourList newEyeColour)
        {
            this.eyeColour = newEyeColour;
            UpdateEyeColour();
        }

        /// <summary>
        /// Changes the factial hair and updates the description.
        /// </summary>
        /// <param name="newFacialHair">New facial hair.</param>
        public void ChangeFacialHair(FacialHairList newFacialHair)
        {
            this.facialHair = newFacialHair;
            UpdateFacialHair();
        }

        /// <summary>
        /// Changes the hair colour and updates the description.
        /// </summary>
        /// <param name="newHairColour">New hair colour.</param>
        public void ChangeHairColour(HairColourList newHairColour)
        {
            this.hairColour = newHairColour;
            UpdateHairColour();
        }

        /// <summary>
        /// Changes the hair style and updates the description.
        /// </summary>
        /// <param name="newHairStyle">New hair style.</param>
        public void ChangeHairStyle(HairStyleList newHairStyle)
        {
            this.hairStyle = newHairStyle;
            UpdateHairStyle();
        }
        #endregion

        #region Description Updater Methods
        /// <summary>
        /// Updates all the appearance descriptors at once.
        /// </summary>
        private void UpdateAll()
        {
            UpdateGender();
            UpdateBodyColour();
            UpdateBodySize();
            UpdateEyeColour();
            UpdateFacialHair();
            UpdateHairColour();
            UpdateHairStyle();
        }

        /// <summary>
        /// Updates the gender appearance descriptors.
        /// </summary>
        private void UpdateGender()
        {
            //Assign gender description.
            if (this.gender == GenderList.Male)
            {
                this.genderDescription = MALE;
            }
            else if (this.gender == GenderList.Female)
            {
                this.genderDescription = FEMALE;
            }
        }

        /// <summary>
        /// Updates the body size appearance descriptors.
        /// </summary>
        private void UpdateBodySize()
        {
            //Assign body size description.
            if (this.bodySize == BodySizeList.Giant)
            {
                this.bodySizeDescription = GIANT;
            }
            else if (this.bodySize == BodySizeList.Average)
            {
                this.bodySizeDescription = AVERGE;
            }
            else if (this.bodySize == BodySizeList.Short)
            {
                this.bodySizeDescription = SHORT;
            }
            else if (this.bodySize == BodySizeList.Tall)
            {
                this.bodySizeDescription = TALL;
            }
            else if (this.bodySize == BodySizeList.Tiny)
            {
                this.bodySizeDescription = TINY;
            }
        }

        /// <summary>
        /// Updates the body colour appearance descriptors.
        /// </summary>
        private void UpdateBodyColour()
        {
            //Assign body colour description.
            if (this.bodyColour == BodyColourList.Pale)
            {
                this.bodyColourDescription = PALE;
            }
            else if (this.bodyColour == BodyColourList.Dark)
            {
                this.bodyColourDescription = DARK;
            }
            else if (this.bodyColour == BodyColourList.Green)
            {
                this.bodyColourDescription = GREEN;
            }
            else if (this.bodyColour == BodyColourList.Light)
            {
                this.bodyColourDescription = LIGHT;
            }
            else if (this.bodyColour == BodyColourList.Tanned)
            {
                this.bodyColourDescription = TANNED;
            }
        }

        /// <summary>
        /// Updates the hair colour appearance descriptors.
        /// </summary>
        private void UpdateHairColour()
        {
            //Assign hair colour description.
            if (this.hairColour == HairColourList.Brown)
            {
                this.hairColourDescription = BROWN_HAIR;
            }
            else if (this.hairColour == HairColourList.Black)
            {
                this.hairColourDescription = BLACK_HAIR;
            }
            else if (this.hairColour == HairColourList.Blonde)
            {
                this.hairColourDescription = BLONDE_HAIR;
            }
            else if (this.hairColour == HairColourList.Gray)
            {
                this.hairColourDescription = GRAY_HAIR;
            }
            else if (this.hairColour == HairColourList.Red)
            {
                this.hairColourDescription = RED_HAIR;
            }
            else if (this.hairColour == HairColourList.White)
            {
                this.hairColourDescription = WHITE_HAIR;
            }
        }

        /// <summary>
        /// Updates the hair style appearance descriptors.
        /// </summary>
        private void UpdateHairStyle()
        {
            //Assign hair style description.
            if (this.hairStyle == HairStyleList.Braided)
            {
                this.hairStyleDescription = BRAIDED;
            }
            else if (this.hairStyle == HairStyleList.Long)
            {
                this.hairStyleDescription = LONG;
            }
            else if (this.hairStyle == HairStyleList.Ponytail)
            {
                this.hairStyleDescription = PONYTAIL;
            }
            else if (this.hairStyle == HairStyleList.Shaved)
            {
                this.hairStyleDescription = SHAVED;
            }
            else if (this.hairStyle == HairStyleList.Short)
            {
                this.hairStyleDescription = SHORT_HAIR;
            }
        }

        /// <summary>
        /// Updates the facial hair appearance descriptors.
        /// </summary>
        private void UpdateFacialHair()
        {
            //Assign facial hair description.
            if (this.facialHair == FacialHairList.None)
            {
                this.facialHairDescription = NONE;
            }
            else if (this.facialHair == FacialHairList.Mustache)
            {
                this.facialHairDescription = MUSTACHE;
            }
            else if (this.facialHair == FacialHairList.Goatee)
            {
                this.facialHairDescription = GOATEE;
            }
            else if (this.facialHair == FacialHairList.Stubble)
            {
                this.facialHairDescription = STUBBLE;
            }
        }

        /// <summary>
        /// Updates the eye colour appearance descriptors.
        /// </summary>
        private void UpdateEyeColour()
        {
            //Assign eye colour description.
            if (this.eyeColour == EyeColourList.Blue)
            {
                this.eyeColourDescription = BLUE_EYE;
            }
            else if (this.eyeColour == EyeColourList.Brown)
            {
                this.eyeColourDescription = BROWN_EYE;
            }
            else if (this.eyeColour == EyeColourList.Green)
            {
                this.eyeColourDescription = GREEN_EYE;
            }
            else if (this.eyeColour == EyeColourList.Hazel)
            {
                this.eyeColourDescription = HAZEL_EYE;
            }
            else if (this.eyeColour == EyeColourList.Purple)
            {
                this.eyeColourDescription = PURPLE_EYE;
            }
            else if (this.eyeColour == EyeColourList.Red)
            {
                this.eyeColourDescription = RED_EYE;
            }
            else if (this.eyeColour == EyeColourList.Silver)
            {
                this.eyeColourDescription = SILVER_EYE;
            }
            else if (this.eyeColour == EyeColourList.Yellow)
            {
                this.eyeColourDescription = YELLOW_EYE;
            }
        }
        #endregion

        /// <summary>
        /// Creates and displays a string that is the entire description of the character's appearance.
        /// </summary>
        /// <returns>The characters appearance as a string.</returns>
        public override string ToString()
        {
            StringBuilder tempStringBuilder = new StringBuilder();


            tempStringBuilder.Append("They are " + bodySizeDescription + ", with " + bodyColourDescription + ", and " + eyeColourDescription + ". ");
            tempStringBuilder.Append("\nThey have " + hairColourDescription + " " + hairStyleDescription + ", and " + facialHairDescription + ". ");

            return tempStringBuilder.ToString();
        }

        #region Getters and Setters
        //Getters and Setters.
        /// <summary>
        /// Gets the description of the gender (not used in ToString() override).
        /// </summary>
        /// <returns>Description of the gender.</returns>
        public string GetGenderDescription()
        {
            return this.genderDescription;
        }
        #endregion

        #endregion
    }
}
