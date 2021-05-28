using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model.Models
{

    public class Cnp
    {
        public string nome { get; set; }
        public string data_situacao { get; set; }
        public string tipo { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string situacao { get; set; }
        public string uf { get; set; }
        public string logradouro { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
        public string porte { get; set; }
        public string abertura { get; set; }
        public string natureza_juridica { get; set; }
        public string fantasia { get; set; }
        public string cnpj { get; set; }
    }

    public class CnpjzModel
{
        public List<Cnp> cnps { get; set; }
    }


}
