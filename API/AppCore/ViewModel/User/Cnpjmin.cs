using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ViewModel.User
{
    public class Cnpjmin
    {
        
        
        public string Nome { get; set; }
        public string data_situacao { get; set; }

        public string Tipo { get; set; }

        public string telefone { get; set; }

        public string Email { get; set; }
        
        public string Situacao { get; set; }
               
        public string Uf { get; set; }
        
        public string Logradouro { get; set; }
        public string Cep { get; set; }

        public string Municipio { get; set; }

        public string Porte { get; set; }
        public string Abertura { get; set; }

        public string natureza_juridica { get; set; }

        public string Fantasia { get; set; }

        public string CNPJ { get; set; }


    }
}
