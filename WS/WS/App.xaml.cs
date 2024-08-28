using System;
using WS.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS
{
    public partial class App : Application
    {
        public static string DbPath;
        public static string DbName;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PagePrincipal());
        }
        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.DbPath = dbPath;
            App.DbName = dbName;
            MainPage = new NavigationPage(new PagePrincipal());
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
