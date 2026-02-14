namespace MVCSample.DTOs
{
	public class StudentDTo
	{
		
		public string Name { get; set; }
		public string Description { get; set; }

		public string emaiId { get; set; }

		public string Password { get; set; }
		public IFormFile imagefile { get; set; }	
	}
}
