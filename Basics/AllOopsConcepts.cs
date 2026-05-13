using System;
using System.Collections.Generic;
using System.Text;

namespace Basics
{
    //Class & Object 
    //encapsulation
    public class Electronics
    {
        public string Brand { get; set; }

        public int Price { get; set; }

        //public int Price
        //{
        //    get
        //    {
        //        return _price;
        //    }

        //    set
        //    {
        //        if (value > 0)
        //        {
        //            _price = value;
        //        }
        //        else
        //        {
        //            WriteLine("Price should be greater than 0");
        //        }
        //    }
        //}

        public void PowerOn()
        {
            WriteLine("Powering on the electronic device...");
        }
        //public Electronics(string brand, int price)
        //{
        //    Brand = brand;
        //    Price = price;
        //}

        public void ShowElectronics()
        {
            WriteLine($"Brand: {Brand}");
            WriteLine($"Price: {Price}");
        }
    }
    public class Mobile : Electronics
    {

    }
}
