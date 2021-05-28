using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities
{
    public class CNPJEntity : BaseEntity
    {

        public string id_user { get; set; }

        [BsonElement("atividade_principal")]
        public List<Atividade> atividade_principal { get; set; }
        [BsonElement("atividades_secundarias")]
        public List<Atividade> atividades_secundarias { get; set; }
        [BsonElement("nome")]
        public string Nome { get; set; }       

        [BsonElement("data_situacao")]
        public string data_situacao { get; set; }
        [BsonElement("tipo")]
        public string Tipo { get; set; }
     
        [BsonElement("telefone")]
        public string telefone { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("qsa")]
        public List<QSA> qsa { get; set; }
        [BsonElement("complemento")]
        public string Complemento { get; set; }
        [BsonElement("situacao")]
        public string Situacao { get; set; }
        
        [BsonElement("uf")]
        public string Uf { get; set; }
        [BsonElement("logradouro")]
        public string Logradouro { get; set; }
        [BsonElement("bairro")]
        public string Bairro { get; set; }
        [BsonElement("numero")]
        public string Numero { get; set; }

        [BsonElement("cep")]
        public string Cep { get; set; }
        [BsonElement("municipio")]
        public string Municipio { get; set; }
        [BsonElement("porte")]
        public string Porte { get; set; }
        [BsonElement("abertura")]
        public string Abertura { get; set; }

        [BsonElement("natureza_juridica")]
        public string natureza_juridica { get; set; }

        [BsonElement("fantasia")]
        public string Fantasia { get; set; }

        [BsonElement("cnpj")]
        public string CNPJ { get; set; }

        [BsonElement("ultima_atualizacao")]
        public string ultima_atualizacao { get; set; }

        [BsonElement("capital_social")]      
        public string capital_social { get; set; }




    }

  
    public class Atividade
    {
        [BsonElement("text")]
        public string text { get; set; }
        [BsonElement("code")]
        public string code { get; set; }
    }

    public class QSA
    {
        [BsonElement("qual")]
        public string qual { get; set; }
        [BsonElement("nome")]
        public string nome { get; set; }
    }
}
