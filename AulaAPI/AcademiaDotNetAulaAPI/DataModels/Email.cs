using System.Text.Json.Serialization;

namespace CA_Entity.DataModels
{
    public class Email
    {
        public int id { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public virtual Pessoa? pessoa { get; set; }
    }
}
