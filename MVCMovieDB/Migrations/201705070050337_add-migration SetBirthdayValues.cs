namespace MVCMovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationSetBirthdayValues : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = 2/3/1994 WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = 2/3/1983 WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate = 2/3/1994 WHERE Id = 3");
            Sql("UPDATE Customers SET Birthdate = 2/3/1994 WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
