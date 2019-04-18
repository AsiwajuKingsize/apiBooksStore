using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.DTO
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }
    }
}
