using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbPacientes
    {
        SQLiteConnection conn;
        public ServiceDbPacientes(string dbPath)
        {
            if (dbPath == "")
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Pacientes>();

        }

        public List<Pacientes> ListarPacientes()
        {
            try
            {
                List<Pacientes> li = new List<Pacientes>();
                li = conn.Table<Pacientes>().ToList();
                return li;
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        public void Inserir(Pacientes pacientes)
        {
            try
            {
                conn.Insert(pacientes);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
