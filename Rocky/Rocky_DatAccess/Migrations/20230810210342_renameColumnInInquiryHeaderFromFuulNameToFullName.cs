using Microsoft.EntityFrameworkCore.Migrations;

namespace Rocky_DatAccess.Migrations
{
    public partial class renameColumnInInquiryHeaderFromFuulNameToFullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FuulName",
                table: "InquiryHeader",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "InquiryHeader",
                newName: "FuulName");
        }
    }
}
