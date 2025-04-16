namespace ImageUploas.Dtos
{
	public class StudentDTos
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public IFormFile Image { get; set; }
	}
}
