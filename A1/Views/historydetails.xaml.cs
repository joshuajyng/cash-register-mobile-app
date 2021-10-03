using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class historydetails : ContentPage
    {
        public historydetails(string name, int quant, string date, double price)
        {
            InitializeComponent();
            iname.Text = name;
            iquant.Text = Convert.ToString(quant);
            idate.Text = date;
            itotal.Text = "Total amount: "+ Convert.ToString(price);
            
        }
    }
}