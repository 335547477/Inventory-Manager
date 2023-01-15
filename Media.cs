/*
 * Author: Kinjal Padhiar
 * File Name: Media.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product group Media.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Media : Product
    {
        //initializes variables that can be used by this class and it's subclasses
        protected string genre;
        protected string platform;
        protected string releaseYear;

        //Pre: name, barcode, genre, platform, and release year are valid strings, cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Media (string name, double cost, string barcode, 
            string genre, string platform, string releaseYear) 
            : base (name, cost, barcode)
        {
            this.genre = genre;
            this.platform = platform;
            this.releaseYear = releaseYear;
        }

        //Pre: none
        //Post: return string that displays data for media group type
        //Desc: overrides base class display to add media-specific parameters 
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nGenre: " + genre + "\nPlatform: " + platform + "\nRelease Year: " + releaseYear);

        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (genre + "," + platform + "," + releaseYear + ",");
        }

        //Pre: none
        //Post: returns genre as a string
        //Desc: accessor that gets genre
        public string GetGenre ()
        {
            return genre;
        }

        //Pre: none
        //Post: returns platform as a string
        //Desc: accessor that gets platform
        public string GetPlatform()
        {
            return platform;
        }

        //Pre: none
        //Post: returns release year as a string
        //Desc: accessor that gets release year
        public string GetReleaseYear()
        {
            return releaseYear;
        }

        //Pre: none
        //Post: returns group type (Media) as a string
        //Desc: accessor that overrides to get group type of this class
        public override string GetGroupType()
        {
            groupType = "Media";
            return groupType;
        }
    }
}
