using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace A1.Models
{
    public class Item : INotifyPropertyChanged
    {
        private int newStock;

        public event PropertyChangedEventHandler PropertyChanged;
        public string name { get; set; }
        public int stock
        {
            get
            {
                return newStock;
            }
            set
            {
                if (value == newStock)
                {
                    return;
                }
                newStock = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(stock)));
                }
            }
        }
        public double price { get; set; }

    
        public Item() { }
        public Item(string n, int s, double p)
        {
            name = n;
            stock = s;
            price = p;
        }

        
    }
}
