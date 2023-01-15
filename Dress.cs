/*
 * Author: Kinjal Padhiar
 * File Name: Dress.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Dress.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Dress : Clothing
    {
        //initializes variables limited to dress 
        private string dressType;
        private string size;

        //Pre: name, barcode, material, dress type, and size are valid strings and cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Dress(string name, double cost, string barcode, string material, string dressType, string size)
            : base(name, cost, barcode, material)
        {
            itemType = "Dress";
            this.dressType = dressType;
            this.size = size;
        }

        //Pre: none
        //Post: return string that displays specified data for a dress
        //Desc: overrides base class display to add dress parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nDress Type: " + dressType + "\nSize: " + size);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (dressType + "," + size);
        }

        //Pre: none
        //Post: returns dress type as a string
        //Desc: accessor that gets dress type
        public string GetDressType ()
        {
            return dressType;
        }

        //Pre: none
        //Post: returns size as a string
        //Desc: accessor that gets size
        public string GetSize()
        {
            return size;
        }

        
    }
}
