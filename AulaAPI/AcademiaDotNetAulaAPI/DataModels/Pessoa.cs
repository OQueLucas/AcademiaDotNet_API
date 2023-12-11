using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CA_Entity.DataModels
{
    public class Pessoa
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [JsonIgnore]
        public virtual ICollection<Email>? Emails { get; set; }
    }
}
