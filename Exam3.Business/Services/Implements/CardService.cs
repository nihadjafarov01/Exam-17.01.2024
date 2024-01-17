using AutoMapper;
using Exam3.Business.Profiles;
using Exam3.Business.Repositories.Interfaces;
using Exam3.Business.Services.Interfaces;
using Exam3.Business.ViewModels.CardVMs;
using Exam3.Core.Models;

namespace Exam3.Business.Services.Implements
{
    public class CardService : ICardService
    {
        ICardRepository _repo { get; }
        IMapper _mapper { get; }
        public CardService(ICardRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IEnumerable<CardListItemVM> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<CardListItemVM>>(data);
        }
        public void Create(CardCreateVM vm)
        {
            var model = _mapper.Map<Card>(vm);
            _repo.Create(model);
        }

        public void Update(CardUpdateVM vm)
        {
            throw new NotImplementedException();
        }

        public CardUpdateVM Update(int id)
        {
            var model = _repo.GetById(id);
            var vm = _mapper.Map<CardUpdateVM>(model);
            return vm;
        }

        public void Update(int id, CardUpdateVM vm)
        {
            var model = _mapper.Map<Card>(vm);
            _repo.Save();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
