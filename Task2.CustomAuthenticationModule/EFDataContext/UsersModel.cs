using System.Data.Entity;

namespace Task2.CustomAuthenticationModule.EFDataContext
{
    public partial class UsersModel : DbContext
    {
        public UsersModel() : base("name=UsersContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}