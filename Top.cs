/*
 * Author: Kinjal Padhiar
 * File Name: Top.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Top.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Top : Clothing
    {
        //initializes variables limited to top 
        private string topStyle;
        private string size;

        //Pre: name, barcode, material, top style, and size are valid strings, cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Top (string name, double cost, string barcode, string material, string topStyle, string size)
            : base(name, cost, barcode, material)
        {
            itemType = "Top";
            this.topStyle = topStyle;
            this.size = size;
        }

        //Pre: none
        //Post: return string that displays specified data for a top
        //Desc: overrides base class display to add top parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nTop Style: " + topStyle + "\nSize: " + size);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (topStyle + "," + size);
        }

        //Pre: none
        //Post: returns top style as a string
        //Desc: accessor that gets top style
        public string GetTopStyle ()
        {
            return topStyle;
        }

        //Pre: none
        //Post: returns size as a string
        //Desc: accessor that gets size
        public string GetSize ()
        {
            return size;
        }

       
    }
}
