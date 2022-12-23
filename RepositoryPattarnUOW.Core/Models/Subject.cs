using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattarnUOW.Core.Models
{
   public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }



    }
}
