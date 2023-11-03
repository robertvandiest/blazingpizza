using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Application.Ordering.Mappers;
using BlazingPizza.Domain.Ordering;
using BlazingPizza.Domain.Ordering.Entities;

namespace BlazingPizza.Application.Ordering.Services
{
    public class PizzaService
    {
        private IUnitOfWork _unitOfWork;

        public PizzaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PizzaSpecialDto> GetPizzaSpecials()
        {
            return _unitOfWork.Specials
                .FindAll<PizzaSpecial>()
                .Select(PizzaSpecialMapper.ToPizzaSpecialDto);
        }
    }
}
