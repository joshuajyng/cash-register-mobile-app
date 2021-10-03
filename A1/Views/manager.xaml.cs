using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using A1.Models;
namespace A1.Views

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class manager : ContentPage
    {
        ObservableCollection<Item> i;
        ObservableCollection<HistoryItem> h;
        public manager(ObservableCollection<Item> items, ObservableCollection<HistoryItem> histitems)
        {
            InitializeComponent();
            i = items;
            h = histitems;
        }



        async void navToHistory(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new history(h));
        }

        async void navToRestock(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new restock());
        }

        async void navToNewProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new addnewprod(i));
        }

    }
}