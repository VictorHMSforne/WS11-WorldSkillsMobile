using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    [Table("Vacinas")]
    public class Vacinas
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        public string NomeVacina { get; set; }
        public string Validade { get; set; }

        public Vacinas()
        {
            this.Id = 0;
            this.NomeVacina = "";
            this.Validade = "";
        }
    }
}
