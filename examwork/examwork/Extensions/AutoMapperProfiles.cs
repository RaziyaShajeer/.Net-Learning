using examwork.DTO;
using examwork.Models;

namespace examwork.Extensions
{
    public class AutoMapperProfiles:AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDTO, student>();
        }
    }
}
