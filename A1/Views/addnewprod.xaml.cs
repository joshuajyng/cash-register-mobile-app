using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A1.Models;

namespace A1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class addnewprod : ContentPage
    {
        ObservableCollection<Item> items;
        public addnewprod(ObservableCollection<Item> i)
        {
            InitializeComponent();
            items = i;

        }

        public void save(object sender, EventArgs e)
        {
            if (pname.Text == null || pprice.Text == null || pquant.Text == null)
            {
                DisplayAlert("Error", "Name, price, and quantity have to be filled", "OK");
            }
            else
            {
                if (double.TryParse(pprice.Text, out double n) && int.TryParse(pquant.Text, out int m))
                {
                    items.Add(new Item() { name = pname.Text, stock = Convert.ToInt32(pquant.Text), price = Convert.ToDouble(pprice.Text) });
                    DisplayAlert("Done!", "New product added successfully", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Price and Quantity have to be a number", "OK");
                }
            }
        }
        private async void cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}