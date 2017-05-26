using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGL.Service.Contracts;
using AGL.Service.Models;

namespace AGL.App
{
    public class Processor
    {
        private readonly IPeopleDataService _peopleDataService;

        public Processor(IPeopleDataService peopleDataService)
        {
            _peopleDataService = peopleDataService;
        }

        public async Task<IEnumerable<PetsResponseModel>> GetResponse()
        {
            var peopleData = await _peopleDataService.GetPeople();
            var catGroups = from p in peopleData
                where p.Pets != null
                group p.Pets by p.Gender
                into g
                select new PetsResponseModel
                {
                    GenderKey = g.Key,
                    Pets = g.SelectMany(pets => pets).Where(cat => cat?.Type == "Cat").OrderBy(n => n.Name).ToArray()
                };

            return catGroups;
        }
    }
}
