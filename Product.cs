/*
 * Author: Kinjal Padhiar
 * File Name: Product.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the a general product.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Product
    {
        //initializes variables that can be used by this class and it's subclasses
        protected string name;
        protected double cost;
        protected string barcode;
        protected string groupType;
        protected string itemType;

        //Pre: name and barcode are valid strings, cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that specifies parameters for a general product
        public Product (string name, double cost, string barcode)
        {
            this.name = name;
            this.cost = cost;
            this.barcode = barcode;
        }

        //Pre: none
        //Post: return string that displays data for a product
        //Desc: a virtual method that can be overriden by sub classes to get a string of a specfic product's data 
        public virtual string DisplayData ()
        {
            return ("Type: " + itemType + "\nName: " + name + "\nCost: " + cost + "\nBarcode: " + barcode);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: a virtual method that can be overriden by sub classes to get a string of a specfic product's data seperated by a comma
        public virtual string StringToSaveData ()
        {
            return (name + "," + Convert.ToString(cost) + "," + barcode + ",");
        }

        //Pre: none
        //Post: returns the name of product as a string
        //Desc: accessor that gets the name
        public string GetName ()
        {
            return name;
        }

        //Pre: none
        //Post: returns the cost of the product as a double
        //Desc: accessor that gets the cost
        public double GetCost()
        {
            return cost;
        }

        //Pre: cost is a valid double greater than or equal to 0
        //Post: none
        //Desc: modifier that sets cost in parameter to the cost in this class
        public void SetCost(double cost)
        {
            this.cost = cost;
        }

        //Pre: none
        //Post: returns the barcode of the product as a double
        //Desc: accessor that gets the barcode
        public string GetBarcode()
        {
            return barcode;
        }

        //Pre: none
        //Post: returns the group type of the product as a string
        //Desc: virtual accessor that gets the group type by being overriden in sub classes 
        public virtual string GetGroupType ()
        {
            return groupType;
        }

        //Pre: none
        //Post: returns the item type of the product as a string
        //Desc: accessor that gets the item type
        public string GetItemType()
        {
            return itemType;
        }

     
    }
}
