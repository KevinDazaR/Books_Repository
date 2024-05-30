using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace Simulacro1_Solid.Models
{

    public class Editorial
    {
        
        public int Id {get;set;}

        [Required]

        public string ? Name {get;set;}
        
        [Required]
        public string ? Address {get;set;}

        [Required]
        public string ? Phone {get;set;}

        [Required]
        public string ? Email {get;set;}

        public string ? State {get;set;}

        // [JsonIgnore]
        // public List<Book> ? Books {get;set;}
    }
}
