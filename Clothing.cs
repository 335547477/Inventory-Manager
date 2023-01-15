/*
 * Author: Kinjal Padhiar
 * File Name: Clothing.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product group Clothing.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Clothing: Product
    {
        //initializes variables that can be used by this class and it's subclasses
        protected string material;

        //Pre: name, barcode, and material are valid strings, cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Clothing (string name, double cost, string barcode, string material) 
            : base(name, cost, barcode)
        {
            this.material = material;
        }

        //Pre: none
        //Post: return string that displays data for clothing group type
        //Desc: overrides base class display to add clothing-specific parameters 
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nMaterial: " + material);

        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (material + ",");
        }

        //Pre: none
        //Post: returns material as a string
        //Desc: accessor that gets material
        public string GetMaterial ()
        {
            return material;
        }

        //Pre: none
        //Post: returns group type (Clothing) as a string
        //Desc: accessor that overrides to get group type of this class
        public override string GetGroupType ()
        {
            groupType = "Clothing";
            return groupType;
        }
    }
}
