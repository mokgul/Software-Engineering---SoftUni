﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    partial class ForumAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aada74ff-efba-4a91-82ac-322747845ecf"),
                            Content = "Etiam penatibus arcu molestie augue commodo nostra hac faucibus eros platea, vulputate primis convallis sollicitudin pulvinar scelerisque venenatis ultrices proin ac porttitor, torquent sagittis adipiscing nullam orci laoreet euismod lectus nulla.Sociosqu gravida rhoncus parturient arcu libero, augue ligula curae finibus, quis conubia tincidunt nisl.Pharetra sed etiam nostra ullamcorper accumsan dapibus hendrerit lectus semper nisl dolor at felis, arcu erat elit metus sollicitudin faucibus egestas adipiscing ac dictumst pretium orci.Sociosqu maecenas ridiculus mus habitant nunc pellentesque libero, suspendisse mi eget non elit aenean ultrices auctor, diam faucibus nibh taciti porta egestas.Suspendisse faucibus nostra vehicula magna sagittis tempus, fusce pharetra vestibulum conubia massa lobortis nunc, vel commodo augue dictumst class.",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = new Guid("a2c3ae45-7d9a-4f93-b666-0ac4fb3ba716"),
                            Content = "er arcu ex ipsum varius risus nam, leo et iaculis nunc sodales pretium gravida, at lacinia ridiculus torquent semper.Molestie dictum magnis velit mi convallis lorem accumsan commodo pharetra purus, urna vivamus hendrerit lectus torquent ultrices penatibus inceptos vestibulum nibh nullam, fusce aliquet vitae leo montes proin vel porta luctus.Eros feugiat a nulla commodo ultrices luctus sociosqu tempus egestas, ornare lectus sem curabitur nec maximus fames ligula molestie senectus, fusce gravida rutrum torquent mus pharetra elit ex.Vel tempus sodales natoque commodo luctus curabitur gravida faucibus a leo, viverra tellus vehicula penatibus egestas ex molestie in rutrum, rhoncus venenatis conubia auctor ridiculus finibus augue sociosqu ligula.Dictum nostra aliquet elit lorem proin congue semper convallis sodales dolor, massa laoreet quam lectus mollis ultricies aptent venenatis morbi maximus, arcu condimentum metus cubilia torquent lacus lobortis primis magna.",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = new Guid("8233ac62-1c89-409e-b1d4-ec1092e42b73"),
                            Content = "Blandit phasellus feugiat lectus id rhoncus est ultricies sagittis, potenti fringilla pulvinar fames metus felis congue magnis per, nam nec natoque a nulla gravida tempus.Dis vel aenean parturient eleifend a curae nam, neque dolor leo amet laoreet taciti per quis, eros sem justo porta finibus penatibus.Condimentum velit molestie lectus hac mattis dictumst consequat nam, proin dapibus feugiat finibus mollis nullam sodales, sagittis habitant iaculis mauris in erat nisi.Ut fames inceptos facilisi potenti tempus non id augue, lacinia integer diam finibus mi mollis vel tellus, faucibus accumsan torquent platea tincidunt varius dapibus.Maximus potenti mus consequat ad consectetur interdum netus, ullamcorper quisque proin fermentum metus sed vitae arcu, conubia cubilia vestibulum enim himenaeos mauris.",
                            Title = "My third post"
                        },
                        new
                        {
                            Id = new Guid("dd6207b1-e2ea-45ad-a1b4-154e960c3b65"),
                            Content = "Lorem ipsum dolor sit amet consectetur adipiscing elit dictumst porttitor pretium nostra est dis integer hac, ullamcorper volutpat pellentesque tincidunt donec a tellus orci egestas vehicula potenti ridiculus interdum quisque.Quam placerat natoque accumsan eleifend convallis iaculis nostra facilisi, feugiat diam sit imperdiet id commodo amet quisque, parturient taciti nulla etiam ornare viverra ullamcorper.Volutpat metus ac condimentum neque ad magna sapien tincidunt, suspendisse arcu etiam sollicitudin odio lectus ex cubilia, nostra ridiculus non egestas justo id tellus.",
                            Title = "My forth post"
                        },
                        new
                        {
                            Id = new Guid("aa8bb1e5-a020-4e2f-95ec-803bea5d5a4b"),
                            Content = "Mauris malesuada iaculis duis finibus rhoncus imperdiet fames laoreet, aliquet integer adipiscing ligula est fringilla sed, consequat quis per at sagittis natoque cubilia.Accumsan litora in quis aliquam elementum lobortis purus venenatis dictumst suspendisse tincidunt mi, ut torquent tellus egestas netus vel consequat mollis neque cubilia malesuada.Id ante urna platea litora fames est lobortis iaculis, dapibus interdum parturient per augue leo rhoncus.Nostra diam rutrum nullam sagittis curabitur varius tincidunt, justo habitasse eros quam nec in, orci risus nulla efficitur viverra senectus.Tincidunt parturient suscipit ultricies lobortis quisque sem ullamcorper tempus efficitur et blandit porta enim non faucibus metus eleifend, per nullam vivamus feugiat vehicula condimentum tellus dui at commodo fusce taciti venenatis posuere sollicitudin placerat.",
                            Title = "My fifth post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
