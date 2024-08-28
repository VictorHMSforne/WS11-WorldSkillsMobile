using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class PagePaciente : ContentPage
    {
        public ObservableCollection<Pacientes> lista;
        List<Vacinas> listaVacinas;
        public PagePaciente()
        {
            InitializeComponent();
            lista = new ObservableCollection<Pacientes>();
            lsvPacientes.ItemsSource = lista;
            
            ServiceDbVacinas dbVacinas = new ServiceDbVacinas(App.DbPath);
            listaVacinas = dbVacinas.ListarVacinas();

            foreach (var item in listaVacinas)
            {
                pckVacina.Items.Add(item.NomeVacina);
                
            }
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) == true || string.IsNullOrEmpty(pckVacina.ToString()) == true)
                {
                    DisplayAlert("Campos Vazios!", "Por Favor Preencha os Campos!", "OK");
                }
                else
                {
                    ServiceDbPacientes dbPacientes = new ServiceDbPacientes(App.DbPath);
                    Pacientes pacientes = new Pacientes();
                    foreach (var item in lista)
                    {
                        pacientes.Nome = item.Nome;
                        pacientes.NomeVacina = item.NomeVacina;
                        pacientes.DiaTomado = item.DiaTomado;
                        pacientes.PromixaDose = item.PromixaDose;
                        dbPacientes.Inserir(pacientes);
                    }
                    
                    lista.Clear();
                    DisplayAlert("Inserção Concluída!", "Cadastro Realizado!", "OK");
                }
            }
            catch (Exception er)
            {
                DisplayAlert("Error!", er.Message, "OK");
            }
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception er)
            {
                DisplayAlert("Error!", er.Message, "OK");
            }
        }
        
        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) == true || string.IsNullOrEmpty(pckVacina.ToString()) == true)
                {
                    DisplayAlert("Campos Vazios!", "Por Favor Preencha os Campos!", "OK");
                }
                else
                {
                    Pacientes pacientes = new Pacientes();


                    SQLiteConnection conn = new SQLiteConnection(App.DbPath);
                    var query = conn.ExecuteScalar<string>("Select Validade FROM Vacinas WHERE NomeVacina='" + pckVacina.SelectedItem.ToString() + "'");

                    pacientes.Nome = txtNome.Text;
                    pacientes.NomeVacina = pckVacina.SelectedItem.ToString();
                    pacientes.DiaTomado = DateTime.Now.ToString("dd/MM/yyyy");
                    pacientes.PromixaDose = query.ToString();


                    lista.Add(pacientes);

                    lsvPacientes.ItemsSource = lista;
                    pckVacina.SelectedItem = "";
                }
               
            }
            catch (Exception er)
            {
                DisplayAlert("Error!", er.Message, "OK");
            }
        }

        private void lsvPacientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPaciente(e.SelectedItem as Pacientes);
        }
        void NavegarPaciente(Pacientes pacientes)
        {
            
                PageListarPacientes paciente = new PageListarPacientes();
                paciente.pacientes = pacientes;
                Navigation.PushAsync(paciente);
            
        }
    }
}