using System.Data.Entity.Migrations;

namespace Based.DataAccess.Migrations
{
    public partial class CreateDetailTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 64, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 64, unicode: false),
                        StreetNumber = c.Int(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 128, unicode: false),
                        Address2 = c.String(maxLength: 128, unicode: false),
                        Address3 = c.String(maxLength: 128, unicode: false),
                        City = c.String(nullable: false, maxLength: 64, unicode: false),
                        State = c.String(nullable: false, maxLength: 16, unicode: false),
                        PostalCode = c.Int(nullable: false),
                        PrimaryPhone = c.String(nullable: false, maxLength: 10, unicode: false),
                        SecondaryPhone = c.String(maxLength: 10, unicode: false),
                        EmailAddress = c.String(maxLength: 512, unicode: false),
                        RowVersionDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        RowVersionUser = c.String(nullable: false, maxLength: 64, defaultValueSql: "SYSTEM_USER", unicode: false),
                        DeletedDate = c.DateTime(),
                        RowCreatedDate = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        RowCreatedUser = c.String(nullable: false, maxLength: 64, defaultValueSql: "SYSTEM_USER", unicode: false)
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Detail");
        }
    }
}
