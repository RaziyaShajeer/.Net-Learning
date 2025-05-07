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
        }
    }
}
