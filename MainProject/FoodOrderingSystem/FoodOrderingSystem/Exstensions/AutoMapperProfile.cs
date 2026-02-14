using AutoMapper;
using FoodOrderingSystem.Areas.User.Data;
using FoodOrderingSystem.Models;

namespace FoodOrderingSystem.Exstensions
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Dish,DishDTO>().ForMember(dest => dest.CategoryName,
			   opt => opt.MapFrom(src => src.category.CategoryName));
		}
	}
}
