using Publi24.Validators;
using System.ComponentModel.DataAnnotations;

namespace Publi24.BMs
{
    public class CompanyCreateBM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Exchange { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        [CustomIsinValidator]
        public string Isin { get; set; }
        public string Website { get; set; }
    }
}
