using System.Data.Entity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MangaShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new Initp());
        }

        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ContactInfo> ContactsInfo { get; set; }
        public DbSet<Cart> Carts { get; set; }
        //public DbSet<Cart> Orders { get; set; }
        public DbSet<Region> Regions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Initp : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext ctx)
        {
            Region region1 = new Region { RegionId = 1, Name = "Alba" };
            Region region2 = new Region { RegionId = 2, Name = "Arad" };
            Region region3 = new Region { RegionId = 3, Name = "Argeș" };
            Region region4 = new Region { RegionId = 4, Name = "Bacău" };

            ctx.Regions.Add(region1);
            ctx.Regions.Add(region2);
            ctx.Regions.Add(region3);
            ctx.Regions.Add(region4);
            ctx.Regions.Add(new Region { RegionId = 5, Name = "Bihor" });
            ctx.Regions.Add(new Region { RegionId = 6, Name = "Bistrița-Năsăud" });
            ctx.Regions.Add(new Region { RegionId = 7, Name = "Botoșani" });
            ctx.Regions.Add(new Region { RegionId = 8, Name = "Brașov" });
            ctx.Regions.Add(new Region { RegionId = 9, Name = "Brăila" });
            ctx.Regions.Add(new Region { RegionId = 10, Name = "Buzău" });
            ctx.Regions.Add(new Region { RegionId = 11, Name = "Caraș-Severin" });
            ctx.Regions.Add(new Region { RegionId = 12, Name = "Cluj" });
            ctx.Regions.Add(new Region { RegionId = 13, Name = "Constanța" });
            ctx.Regions.Add(new Region { RegionId = 14, Name = "Covasna" });
            ctx.Regions.Add(new Region { RegionId = 15, Name = "Dâmbovița" });
            ctx.Regions.Add(new Region { RegionId = 16, Name = "Dolj" });
            ctx.Regions.Add(new Region { RegionId = 17, Name = "Galați" });
            ctx.Regions.Add(new Region { RegionId = 18, Name = "Gorj" });
            ctx.Regions.Add(new Region { RegionId = 19, Name = "Harghita" });
            ctx.Regions.Add(new Region { RegionId = 20, Name = "Hunedoara" });
            ctx.Regions.Add(new Region { RegionId = 21, Name = "Ialomița" });
            ctx.Regions.Add(new Region { RegionId = 22, Name = "Iași" });
            ctx.Regions.Add(new Region { RegionId = 23, Name = "Ilfov" });
            ctx.Regions.Add(new Region { RegionId = 24, Name = "Maramureș" });
            ctx.Regions.Add(new Region { RegionId = 25, Name = "Mehedinți" });
            ctx.Regions.Add(new Region { RegionId = 26, Name = "Mureș" });
            ctx.Regions.Add(new Region { RegionId = 27, Name = "Neamț" });
            ctx.Regions.Add(new Region { RegionId = 28, Name = "Olt" });
            ctx.Regions.Add(new Region { RegionId = 29, Name = "Prahova" });
            ctx.Regions.Add(new Region { RegionId = 30, Name = "Satu Mare" });
            ctx.Regions.Add(new Region { RegionId = 31, Name = "Sălaj" });
            ctx.Regions.Add(new Region { RegionId = 32, Name = "Sibiu" });
            ctx.Regions.Add(new Region { RegionId = 33, Name = "Suceava" });
            ctx.Regions.Add(new Region { RegionId = 34, Name = "Teleorman" });
            ctx.Regions.Add(new Region { RegionId = 35, Name = "Timiș" });
            ctx.Regions.Add(new Region { RegionId = 36, Name = "Tulcea" });
            ctx.Regions.Add(new Region { RegionId = 37, Name = "Vaslui" });
            ctx.Regions.Add(new Region { RegionId = 38, Name = "Vâlcea" });
            ctx.Regions.Add(new Region { RegionId = 39, Name = "Vrancea" });
            ctx.Regions.Add(new Region { RegionId = 40, Name = "București" });
            ctx.Regions.Add(new Region { RegionId = 41, Name = "București-Sector 1" });
            ctx.Regions.Add(new Region { RegionId = 42, Name = "București-Sector-2" });
            ctx.Regions.Add(new Region { RegionId = 43, Name = "București-Sector-3" });
            ctx.Regions.Add(new Region { RegionId = 44, Name = "București-Sector-4" });
            ctx.Regions.Add(new Region { RegionId = 45, Name = "București-Sector 5" });
            ctx.Regions.Add(new Region { RegionId = 46, Name = "București - Sector 6" });
            ctx.Regions.Add(new Region { RegionId = 51, Name = "Călărași" });
            ctx.Regions.Add(new Region { RegionId = 52, Name = "Giurgiu" });

            ContactInfo contact1 = new ContactInfo
            {
                PhoneNumber = "0712345678",
                BirthDay = "16",
                BirthMonth = "03",
                BirthYear = 1991,
                CNP = "2910316014007",
                GenderType = Gender.Female,
                RegionId = region1.RegionId
            };

            ContactInfo contact2 = new ContactInfo
            {
                PhoneNumber = "0713345878",
                BirthDay = "07",
                BirthMonth = "04",
                BirthYear = 2002,
                CNP = "6020407023976",
                GenderType = Gender.Female,
                RegionId = region2.RegionId
            };

            ContactInfo contact3 = new ContactInfo
            {
                PhoneNumber = "0711345678",
                BirthDay = "30",
                BirthMonth = "10",
                BirthYear = 2002,
                CNP = "5021030031736",
                GenderType = Gender.Male,
                RegionId = region3.RegionId
            };

            ContactInfo contact4 = new ContactInfo
            {
                PhoneNumber = "0712665679",
                BirthDay = "13",
                BirthMonth = "05",
                BirthYear = 1986,
                CNP = "2860513040701",
                GenderType = Gender.Female,
                RegionId = region4.RegionId
            };

            ctx.ContactsInfo.Add(contact1);
            ctx.ContactsInfo.Add(contact2);
            ctx.ContactsInfo.Add(contact3);
            ctx.ContactsInfo.Add(contact4);

            Publisher Publisher1 = new Publisher { Name = "Publisher1", ContactInfo = contact1 };
            Publisher Publisher2 = new Publisher { Name = "Publisher2", ContactInfo = contact2 };
            Publisher Publisher3 = new Publisher { Name = "Publisher3", ContactInfo = contact3 };
            Publisher Publisher4 = new Publisher { Name = "Publisher4", ContactInfo = contact4 };

            ctx.Publishers.Add(Publisher1);
            ctx.Publishers.Add(Publisher2);
            ctx.Publishers.Add(Publisher3);
            ctx.Publishers.Add(Publisher4);

            ctx.Mangas.Add(new Manga
            {
                Title = "Attack On Titan",
                Author = "Hajime Isayama",
                Summary = "The series is based on a fictional story of humanity’s last stand against man-eating giant creatures known as Titans",
                Price = 23,
                Image = "~/Content/public/themes/images/manga_images/AttackOnTitan.jpg",
                NoOfPages = 112,
                VolumeNumber = 7,
                Publisher = Publisher1,
                PublisherId = Publisher1.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Action"},
                    new Genre { Name = "Dark fantasy"},
                    new Genre { Name = "Post-apocalyptic"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "20th Century Boys",
                Author = "Naoki Urasawa",
                Summary = "It tells the story of Kenji Endō and his friends, who notice a cult-leader known only as `Friend` is out to destroy the world, and it has something to do with their childhood memories",
                Price = 30,
                Image = "~/Content/public/themes/images/manga_images/20th Century Boys.jpg",
                NoOfPages = 150,
                VolumeNumber = 2,
                Publisher = Publisher2,
                PublisherId = Publisher2.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Mystery"},
                    new Genre { Name = "Science fiction"},
                    new Genre { Name = "Thriller"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Berserk",
                Author = "Kentaro Miura",
                Summary = "Set in a medieval Europe-inspired dark fantasy world, the story centers on the characters of Guts, a lone mercenary, and Griffith, the leader of a mercenary band called the `Band of the Hawk`",
                Price = 28,
                Image = "~/Content/public/themes/images/manga_images/berserk.jpg",
                NoOfPages = 125,
                VolumeNumber = 4,
                Publisher = Publisher3,
                PublisherId = Publisher3.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Dark fantasy"},
                    new Genre { Name = "Epic"},
                    new Genre { Name = "Sword and sorcery"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Dr.Stone",
                Author = "Riichiro Inagaki",
                Summary = "It's been over 3,700 years since a mysterious flash of large eggs petrified nearly all the human life. An 18-year-old genius named Senkū Ishigami is suddenly revived to find himself in a world where all traces of human civilization have been eroded by time",
                Price = 20,
                Image = "~/Content/public/themes/images/manga_images/Dr.Stone.jpg",
                NoOfPages = 100,
                VolumeNumber = 1,
                Publisher = Publisher1,
                PublisherId = Publisher1.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Post-apocalyptic"},
                    new Genre { Name = "Science fiction"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Fullmetal Alchemist",
                Author = "Hiromu Arakawa",
                Summary = "The series follows the adventures of two alchemist brothers named Edward and Alphonse Elric, who are searching for the philosopher's stone to restore their bodies after a failed attempt to bring their mother back to life using alchemy",
                Price = 21,
                Image = "~/Content/public/themes/images/manga_images/Fullmetal Alchemist.jpg",
                NoOfPages = 107,
                VolumeNumber = 1,
                Publisher = Publisher2,
                PublisherId = Publisher2.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Dark fantasy"},
                    new Genre { Name = "Steampunk"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Grand blue",
                Author = "Kenji Inoue",
                Summary = "Iori Kitahara looks forward to his new life on the Izu Peninsula as he prepares to start his college life there, staying in a room above his uncle's diving shop `Grand Blue`. However, he is quickly shocked as he meets the local Diving Club, a group full of buff men who spend more time drinking, partying, and stripping naked than actually diving",
                Price = 18,
                Image = "~/Content/public/themes/images/manga_images/Grand blue.jpg",
                NoOfPages = 89,
                VolumeNumber = 2,
                Publisher = Publisher3,
                PublisherId = Publisher3.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Comedy"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Great Teacher Onizuka",
                Author = "Tooru Fujisawa",
                Summary = "The story focuses on 22-year-old ex-bōsōzoku member Eikichi Onizuka, who becomes a teacher at a private middle school",
                Price = 19,
                Image = "~/Content/public/themes/images/manga_images/GTO.jpg",
                NoOfPages = 94,
                VolumeNumber = 1,
                Publisher = Publisher4,
                PublisherId = Publisher4.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Action"},
                    new Genre { Name = "Comedy"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Hunter x hunter",
                Author = "Yoshihiro Togashi",
                Summary = "The story focuses on a young boy named Gon Freecss who discovers that his father, who left him at a young age, is actually a world renowned Hunter, a licensed professional who specializes in fantastical pursuits such as locating rare or unidentified animal species, treasure hunting, surveying unexplored enclaves, or hunting down lawless individuals",
                Price = 40,
                Image = "~/Content/public/themes/images/manga_images/HunterxHunter.jpg",
                NoOfPages = 140,
                VolumeNumber = 10,
                Publisher = Publisher4,
                PublisherId = Publisher4.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Fantasy"},
                    new Genre { Name = "Martial arts"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Jojo's bizarre adventure",
                Author = "Hirohiko Araki",
                Summary = "JoJo's Bizarre Adventure is well-known for its iconic art style and poses, frequent references to Western popular music and fashion, and creative battles centered around Stands, psycho-spiritual manifestations with unique supernatural abilities",
                Price = 28,
                Image = "~/Content/public/themes/images/manga_images/Jojo's bizzare adventure.jpg",
                NoOfPages = 105,
                VolumeNumber = 4,
                Publisher = Publisher4,
                PublisherId = Publisher4.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Fantasy"},
                    new Genre { Name = "Supernatural"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Kingdom",
                Author = "Yasuhisa Hara",
                Summary = "The manga provides a fictionalized account of the Warring States period primarily through the experiences of the war orphan Xin and his comrades as he fights to become the greatest general under the heavens, and in doing so, unifying China for the first time in 500 years",
                Price = 29,
                Image = "~/Content/public/themes/images/manga_images/Kingdom.jpg",
                NoOfPages = 101,
                VolumeNumber = 12,
                Publisher = Publisher1,
                PublisherId = Publisher1.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Epic"},
                    new Genre { Name = "Historical"},
                    new Genre { Name = "Military"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Monster",
                Author = "Naoki Urasawa",
                Summary = "The story revolves around Kenzo Tenma, a Japanese surgeon living in Germany whose life enters turmoil after getting himself involved with Johan Liebert, one of his former patients, who is revealed to be a dangerous serial killer",
                Price = 35,
                Image = "~/Content/public/themes/images/manga_images/Monster.jpg",
                NoOfPages = 160,
                VolumeNumber = 1,
                Publisher = Publisher2,
                PublisherId = Publisher2.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Crime"},
                    new Genre { Name = "Mystery"},
                    new Genre { Name = "Thriller"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "One piece",
                Author = "Eiichiro Oda",
                Summary = "The story follows the adventures of Monkey D. Luffy, a boy whose body gained the properties of rubber after unintentionally eating a Devil Fruit. With his crew of pirates, named the Straw Hat Pirates, Luffy explores the Grand Line in search of the world's ultimate treasure known as `One Piece` in order to become the next King of the Pirates",
                Price = 23,
                Image = "~/Content/public/themes/images/manga_images/OnePiece.jpg",
                NoOfPages = 110,
                VolumeNumber = 16,
                Publisher = Publisher3,
                PublisherId = Publisher3.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Fantasy"}                   
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Oyasumi Punpun",
                Author = "Inio Asano",
                Summary = "A coming-of-age drama story, it follows the life of a child named Onodera Punpun, from his elementary school years to his early 20s, as he copes with his dysfunctional family, love life, friends, life goals and hyperactive mind, while occasionally focusing on the lives and struggles of his schoolmates and family. Punpun and the members of his family are normal humans, but are depicted to the reader in the forms of birds. The manga explores themes such as depression, love, social isolation, sex, death, and family",
                Price = 29,
                Image = "~/Content/public/themes/images/manga_images/Oyasumi Punpun.jpg",
                NoOfPages = 100,
                VolumeNumber = 1,
                Publisher = Publisher4,
                PublisherId = Publisher4.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Coming-of-age"},
                    new Genre { Name = "Drama"},
                    new Genre { Name = "Slice of life"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "The Promised Neverland",
                Author = "Kaiu Shirai",
                Summary = "The story follows a group of orphaned children in their escape plan from an orphanage after they realize a dark secret",
                Price = 28,
                Image = "~/Content/public/themes/images/manga_images/ThePromisedNeverland.jpg",
                NoOfPages = 116,
                VolumeNumber = 7,
                Publisher = Publisher1,
                PublisherId = Publisher1.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Dark fantasy"},
                    new Genre { Name = "Science fiction"},
                    new Genre { Name = "Thriller"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Vagabond",
                Author = "Takehiko Inoue",
                Summary = "It portrays a fictionalized account of the life of Japanese swordsman Musashi Miyamoto, based on Eiji Yoshikawa's novel Musashi",
                Price = 39,
                Image = "~/Content/public/themes/images/manga_images/Vagabond.jpg",
                NoOfPages = 115,
                VolumeNumber = 3,
                Publisher = Publisher2,
                PublisherId = Publisher2.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Epic"},
                    new Genre { Name = "Historical"},
                    new Genre { Name = "Martial arts"}
                }
            });

            ctx.Mangas.Add(new Manga
            {
                Title = "Vinland Saga",
                Author = "Makoto Yukimura",
                Summary = "The title, Vinland Saga, would evoke associations to Vinland as described in two Norse sagas. Vinland Saga is, however, set in Dane-controlled England at the start of the 11th century, and features the Danish invaders of England commonly known as Vikings. The story combines a dramatization of King Cnut the Great's historical rise to power with a revenge plot centered on the historical explorer Thorfinn, the son of a murdered ex-warrior",
                Price = 30,
                Image = "~/Content/public/themes/images/manga_images/VinlandSaga.jpg",
                NoOfPages = 100,
                VolumeNumber = 1,
                Publisher = Publisher3,
                PublisherId = Publisher3.PublisherId,
                Genres = new List<Genre> {
                    new Genre { Name = "Adventure"},
                    new Genre { Name = "Epic"},
                    new Genre { Name = "Historical"}
                }
            });

            ctx.SaveChanges();
            base.Seed(ctx);
        }
    }
}