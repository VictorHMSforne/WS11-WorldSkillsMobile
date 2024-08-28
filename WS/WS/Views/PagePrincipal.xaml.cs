using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void btnVacina_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageVacina());
        }

        private void btnPaciente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagePaciente());
        }

        private void btnListarPacientes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageListarPacientes());
        }

        private void btnListarPacienteVacinas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageListarPacientesVacinas());
        }

        private void btnSair_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}