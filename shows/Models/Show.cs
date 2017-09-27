using System.ComponentModel.DataAnnotations;

namespace shows.Models {
    public class Show {
        [Required]
        [MinLength(2)]
        public string Title {get; set;}
        [Required]
        [MinLength(10)]
        public string Description {get; set;}
        [Required]
        [MinLength(2)]
        public string Network {get; set;}
    }
}