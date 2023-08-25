using SQLite;

namespace ExploreCity.Models
{
    public class UserModel //razones de cambio: 1-necesidad de registro de metadata de auditoria
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
