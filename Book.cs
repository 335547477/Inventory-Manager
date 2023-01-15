/*
 * Author: Kinjal Padhiar
 * File Name: Book.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Book.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Book : Media
    {
        //initializes variables limited to book 
        private string author;
        private string publisher;

        //Pre: name, barcode, genre, platform, release year, author, and publisher are valid strings 
        //     and cost is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Book(string name, double cost, string barcode, string genre, string platform, string releaseYear, 
                    string author, string publisher)
           : base(name, cost, barcode, genre, platform, releaseYear)
        {
            itemType = "Book";
            this.author = author;
            this.publisher = publisher;
        }

        //Pre: none
        //Post: return string that displays specified data for a book
        //Desc: overrides base class display to add book parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nAuthor: " + author + "\nPublisher: " + publisher);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (author + "," + publisher);
        }

        //Pre: none
        //Post: returns author as a string
        //Desc: accessor that gets author
        public string GetAuthor()
        {
            return author;
        }

        //Pre: none
        //Post: returns publisher as a string
        //Desc: accessor that gets publisher
        public string GetPublisher()
        {
            return publisher;
        }


        
    }
}
