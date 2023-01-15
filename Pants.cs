/*
 * Author: Kinjal Padhiar
 * File Name: Pants.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Pants.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Pants : Clothing
    {
        //initializes variables limited to pants 
        private int waistSize;

        //Pre: name, barcode, and material are valid strings, cost is a valid double that is 0 or greater, 
        //     and waist size in a valid integer between 20 and 50 
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Pants (string name, double cost, string barcode, string material, int waistSize) 
            : base (name, cost, barcode, material)
        {
            itemType = "Pants";
            this.waistSize = waistSize;
        }

        //Pre: none
        //Post: return string that displays specified data for a pants
        //Desc: overrides base class display to add pants parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nWaist Size: " + waistSize);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (waistSize);
        }

        //Pre: none
        //Post: returns waist size as an integer
        //Desc: accessor that gets waist size
        public int GetWaistSize ()
        {
            return waistSize;
        }

       
    }
}
