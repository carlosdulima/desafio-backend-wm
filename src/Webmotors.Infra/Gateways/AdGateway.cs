using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.Queries;
using Webmotors.Infra.Repositories.Interfaces;

namespace Webmotors.Infra.Gateways
{
    public class AdGateway : IAdGateway
    {
        private readonly IAdRepository _repository;

        public AdGateway(IAdRepository repository)
        {
            _repository = repository;
        }

        public Task<Ad> Create(Ad ad)
        {
            _repository.Add(ad);
            _repository.Save();
            return Task.FromResult(ad);
        }

        public Task Delete(Ad ad)
        {
            _repository.Delete(ad);
            _repository.Save();
            return Task.FromResult(ad);
        }

        public Task<Ad> Get(int id)
        {
            return Task.FromResult(_repository.Get(id));
        }

        public Task<IEnumerable<Ad>> GetAll()
        {
            return Task.FromResult(_repository.GetAll().AsEnumerable());
        }

        public Task<IEnumerable<Ad>> GetAll(AdQuery adQuery)
        {
            var query = _repository.GetAll();

            if (adQuery?.Id > 0)
                query = query.Where(x => x.Id == adQuery.Id.Value);

            return Task.FromResult(query.AsEnumerable());
        }

        public Task<Ad> Upsert(Ad ad)
        {
            _repository.Save();
            return Task.FromResult(ad);
        }
    }
}
