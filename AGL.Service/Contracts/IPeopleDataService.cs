using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGL.Domain;

namespace AGL.Service.Contracts
{
    public interface IPeopleDataService
    {
        Task<IEnumerable<Person>> GetPeople();
    }
}
