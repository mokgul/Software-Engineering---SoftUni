﻿
using Azure;
using Forum.Data.Models;
using static Azure.Core.HttpHeader;
using static Forum.Common.Validations.ValidationConstants;
namespace Forum.Data.Seeding;

using Post = Forum.Data.Models.Post;

internal class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            IList<string> titles = new List<string>()
            {
                "My first post", "My second post", "My third post", "My forth post", "My fifth post"
            };

            IList<string> contents = new List<string>()
            {
                "Etiam penatibus arcu molestie augue commodo nostra hac faucibus eros platea, vulputate primis convallis sollicitudin pulvinar scelerisque venenatis ultrices proin ac porttitor, torquent sagittis adipiscing nullam orci laoreet euismod lectus nulla.Sociosqu gravida rhoncus parturient arcu libero, augue ligula curae finibus, quis conubia tincidunt nisl.Pharetra sed etiam nostra ullamcorper accumsan dapibus hendrerit lectus semper nisl dolor at felis, arcu erat elit metus sollicitudin faucibus egestas adipiscing ac dictumst pretium orci.Sociosqu maecenas ridiculus mus habitant nunc pellentesque libero, suspendisse mi eget non elit aenean ultrices auctor, diam faucibus nibh taciti porta egestas.Suspendisse faucibus nostra vehicula magna sagittis tempus, fusce pharetra vestibulum conubia massa lobortis nunc, vel commodo augue dictumst class.",

                "er arcu ex ipsum varius risus nam, leo et iaculis nunc sodales pretium gravida, at lacinia ridiculus torquent semper.Molestie dictum magnis velit mi convallis lorem accumsan commodo pharetra purus, urna vivamus hendrerit lectus torquent ultrices penatibus inceptos vestibulum nibh nullam, fusce aliquet vitae leo montes proin vel porta luctus.Eros feugiat a nulla commodo ultrices luctus sociosqu tempus egestas, ornare lectus sem curabitur nec maximus fames ligula molestie senectus, fusce gravida rutrum torquent mus pharetra elit ex.Vel tempus sodales natoque commodo luctus curabitur gravida faucibus a leo, viverra tellus vehicula penatibus egestas ex molestie in rutrum, rhoncus venenatis conubia auctor ridiculus finibus augue sociosqu ligula.Dictum nostra aliquet elit lorem proin congue semper convallis sodales dolor, massa laoreet quam lectus mollis ultricies aptent venenatis morbi maximus, arcu condimentum metus cubilia torquent lacus lobortis primis magna.",
                "Blandit phasellus feugiat lectus id rhoncus est ultricies sagittis, potenti fringilla pulvinar fames metus felis congue magnis per, nam nec natoque a nulla gravida tempus.Dis vel aenean parturient eleifend a curae nam, neque dolor leo amet laoreet taciti per quis, eros sem justo porta finibus penatibus.Condimentum velit molestie lectus hac mattis dictumst consequat nam, proin dapibus feugiat finibus mollis nullam sodales, sagittis habitant iaculis mauris in erat nisi.Ut fames inceptos facilisi potenti tempus non id augue, lacinia integer diam finibus mi mollis vel tellus, faucibus accumsan torquent platea tincidunt varius dapibus.Maximus potenti mus consequat ad consectetur interdum netus, ullamcorper quisque proin fermentum metus sed vitae arcu, conubia cubilia vestibulum enim himenaeos mauris.",
                "Lorem ipsum dolor sit amet consectetur adipiscing elit dictumst porttitor pretium nostra est dis integer hac, ullamcorper volutpat pellentesque tincidunt donec a tellus orci egestas vehicula potenti ridiculus interdum quisque.Quam placerat natoque accumsan eleifend convallis iaculis nostra facilisi, feugiat diam sit imperdiet id commodo amet quisque, parturient taciti nulla etiam ornare viverra ullamcorper.Volutpat metus ac condimentum neque ad magna sapien tincidunt, suspendisse arcu etiam sollicitudin odio lectus ex cubilia, nostra ridiculus non egestas justo id tellus.",
                "Mauris malesuada iaculis duis finibus rhoncus imperdiet fames laoreet, aliquet integer adipiscing ligula est fringilla sed, consequat quis per at sagittis natoque cubilia.Accumsan litora in quis aliquam elementum lobortis purus venenatis dictumst suspendisse tincidunt mi, ut torquent tellus egestas netus vel consequat mollis neque cubilia malesuada.Id ante urna platea litora fames est lobortis iaculis, dapibus interdum parturient per augue leo rhoncus.Nostra diam rutrum nullam sagittis curabitur varius tincidunt, justo habitasse eros quam nec in, orci risus nulla efficitur viverra senectus.Tincidunt parturient suscipit ultricies lobortis quisque sem ullamcorper tempus efficitur et blandit porta enim non faucibus metus eleifend, per nullam vivamus feugiat vehicula condimentum tellus dui at commodo fusce taciti venenatis posuere sollicitudin placerat."
            };

            ICollection<Post> posts = new HashSet<Post>();
            for(int i = 0; i < titles.Count; i++) 
                posts.Add(new Post()
                {
                    Title = titles[i],
                    Content = contents[i],
                });
            return posts.ToArray();
        }
    }

