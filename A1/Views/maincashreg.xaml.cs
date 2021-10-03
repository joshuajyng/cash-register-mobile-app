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
    public partial class maincashreg : ContentPage
    {

        bool itemSelected = false;
        public static ObservableCollection<Item> items { get; set; }
        public static ObservableCollection<HistoryItem> histitems { get; set; }

        public maincashreg()
        {
            InitializeComponent();

            items = new ObservableCollection<Item>
            {
                new Item(){name="Pants", stock=20, price=50.7 },
                new Item(){name="Shoes", stock=45, price=90 },
                new Item(){name="Hats", stock=10, price=20.5 },
                new Item(){name="Tshirts", stock=10, price=15.5 },
                new Item(){name="Dresses", stock=24, price=140.3 },
                new Item(){name="Socks", stock=50, price=99.9 }
            };
            ItemList.ItemsSource = items;
            histitems = new ObservableCollection<HistoryItem>
            {

            };
        }
        public void mylist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if(this.ItemList.SelectedItem != null)
            {
                ItemType.Text = (e.SelectedItem as Item).name;
                itemSelected = true;
            }
            
            
        }
        public void numClicked(System.Object sender, System.EventArgs e)
        {
            if (itemSelected)
            {
                if (ItemQuantity.Text == "Quantity" || ItemQuantity.Text == "0")
                {
                    ItemQuantity.Text = ((Button)sender).Text;
                }
                else
                {
                    ItemQuantity.Text = ItemQuantity.Text + ((Button)sender).Text;

                }
                updateTotal(sender);
            }
            
        }
        void updateTotal(System.Object sender)
        {
            if (ItemQuantity.Text == "Quantity" || ItemQuantity.Text=="0")
            {
                TotalCost.Text = "0";
            }
            else
            {
                double tempPrice = (ItemList.SelectedItem as Item).price;
                int tempQuant = Convert.ToInt32(ItemQuantity.Text);
                TotalCost.Text = Convert.ToString(tempPrice * tempQuant);
            }
            
        }

        public void buyItem(System.Object sender,System.EventArgs e)
        {
            if (ItemQuantity.Text != "Quantity")
            {
                if (Convert.ToInt32(ItemQuantity.Text) > ((ItemList.SelectedItem as Item).stock))
                {
                    DisplayAlert("Not Enough Items in Stock", "Selected quantity is more than available stock", "Ok");
                }
                else
                {
                    histitems.Add(new HistoryItem() {name=ItemType.Text, quant= Convert.ToInt32(ItemQuantity.Text), date = DateTime.Now.ToString(),  totalPrice = Convert.ToDouble(TotalCost.Text)});
                    (ItemList.SelectedItem as Item).stock -= Convert.ToInt32(ItemQuantity.Text);
                    this.ItemList.SelectedItem = null;
                    itemSelected = false;
                    ItemType.Text = "Type";
                    ItemQuantity.Text = "Quantity";
                    TotalCost.Text = "Total";

                }
            }
           
        }
        public void clearQuant(System.Object sender, System.EventArgs e)
        {
            ItemQuantity.Text = "0";
        }

        async void navToManager(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new manager(items, histitems));
        }

    }

}