namespace audiopretzel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbsetMusic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Artist = c.String(),
                        Genre = c.String(),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musics");
        }
    }
}
