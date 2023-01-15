/*
 * Author: Kinjal Padhiar
 * File Name: Game.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Game.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Game : Media
    {
        //initializes variables limited to game 
        private string ESRBRating;
        private int score;

        //Pre: name, barcode, genre, platform, release year, and ESRB rating are valid strings, cost is a valid double that is 0 or greater,
        //     and score is a integer between 0 and 100
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Game(string name, double cost, string barcode, string genre, string platform, string releaseYear, 
            string ESRBRating, int score)
           : base(name, cost, barcode, genre, platform, releaseYear)
        {
            itemType = "Game";
            this.ESRBRating = ESRBRating;
            this.score = score;
        }

        //Pre: none
        //Post: return string that displays specified data for a game
        //Desc: overrides base class display to add game parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nRating: " + ESRBRating + "\nScore: " + score);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (ESRBRating + "," + score); 
        }

        //Pre: none
        //Post: returns ESRB rating as a string
        //Desc: accessor that gets ESRB rating
        public string GetESRBRating()
        {
            return ESRBRating;
        }

        //Pre: none
        //Post: returns score as an integer
        //Desc: accessor that gets score
        public int GetScore ()
        {
            return score;
        }

        
    }
}
