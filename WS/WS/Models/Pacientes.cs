using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    [Table("Pacientes")]
    public class Pacientes
    {
        [PrimaryKey,NotNull,AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeVacina { get; set; }
        public string DiaTomado { get; set; }
        public string PromixaDose { get; set; }

        public Pacientes()
        {
            this.Id = 0;
            this.Nome = "";
            this.NomeVacina = "";
            this.DiaTomado = "";
            this.PromixaDose = "";
        }
    }
}
