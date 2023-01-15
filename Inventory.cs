/*
 * Author: Kinjal Padhiar
 * File Name: Inventory.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the inventory of products.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManager
{
    class Inventory
    {
        //initializes variables that can only be used by this class
        private StreamWriter outFile;

        //initializes a list that stores all the products in a list 
        private List<Product> products = new List<Product>();

        //Pre: none
        //Post: none
        //Desc: constructer to access inventory from driver class
        public Inventory ()
        {

        }

        //Pre: product is a valid Product
        //Post: none
        //Desc: adds product to the list of products
        public void AddProduct (Product product)
        {
            products.Add(product);    
        }

        //Pre: product is a valid Product
        //Post: none
        //Desc: removes product to the list of products
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        //Pre: product is a valid Product
        //Post: returns displayed data as a string  
        //Desc: displays the data of a specific product in the form of a string
        public string DisplayData(Product product)
        {
            return (product.DisplayData());
        }

        //Pre: item type is a valid string
        //Post: returns first two of the specified item type as a string  
        //Desc: finds the first two of an item type from the list of products
        public string GetFirst2 (string itemType)
        {
            //initializes string that stores the first two products found
            List<string> firstTwo = new List<string>();

            //initializes integer to count how many products added
            int count = 0;

            //loops through product list to find first two products of an item type (does it until count of first two list is 2)
            for (int i = 0; (i < products.Count && count < 2); i++)
            {
                //adds product to first two list if it is equal to the item type and increases count by 1
                if ((products[i].GetItemType()).Equals(itemType))
                {
                    firstTwo.Add(products[i].DisplayData());
                    count++;
                }
            }

            //based on list count, returns display data for each product followed by an enter
            if (count == 1)
            {
                return firstTwo[0] + "\n";
            }
            else if (count == 2)
            {
                return firstTwo[0] + "\n\n" + firstTwo[1] + "\n";
            }
            else
            {
                //if list is empty then returns string stating no products found
                return ("No products of type " + itemType + " found.\n");
            }
            
        }

        //Pre: barcode is a valid string
        //Post: returns product with matching barcode
        //Desc: finds product corresponding with the barcode passed thorugh
        public Product FindBarcode(string barcode)
        {
            //loops through products list to match barcode
            for (int i = 0; i < products.Count; i++)
            {
                //returns product if any product in the list is equal to the stated barcode
                if ((products[i].GetBarcode()).Equals(barcode))
                {
                    return products[i];
                }

            }

            //if no product matches barocde, return null 
            return null;
        }

        //Pre: name is a valid string
        //Post: returns a list of products with given name  
        //Desc: finds all products in a list with the same name 
        public List <Product> FindName (string name)
        {
            //initializes list to store all found products with the same name
            List <Product> productName = new List<Product> ();

            //loops through product list to match name to product
            for (int i = 0; i < products.Count; i++)
            {
                //if the product's name matches the given name, then add the product to the new list
                if ((products[i].GetName()).Equals(name))
                {
                    productName.Add(products[i]);
                }
            }

            //returns the list (returns empty list if no names match)
            return productName;
        }

        //Pre: none
        //Post: returns a list that is sorted by cost
        //Desc: sorts list of products by group type, item type and cost
        public List<Product> SortByCost ()
        {
            //sorts list of products and then proceeds to store it back into the orginal list
            products = products.OrderBy(x => x.GetGroupType())
                .ThenBy(x => x.GetItemType())
                .ThenByDescending(x => x.GetCost())
                .ToList();

            //returns list of products
            return products;
        }

        //Pre: none
        //Post: returns a list that is sorted by name
        //Desc: sorts list of products by group type, item type and name
        public List<Product> SortByName ()
        {
            //sorts list of products and then proceeds to store it back into the orginal list
            products = products.OrderBy(x => x.GetGroupType())
                .ThenBy(x => x.GetItemType())
                .ThenBy(x => x.GetName())
                .ToList();

            //returns list of products
            return products;
        }

        //Pre: none
        //Post: none
        //Desc: saves new inventory back into inventory file
        public void SaveInventory ()
        {
            //try-catch block to catch and accordingly output feedback for any errors
            try
            {
                //creates or opens inventory file to save inventory
                outFile = File.CreateText("inventory.txt");

                //loops thorugh product list 
                for (int i = 0; i < products.Count; i++)
                {
                    //for each product: writes string that saves data to the inventory
                    outFile.WriteLine(products[i].GetItemType() + "," + products[i].StringToSaveData());
                }
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("ERROR: " + fnf.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
            finally
            {
                //closes file if file is not null
                if (outFile != null)
                {
                    outFile.Close();
                }
            }
           

        }
    }
}
