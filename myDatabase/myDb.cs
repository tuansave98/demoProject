namespace myDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class myDb : DbContext
    {
        public myDb()
            : base("name=myDb")
        {
        }

        public virtual DbSet<customer> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
