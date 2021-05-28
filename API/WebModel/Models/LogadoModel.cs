using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Model.Models
{
    public class LogadoModel
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }

    //public class Root
    //{
    //    public User user { get; set; }
    //    public string token { get; set; }
    //}

}
