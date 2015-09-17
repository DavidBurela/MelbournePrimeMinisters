using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelbournePrimeMinisters.Models
{
    public class PrimeMinister
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }

        [ForeignKey("PoliticalParty")]
        public int PoliticalPartyId { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
    }

    public class PoliticalParty
    {
        public int Id { get; set; }
        public string PartyName { get; set; }
    }
}
