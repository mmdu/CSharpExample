namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdayRecordofCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday=CAST('1980-01-01' AS DATETIME) WHERE Id=1");
            Sql("UPDATE Customers SET Birthday= NULL WHERE Id=2");

        }

        public override void Down()
        {
        }
    }
}
