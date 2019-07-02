namespace InternetProvider.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberFour : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities");
            DropIndex("dbo.UserTariffEntities", new[] { "AccountEntity_Id" });
            RenameColumn(table: "dbo.UserTariffEntities", name: "AccountEntity_Id", newName: "Account_Id");
            AlterColumn("dbo.UserTariffEntities", "Account_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserTariffEntities", "Account_Id");
            AddForeignKey("dbo.UserTariffEntities", "Account_Id", "dbo.AccountEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTariffEntities", "Account_Id", "dbo.AccountEntities");
            DropIndex("dbo.UserTariffEntities", new[] { "Account_Id" });
            AlterColumn("dbo.UserTariffEntities", "Account_Id", c => c.Guid());
            RenameColumn(table: "dbo.UserTariffEntities", name: "Account_Id", newName: "AccountEntity_Id");
            CreateIndex("dbo.UserTariffEntities", "AccountEntity_Id");
            AddForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities", "Id");
        }
    }
}
