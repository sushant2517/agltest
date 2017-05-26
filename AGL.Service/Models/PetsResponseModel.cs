using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGL.Domain;

namespace AGL.Service.Models
{
    public class PetsResponseModel
    {
        public string GenderKey { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
    }
}
