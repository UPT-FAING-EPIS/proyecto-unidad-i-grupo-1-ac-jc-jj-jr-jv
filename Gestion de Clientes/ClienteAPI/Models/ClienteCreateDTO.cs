using System;
using System.Collections.Generic;

namespace ClienteAPI.Models
{
    public class ClienteCreateDTO
    {
        public string NomCliente { get; set; }

        public string ApePaterno { get; set; }

        public string ApeMaterno { get; set; }

        public int Numero { get; set; }

        public string Genero { get; set; }
    }

}
