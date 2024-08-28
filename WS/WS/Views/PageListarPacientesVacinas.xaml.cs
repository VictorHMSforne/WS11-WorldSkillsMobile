using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListarPacientesVacinas : ContentPage
    {
        public PageListarPacientesVacinas()
        {
            InitializeComponent();
            ServiceDbVacinas dbVacinas = new ServiceDbVacinas(App.DbPath);
            lsvVacinas.ItemsSource = dbVacinas.ListarVacinas();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}