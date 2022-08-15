namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comdey')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
