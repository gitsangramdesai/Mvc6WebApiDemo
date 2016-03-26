using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WebApplication1.EFRepositoy;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20160326171922_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Call", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<Guid>("ContactId");

                    b.Property<int>("DurationInMinutes");

                    b.Property<string>("FollowUpAddress");

                    b.Property<DateTime>("FollowUpDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<byte>("Prospect");

                    b.Property<string>("Purpose");

                    b.Property<byte>("Rating");

                    b.Property<string>("Status");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("WebApplication1.Models.Contact", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<DateTime>("AnniversaryDate");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsFamilyMember");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<DateTime>("ModifiedDate");

                    b.HasKey("ID");
                });
        }
    }
}
