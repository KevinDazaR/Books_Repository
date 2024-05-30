using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace Simulacro1_Solid.Models
{
    public class Book
    {
        public int Id {get;set;}

        [Required]
        public string ? Title {get;set;}

        [Required]
        public int ? Pages {get;set;}

        [Required]
        public string ? Language {get;set;}

        [Required]
        public DateTime PublicationDate {get;set;}  //DateOnly ?

        public string ? Description {get;set;}

        public string ? State {get;set;}
        
        [Required]
        public int ? AuthorId {get;set;}
        public Author Author {get;set;}
        
        [Required]
        public int ? EditorialId {get;set;}
        public Editorial Editorial {get;set;}

    }
}