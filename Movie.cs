/*
 * Author: Kinjal Padhiar
 * File Name: Movie.cs
 * Project Name: InventoryManager
 * Creation Date: March 22, 2022
 * Modified Date: March 31, 2022
 * Description: This class stores and processes data for the product Movie.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    class Movie : Media
    {
        //initializes variables limited to movie 
        private string director;
        private string MPAARating;
        private double duration;

        //Pre: name, barcode, genre, platform, release year, director, and MPAA rating are valid strings
        //     as well as cost and duration is a valid double that is 0 or greater
        //Post: none
        //Desc: overloaded constructer that takes parameters from base class and adds its specific parameters
        public Movie(string name, double cost, string barcode, string genre, string platform, string releaseYear, 
            string director, string MPAARating, double duration) 
            : base (name, cost, barcode, genre, platform, releaseYear)
        {
            itemType = "Movie";
            this.director = director;
            this.MPAARating = MPAARating;
            this.duration = duration;
        }

        //Pre: none
        //Post: return string that displays specified data for a movie
        //Desc: overrides base class display to add movie parameters
        public override string DisplayData()
        {
            return base.DisplayData() + ("\nDirector: " + director + "\nMPAA Rating: " + MPAARating + "\nDuration: " + duration);
        }

        //Pre: none
        //Post: returns string that displays data seperated by a comma
        //Desc: overrides base class to create string that contains data seperated by comma
        public override string StringToSaveData()
        {
            return base.StringToSaveData() + (director + "," + MPAARating + "," + duration);
        }

        //Pre: none
        //Post: returns director as a string
        //Desc: accessor that gets director
        public string GetDirector ()
        {
            return director;
        }

        //Pre: none
        //Post: returns MPAA rating as a string
        //Desc: accessor that gets MPAA rating
        public string GetMPAARating()
        {
            return MPAARating;
        }

        //Pre: none
        //Post: returns duration as a double
        //Desc: accessor that gets duration
        public double GetDuration()
        {
            return duration;
        }

        
    }
}
