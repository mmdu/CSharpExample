namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershiptype : DbMigration
    {
        public override void Up()
        {
            

            Sql("UPDATE  MembershipTypes  SET Name = 'Pay As Go' WHERE  Id=1");
            Sql("UPDATE  MembershipTypes  SET Name = 'By Month' WHERE  Id=2 ");
            Sql("UPDATE  MembershipTypes  SET Name = 'By Quator' WHERE Id=3 ");
            Sql("UPDATE  MembershipTypes  SET Name = 'By Year' WHERE Id=4");


        }

        public override void Down()
        {
        }
    }
}
