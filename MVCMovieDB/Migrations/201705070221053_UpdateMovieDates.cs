namespace MVCMovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieDates : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = '20060306', DateAdded = '20170606'  WHERE Id = 1");
            Sql("UPDATE Movies SET ReleaseDate = '20070107', DateAdded = '20170606'  WHERE Id = 2");
            Sql("UPDATE Movies SET ReleaseDate = '20080909', DateAdded = '20170606'  WHERE Id = 3");
            Sql("UPDATE Movies SET ReleaseDate = '20100712', DateAdded = '20170606'  WHERE Id = 4");
            Sql("UPDATE Movies SET ReleaseDate = '20020619', DateAdded = '20170606'  WHERE Id = 5");
            Sql("UPDATE Movies SET ReleaseDate = '20120210', DateAdded = '20170606'  WHERE Id = 6");

        }

        public override void Down()
        {
        }
    }
}
