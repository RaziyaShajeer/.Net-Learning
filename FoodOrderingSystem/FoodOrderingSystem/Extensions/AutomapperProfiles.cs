using AutoMapper;
using FoodOrderingSystem.DTOs;
using FoodOrderingSystem.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace FoodOrderingSystem.Extensions
{
    public class AutomapperProfile:AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserDTo, MyUser>();
        }
    }
}
