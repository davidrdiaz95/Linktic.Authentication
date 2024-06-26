namespace Linktic.Authentication.Repository.Entity
{
	public class Rol
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public List<Login> Login { get; set; }
	}
}
