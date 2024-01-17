using AutoMapper;
using Exam3.Business.ViewModels.CardVMs;
using Exam3.Core.Models;
using Microsoft.AspNetCore.Hosting;

namespace Exam3.Business.Services.Implements
{
    public class CardService : ICardService
    {
        IWebHostEnvironment _env { get; }
        ICardRepository _repo { get; }
        IMapper _mapper { get; }
        public CardService(ICardRepository repo, IMapper mapper, IWebHostEnvironment env)
        {
            _repo = repo;
            _mapper = mapper;
            _env = env;
        }
        public IEnumerable<CardListItemVM> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<CardListItemVM>>(data);
        }
        public void Create(CardCreateVM vm)
        {
            var model = _mapper.Map<Card>(vm);
            //string filePath = Path.Combine("images", "cards", vm.ImageFile.FileName);
            //using (FileStream fs = System.IO.File.Create(Path.Combine(_env.WebRootPath, filePath)))
            //{
            //    vm.ImageFile.CopyTo(fs);
            //}
            //model.ImageUrl = filePath;
            _repo.Create(model);
        }

        public CardUpdateVM Update(int id)
        {
            var model = _repo.GetById(id);
            var vm = _mapper.Map<CardUpdateVM>(model);
            return vm;
        }

        public void Update(int id, CardUpdateVM vm)
        {
            var model = _repo.GetById(id);
            model = _mapper.Map(vm,model);
            //if (vm.ImageFile != null)
            //{
            //    _mapper.Map(vm, model);
            //    string filePath = Path.Combine("images", "cards", vm.ImageFile.FileName);
            //    using (FileStream fs = System.IO.File.Create(Path.Combine(_env.WebRootPath, filePath)))
            //    {
            //        vm.ImageFile.CopyTo(fs);
            //    }
            //    model.ImageUrl = filePath;
            //}
            //else
            //{
            //    model.Title = vm.Title;
            //    model.Description = vm.Description;
            //}
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
