using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A1.Views;


namespace A1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new maincashreg());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
