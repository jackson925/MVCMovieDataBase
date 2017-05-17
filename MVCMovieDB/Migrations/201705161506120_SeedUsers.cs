namespace MVCMovieDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
             INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a03d0bb7-77b1-4b39-afb9-89d81f30707a', N'User@MovieDB.com', 0, N'ACyGz72k+ga6frEWs93JgcC0Up9PwKSnPb6Bye64naOD9+Dmmq8Yt+ldW1pxgUZ4Pg==', N'0c860153-31da-444c-a98a-0547ad516cef', NULL, 0, 0, NULL, 1, 0, N'User@MovieDB.com')
             INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f999b964-333a-45ca-8d6d-23247847023b', N'Admin@MovieDb.com', 0, N'AL2Ujx5ui2X/C2oz7cwWlya0KotX8nUSgdF/p29VKKrrv7+8+7QxvVkZh6kGg7dRFQ==', N'4098e438-1c79-4feb-9916-8670d02d3c27', NULL, 0, 0, NULL, 1, 0, N'Admin@MovieDb.com')
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b935c74c-0c67-4f15-90bb-391e9ef4a977', N'CanManageMovies')
             INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f999b964-333a-45ca-8d6d-23247847023b', N'b935c74c-0c67-4f15-90bb-391e9ef4a977')
             
");
        }
        
        public override void Down()
        {
        }
    }
}
