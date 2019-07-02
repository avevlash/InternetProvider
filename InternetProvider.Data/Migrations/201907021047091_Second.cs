namespace InternetProvider.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities");
            DropForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities");
            DropIndex("dbo.UserTariffEntities", new[] { "Tariff_Id" });
            DropIndex("dbo.TariffEntities", new[] { "Service_Id" });
            AlterColumn("dbo.UserTariffEntities", "Tariff_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.TariffEntities", "Service_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.UserTariffEntities", "Tariff_Id");
            CreateIndex("dbo.TariffEntities", "Service_Id");
            AddForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities");
            DropForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities");
            DropIndex("dbo.TariffEntities", new[] { "Service_Id" });
            DropIndex("dbo.UserTariffEntities", new[] { "Tariff_Id" });
            AlterColumn("dbo.TariffEntities", "Service_Id", c => c.Guid());
            AlterColumn("dbo.UserTariffEntities", "Tariff_Id", c => c.Guid());
            CreateIndex("dbo.TariffEntities", "Service_Id");
            CreateIndex("dbo.UserTariffEntities", "Tariff_Id");
            AddForeignKey("dbo.TariffEntities", "Service_Id", "dbo.ServiceEntities", "Id");
            AddForeignKey("dbo.UserTariffEntities", "Tariff_Id", "dbo.TariffEntities", "Id");
        }
    }
}
