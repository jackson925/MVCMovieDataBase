namespace MVCMovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationPopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (1, 'Shrek', 'Comedy', 2/12/2004, 06/06/2017, 5)");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (2, 'A Beautiful Mind', 'Drama', 2/12/2000, 06/06/2017, 4)");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (3, 'Tropic Thunder', 'Comedy', 2/12/2008, 06/06/2017, 2)");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (4, 'Interstellar', 'Drama', 2/12/2015, 06/06/2017, 6)");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (5, 'Where The Wild Things Are', 'Comedy', 2/12/2012, 06/06/2017, 10)");
            Sql("INSERT INTO Movies (Id, Name, Genre, ReleaseDate, DateAdded, Stock) VALUES (6, 'Anchorman', 'Comedy', 2/12/2008, 06/06/2017, 7)");

        }

        public override void Down()
        {
        }
    }
}
