using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbVacinas
    {
        SQLiteConnection conn;
        public ServiceDbVacinas(string dbPath) 
        {
            if (dbPath == "")
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Vacinas>();
        
        }

        public List<Vacinas> ListarVacinas()
        {
            try
            {
                List<Vacinas> li = new List<Vacinas>();
                li = conn.Table<Vacinas>().ToList();
                return li;
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        public void Inserir(Vacinas vacinas)
        {
            try
            {
                conn.Insert(vacinas);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
