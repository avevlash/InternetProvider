namespace InternetProvider.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities");
            DropForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities");
            DropForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities");
            DropPrimaryKey("dbo.AccountEntities");
            DropPrimaryKey("dbo.UserTariffEntities");
            DropPrimaryKey("dbo.TariffEntities");
            DropPrimaryKey("dbo.ServiceEntities");
            AlterColumn("dbo.AccountEntities", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.UserTariffEntities", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.TariffEntities", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AlterColumn("dbo.ServiceEntities", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"));
            AddPrimaryKey("dbo.AccountEntities", "Id");
            AddPrimaryKey("dbo.UserTariffEntities", "Id");
            AddPrimaryKey("dbo.TariffEntities", "Id");
            AddPrimaryKey("dbo.ServiceEntities", "Id");
            AddForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities", "Id");
            AddForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities");
            DropForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities");
            DropForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities");
            DropPrimaryKey("dbo.ServiceEntities");
            DropPrimaryKey("dbo.TariffEntities");
            DropPrimaryKey("dbo.UserTariffEntities");
            DropPrimaryKey("dbo.AccountEntities");
            AlterColumn("dbo.ServiceEntities", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TariffEntities", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserTariffEntities", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.AccountEntities", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ServiceEntities", "Id");
            AddPrimaryKey("dbo.TariffEntities", "Id");
            AddPrimaryKey("dbo.UserTariffEntities", "Id");
            AddPrimaryKey("dbo.AccountEntities", "Id");
            AddForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserTariffEntities", "AccountEntity_Id", "dbo.AccountEntities", "Id");
        }
    }
}
