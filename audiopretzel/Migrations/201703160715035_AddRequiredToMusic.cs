namespace audiopretzel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToMusic : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musics", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Musics", "Artist", c => c.String(nullable: false));
            AlterColumn("dbo.Musics", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Musics", "Path", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musics", "Path", c => c.String());
            AlterColumn("dbo.Musics", "Genre", c => c.String());
            AlterColumn("dbo.Musics", "Artist", c => c.String());
            AlterColumn("dbo.Musics", "Name", c => c.String());
        }
    }
}
