using AutoMapper;
using FoodOrderingSystem.DTO;
using FoodOrderingSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace FoodOrderingSystem.Extensions
{
    public class AutomapperProfile:AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserDTO, MyUser>();
            CreateMap<CategoryDto, Category>();
            CreateMap<RestaurentProfileDTO, RestaurantProfile>();
            CreateMap<Category, EditCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<DishDTO, Dish>().ReverseMap();
            CreateMap<Dish,DishViewDTO>().ForMember(dest
                =>dest.CategoryName,opt=>opt.MapFrom(e=>e.category.CategoryName)).ForMember(dest=>dest.RestaurantName,opt=>opt.MapFrom(opt=>opt.Restaurant.RestaurantName));
            CreateMap<Dish, EditViewDishDTO>().ForMember(dest=> dest.RestaurantName,src=>src.MapFrom(e=>e.Restaurant.RestaurantName));   
        }
    }
}
