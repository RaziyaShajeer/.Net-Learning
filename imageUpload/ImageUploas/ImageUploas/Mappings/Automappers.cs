using AutoMapper;
using ImageUploas.Dtos;
using ImageUploas.Models;

namespace ImageUploas.Mappings
{
	public class Automappers:Profile
	{
		public Automappers() {
			CreateMap<StudentDTos, Student>().ReverseMap();
				}
	}
}
