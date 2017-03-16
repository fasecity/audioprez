namespace audiopretzel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMusicTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Musics (Name,Artist,Genre,Path) VALUES ('almost', 'fasecity', 'electronic', '/Tunes/almost.mp3')");
            Sql("INSERT INTO Musics (Name,Artist,Genre,Path) VALUES ('a-minor', 'fasecity', 'electronic', '/Tunes/aminor1.mp3')");
            Sql("INSERT INTO Musics (Name,Artist,Genre,Path) VALUES ('funk me baby', 'fasecity', 'electronic', '/Tunes/BASSFUNK2016.mp3')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Musics WHERE Artist IN ('fasecity')");
        }
    }
}
