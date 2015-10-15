using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Taygeta.DataAccessLayer;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Taygeta.DataAccessLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class M1
    {
        public override string Id
        {
            get { return "20151005094135_M1"; }
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("Taygeta.Repositories.Models.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .Annotation("Relational:ColumnType", "ntext");

                    b.Property<string>("HomePageTitle");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Url");

                    b.Property<DateTime?>("Wrapped");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Pages");
                });

            modelBuilder.Entity("Taygeta.Repositories.Models.Resource", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("CultureName")
                        .Annotation("MaxLength", 5);

                    b.Property<string>("Value");

                    b.Key("Name", "CultureName");

                    b.Annotation("Relational:TableName", "Resources");
                });

            modelBuilder.Entity("Taygeta.Repositories.Models.Vacancy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Closed");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Description");

                    b.Property<string>("EMail")
                        .Annotation("MaxLength", 254);

                    b.Property<string>("Location");

                    b.Property<string>("Position");

                    b.Property<DateTime>("Published");

                    b.Property<string>("Requirements");

                    b.Property<string>("Url");

                    b.Key("Id");

                    b.Annotation("Relational:TableName", "Vacancies");
                });

            modelBuilder.Entity("Taygeta.Repositories.Models.Wrapper", b =>
                {
                    b.Property<long>("PageId");

                    b.Property<int>("RecordNo");

                    b.Property<string>("FieldName")
                        .Annotation("MaxLength", 256);

                    b.Property<string>("ValuePath");

                    b.Key("PageId", "RecordNo", "FieldName");

                    b.Annotation("Relational:TableName", "Wrappers");
                });

            modelBuilder.Entity("Taygeta.Repositories.Models.Wrapper", b =>
                {
                    b.Reference("Taygeta.Repositories.Models.Page")
                        .InverseCollection()
                        .ForeignKey("PageId");
                });
        }
    }
}
