using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A1.Models;


namespace A1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class restock : ContentPage
    {
        bool itemSelected = false;
        public restock()
        {
            InitializeComponent();
            ItemList.ItemsSource = maincashreg.items;
        }


        public void restockItem(object sender, EventArgs e)
        {
            if (entry.Text == null || itemSelected == false)
            {
                DisplayAlert("Error", "You have to select an Item and provide a new quantity", "OK");
            }
            else
            {
                if (int.TryParse(entry.Text, out int n))
                {
                    (ItemList.SelectedItem as Item).stock += Convert.ToInt32(entry.Text);
                    entry.Text = null;
                    this.ItemList.SelectedItem = null;
                    itemSelected = false;
                }
                else
                {
                    DisplayAlert("Error", "Value has to be a number", "OK");
                }
            }
        }
        private async void cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public void mylist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (this.ItemList.SelectedItem != null)
            {
                itemSelected = true;
            }


        }
    }
}