/*
 * Author: Kinjal Padhiar
 * File Name: Program.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: April 1, 2022
 * Description: The driver class reads the inventory and performs actions accordingly 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace InventoryManager
{
    class Program
    {
        //initializes variables for this program to use in file input/output
        private static StreamWriter outFile;
        private static StreamReader inFile;

        //initialzies inventory that holds the prodcuts
        private static Inventory inventory = new Inventory ();

        //initailes extra varibles that will be used for storage/holding data
        private static Product product;
        private static List<String> resultsProducts = new List<String>();
        private static double validData;

        static void Main(string[] args)
        {
            //if reading the inventory fails, then terminates the program
            if (ReadInventory() == false)
            {
                Console.ReadLine();
                return;
            }

            //if reading the actions fails, then terminates the program
            if (ReadActions() == false)
            {
                Console.ReadLine();
                return;
            }

            Console.ReadLine();
        }

        //Pre: none
        //Post: returns a boolean of whether reading the file was successful 
        //Desc: reads and stores inventory file
        private static bool ReadInventory ()
        {
            //try-catch block to catch and accordingly output feedback for his errors
            try
            {
                //intializes valiables to store data from file
                List<string> data = null;

                //opens inventory file
                inFile = File.OpenText("inventory.txt");

                //loops until the end of file that is trying to be read in 
                while (!inFile.EndOfStream)
                {
                    //reads file into list split by a comma
                    data = (inFile.ReadLine()).Split(',').ToList();

                    //adds product to product list 
                    AddProduct(data);
                }

            }
            catch (FormatException fe)
            {
                Console.WriteLine("ERROR: " + fe.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("ERROR: " + fnf.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (IndexOutOfRangeException re)
            {
                Console.WriteLine("ERROR: " + re.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            finally
            {
                //if file is not empty/ not equal to null, then closes file
                if (inFile != null)
                {
                    inFile.Close();
                }

            }
            
            //returns true if reading the file was successful
            return true;
        }

        //Pre: none
        //Post: returns a boolean of whether reading the file was successful 
        //Desc: reads and stores actions file
        private static bool ReadActions ()
        {
            //try-catch block to catch and accordingly output feedback for his errors
            try
            {
                //initializes variable to store data
                List<string> data = null;

                //opens actions file to read from
                inFile = File.OpenText("actions.txt");

                //loops until the end of file that is trying to be read in 
                while (!inFile.EndOfStream)
                {
                    //reads and stores in data into list specifically splitting at ':'
                    data = (inFile.ReadLine()).Split(':').ToList();

                    //method that performs the requested action
                    PerformAction(data);

                    //stores the results by writing them to results file
                    ResultsStorage(resultsProducts);
                }

            }
            catch (FormatException fe)
            {
                Console.WriteLine("ERROR: " + fe.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine("ERROR: " + fnf.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (IndexOutOfRangeException re)
            {
                Console.WriteLine("ERROR: " + re.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);

                //if error is caught return false (reading file was not successful)
                return false;
            }
            finally
            {
                //if file is not empty/ not equal to null, then closes file
                if (inFile != null)
                {
                    inFile.Close();
                }
            }

            //returns true if reading the file was successful
            return true;
        }

        //Pre: data is a valid list of string 
        //Post: none 
        //Desc: adds a product to the inventory if it is valid
        private static void AddProduct (List <string> data)
        {
            //switch statement that uses the item type from the line to add the specified product
            switch (data[0])
            { 
                case "Movie":
                    //if the data count is 10 (enough data to fill parameters of a movie)
                    if (data.Count == 10)
                    {
                        //if the cost and duration can be converted to a double  
                        if (TryParse(data[9]) == true && TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Movie(data[1], Math.Round(validData, 2), data[3], data[4], data[5],
                            data[6], data[7], data[8], Convert.ToDouble(data[9])));
                        }
                    }
                    break;

                case "Game":
                    //if the data count is 9 (enough data to fill parameters of a game)
                    if (data.Count == 9)
                    {
                        //if the cost and score can be converted to a double  
                        if (TryParse(data[8]) == true && TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Game(data[1], Math.Round(validData, 2), data[3], data[4], data[5],
                            data[6], data[7], Convert.ToInt32(data[8])));
                        }
                    }
                    break;

                case "Book":
                    //if the data count is 9 (enough data to fill parameters of a book)
                    if (data.Count == 9)
                    {
                        //if the cost can be converted to a double  
                        if (TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Book(data[1], Math.Round(validData, 2), data[3], data[4], data[5],
                            data[6], data[7], data[8]));
                        }  
                    }
                    break;

                case "Pants":
                    //if the data count is 6 (enough data to fill parameters of pants)
                    if (data.Count == 6)
                    {
                        //if the cost and waist size can be converted to a double  
                        if (TryParse(data[5]) == true && TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Pants(data[1], Math.Round(validData, 2), data[3], data[4], Convert.ToInt32(data[5])));
                        }
                    }
                    break;

                case "Top":
                    //if the data count is 7 (enough data to fill parameters of a top)
                    if (data.Count == 7)
                    {
                        //if the cost can be converted to a double  
                        if (TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Top(data[1], Math.Round(validData, 2), data[3], data[4], data[5], data[6]));
                        } 
                    }
                    break;

                case "Dress":
                    //if the data count is 7 (enough data to fill parameters of a dress)
                    if (data.Count == 7)
                    {
                        //if the cost can be converted to a double  
                        if (TryParse(data[2]) == true)
                        {
                            //adds product
                            inventory.AddProduct(new Dress(data[1], Math.Round(validData, 2), data[3], data[4], data[5], data[6]));
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Product");
                    break;
            }
        }

        //Pre: data is a valid string 
        //Post: returns a boolean of whether conversion was successful 
        //Desc: tries to convert string into double
        private static bool TryParse (string data)
        {
            //stores whether try parse conversion was successful (if it was validData holds the value)
            bool success = double.TryParse(data, out validData);

            //returns bool value 
            return success;
        }

        //Pre: data is a valid list of string 
        //Post: none
        //Desc: performs actions read in from actions file
        private static void PerformAction (List <string> data)
        {
            //initalizes variables to store data and display certain data based on action
            List<Product> products = new List<Product>();
            string display;

            //switch statement that uses the action stated from the line to perform action
            switch (data[0])
            {
                case "Add":
                    //adds product using "AddProduct" method by splitting line using a comma
                    AddProduct(data[1].Split(',').ToList());

                    break;

                case "Display2":
                    //gets and displays string of the first two products of specified type
                    display = inventory.GetFirst2(data[1]);
                    Console.WriteLine(display);

                    //adds string of display into list to be written to file
                    resultsProducts.Add(display);

                    break;

                case "FindBarcode":
                    //stores product that matches the desired barcode
                    product = inventory.FindBarcode(data[1]);

                    break;

                case "FindName":
                    //stores list of products that match desired name 
                    products = inventory.FindName(data[1]);

                    break;

                case "SortByCost":
                    //stores list that stores inventory sorted by cost
                    products = inventory.SortByCost();

                    break;

                case "SortByName":
                    //stores list that stores inventory sorted by name
                    products = inventory.SortByName();

                    break;
                default:
                    //if the action coommand doesn't match, then writes to console that action not recognized
                    Console.WriteLine("Action Command: " + data[0] + " not recognized.");

                    break;
            }

            //if the data count it more than 2, then there is a secondary command involved 
            if (data.Count > 2)
            {
                //switch statement that performs action based on secondary commany
                switch (data[2])
                {
                    case "Modify":
                        //if the data count is more than 4, then secondary command is pertaining to find name otherwise find barcode
                        if (data.Count > 4)
                        {
                            //changes cost of specified product 
                            products[Convert.ToInt32(data[3])].SetCost(Convert.ToDouble(data[4]));
                        }

                        else
                        {
                            //if a product that matches the barcode was found, then changes cost 
                            if (product != null)
                            {
                                product.SetCost(Convert.ToDouble(data[3]));
                            }
                            
                        }

                        break;

                    case "Display":
                        //if data count is more than 3, then secondary command is pertaining to find name otherwise find barcode
                        if (data.Count > 3)
                        {
                            //displays data of product based on specified index
                            Console.WriteLine(inventory.DisplayData(products[Convert.ToInt32(data[3])]));
                            Console.WriteLine();

                            //adds string that displays data to list to be written to file
                            resultsProducts.Add(inventory.DisplayData(products[Convert.ToInt32(data[3])]) + "\n");
                        }
                        else
                        {
                            //if a product that matches the barcode was found
                            if (product != null)
                            {
                                //displays data of product based on specified index
                                Console.WriteLine(inventory.DisplayData(product));
                                Console.WriteLine();

                                //adds string that displays data to list to be written to file
                                resultsProducts.Add(inventory.DisplayData(product) + "\n");
                            }
                            
                        }

                        break;

                    case "Delete":
                        //if the data count is more than 3, then secondary command is pertaining to find name otherwise find barcode
                        if (data.Count > 3)
                        {
                            //if the product index that wants to be removed is less than count of products (valid index)
                            if ((Convert.ToInt32(data[3])) < products.Count)
                            {
                                //removes product at specified index
                                products.RemoveAt(Convert.ToInt32(data[3]));

                            }
                        }
                        else
                        {
                            //if a product that matches the barcode was found
                            if (product != null)
                            {
                                //removes product from inventory
                                inventory.RemoveProduct(product);
                            } 
                        }

                        break;

                    default:
                        //if the action coommand doesn't match, then writes to console that action not recognized
                        Console.WriteLine("Secondary Action Command: " + data[2] + " not recognized.");

                        break;
                } 
                
            }

            //saves inventory 
            inventory.SaveInventory();
        }

        //Pre: products is a valid list of string
        //Post: none
        //Desc: stores the results of actions performed into file
        private static void ResultsStorage (List <string> products)
        {
            //try-catch block to catch and accordingly output feedback for any errors
            try
            {
                //creates or opens actions file to store results
                outFile = File.CreateText("PadhiarK_PASS2.txt");

                //loops thorugh product list 
                for (int i = 0; i < products.Count; i++)
                {
                    //for each produc: writes display of product into the results file
                    outFile.WriteLine(products[i]);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
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
