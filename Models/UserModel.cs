using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExploreCity.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
    }
}
