using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A1.Models;

namespace A1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class history : ContentPage
    {

        ObservableCollection<HistoryItem> histitems;

        public history(ObservableCollection<HistoryItem> h)
        {
            InitializeComponent();
            histitems = h;

            ItemList.ItemsSource = histitems;
        }

        private async void mylist_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var temp= ItemList.SelectedItem as HistoryItem;
            await Navigation.PushAsync(new historydetails(temp.name, temp.quant, temp.date, temp.totalPrice));
        }
    }
}
