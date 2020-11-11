using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AccueilViewModel
    {
        public AccueilViewModel()
        {
            ListFormations = new List<FormationAvecAvisDto>();
        }
        public List<FormationAvecAvisDto> ListFormations { get; set; }
    }
}