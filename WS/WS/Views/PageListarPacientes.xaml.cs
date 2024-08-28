using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Models;
using WS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListarPacientes : ContentPage
    {
        public Pacientes pacientes;
        public PageListarPacientes()
        {
            InitializeComponent();
            ServiceDbPacientes dbPacientes = new ServiceDbPacientes(App.DbPath);
            lsvPacientes.ItemsSource = dbPacientes.ListarPacientes();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception er)
            {
                DisplayAlert("Erro!", er.Message, "OK");
            }
        }
    }
}