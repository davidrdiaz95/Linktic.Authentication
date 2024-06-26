namespace Linktic.Authentication.Repository.Entity
{
	public class Login
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
		public int FkIdRol { get; set; }
		public Rol Rol { get; set; }
    }
}
