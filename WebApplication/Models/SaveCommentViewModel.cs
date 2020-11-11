using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SaveCommentViewModel
    {
        public string Commentaire { get;  set; }
        public string NomPersonne { get;  set; }
        public string Note { get;  set; }
        public string NomSeo { get;  set; }
    }
}