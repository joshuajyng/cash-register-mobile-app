using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace A1.Models
{
    public class HistoryItem
    {

        public string name { get; set; }
        public int quant { get; set; }
        public double totalPrice { get; set; }
        public string date { get; set; }


        public HistoryItem () { }
        public HistoryItem(string n, int q, string d, double p)
        {
            name = n;
            quant = q;
            date = d;
            totalPrice = p;
        }


    }
}
