using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DbAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int uniqueNumber { get; set; }
    }
}