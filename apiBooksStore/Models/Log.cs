using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.Models
{
    [Table("Log", Schema = "Logging")]
    public class Log
    {
        [Key]      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }

        private string Properties { get; set; }

    public string LogEvent { get; set; }
    
    }
}
