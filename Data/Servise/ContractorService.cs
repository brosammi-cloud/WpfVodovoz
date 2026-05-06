using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfVodovoz.Models;

namespace WpfVodovoz.Data.Servise
{
    public class ContractorService
    {
        private readonly IRepository<Contractor> Repo;

        public ContractorService(IRepository<Contractor> repo)
        {
            Repo = repo;
        }

        public IList<Contractor> GetAllСontractors()
            => Repo.GetAll();

        public void AddСontractor(Contractor contractor)
        {
            Repo.Add(contractor);
        }
        public void DeleteСontractor(Contractor contractor)
        {
            Repo.Delete(contractor);
        }
        public void UpdateСontractor(Contractor contractor)
        {
            Repo.Update(contractor);
        }
    }
}
