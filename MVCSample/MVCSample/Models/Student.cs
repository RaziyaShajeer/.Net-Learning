namespace MVCSample.Models
{
    public class Student
    {
        public Guid Id { get; set; }=Guid.NewGuid(); 
        public string Name { get; set; }
        public string Description { get; set; }

        public string emaiId { get; set; }

        public string Password {  get; set; }
        public byte[] Image { get; set; }
        

    }
}
