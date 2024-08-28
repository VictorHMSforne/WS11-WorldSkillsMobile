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
    public partial class PageVacina : ContentPage
    {
        public PageVacina()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) == true)
                {
                    DisplayAlert("Campos Vazios!", "Preencha os Campos!", "OK");
                }
                else
                {
                    ServiceDbVacinas dbVacinas = new ServiceDbVacinas(App.DbPath);
                    Vacinas vacinas = new Vacinas();

                    vacinas.NomeVacina = txtNome.Text;
                    vacinas.Validade = dtpValidade.Date.ToString("dd/MM/yyyy");
                    dbVacinas.Inserir(vacinas);
                    DisplayAlert("Inserção!", "Vacina Cadastrada com Sucesso!", "OK");

                    txtNome.Text = "";
                    dtpValidade.Date = DateTime.Now;
                }
            }
            catch (Exception er)
            {
                DisplayAlert("Error!", er.Message, "OK");
            }
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}