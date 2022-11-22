using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShopProject.Migrations
{
    /// <inheritdoc />
    public partial class Zoo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Descripition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "mamals" },
                    { 2, "reptiles" },
                    { 3, "avian" },
                    { 4, "fish" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Descripition", "Name", "PicturePath" },
                values: new object[,]
                {
                    { 1, 5, 1, "Python is a genus of constricting snakes in the Pythonidae family native to the tropics and subtropics of the Eastern Hemisphere. The name Python was proposed by François Marie Daudin in 1803 for non-venomous flecked snakes. Currently, 10 python species are recognized as valid taxa.", "Python", "https://images.foxtv.com/static.fox10phoenix.com/www.fox10phoenix.com/content/uploads/2021/07/764/432/MyLove-the-snake-crop-3-Courtesy-of-Jay-Brewer.jpg?ve=1&tl=1" },
                    { 2, 12, 2, "Monitor lizards are lizards in the genus Varanus, the only extant genus in the family Varanidae. They are native to Africa, Asia, and Oceania, and one species is also found in the Americas as an invasive species. About 80 species are recognized.\r\n\r\nMonitor lizards have long necks, powerful tails and claws, and well-developed limbs. The adult length of extant species ranges from 20 cm (7.9 in) in some species, to over 3 m (10 ft) in the case of the Komodo dragon, though the extinct varanid known as megalania (Varanus priscus) may have been capable of reaching lengths more than 7 m (23 ft). Most monitor species are terrestrial, but arboreal and semiaquatic monitors are also known. While most monitor lizards are carnivorous, eating eggs, smaller reptiles, fish, birds, insects, and small mammals, some also eat fruit and vegetation, depending on where they live.", "Monitor Lizard", "https://a-z-animals.com/media/2018/09/Monitor-lizard-header.jpg" },
                    { 3, 2, 3, "The sugar glider (Petaurus breviceps) is a small, omnivorous, arboreal, and nocturnal gliding possum belonging to the marsupial infraclass. The common name refers to its predilection for sugary foods such as sap and nectar and its ability to glide through the air, much like a flying squirrel. They have very similar habits and appearance to the flying squirrel, despite not being closely related", "sugar glider", "https://www.wilderness.org.au/images/uploads/2ACH01R-1-Alamy-sugar-glider-CROP.jpg" },
                    { 4, 90, 4, "The gray whale (Eschrichtius robustus), also known as the grey whale, gray back whale, Pacific gray whale, Korean gray whale, or California gray whale, is a baleen whale that migrates between feeding and breeding grounds yearly. It reaches a length of 14.9 meters (49 ft), a weight of up to 41 tonnes (90,000 lb) and lives between 55 and 70 years, although one female was estimated to be 75–80 years of age. The common name of the whale comes from the gray patches and white mottling on its dark skin. Gray whales were once called devil fish because of their fighting behavior when hunted. The gray whale is the sole living species in the genus Eschrichtius.", "grey whale", "i dont know" },
                    { 5, 20, 1, "The okapi (/oʊˈkɑːpiː/; Okapia johnstoni), also known as the forest giraffe, Congolese giraffe, or zebra giraffe, is an artiodactyl mammal that is endemic to the northeast Democratic Republic of the Congo in central Africa. It is the only species in the genus Okapia. Although the okapi has striped markings reminiscent of zebras, it is most closely related to the giraffe. The okapi and the giraffe are the only living members of the family Giraffidae.\r\n\r\nThe okapi stands about 1.5 m (4 ft 11 in) tall at the shoulder and has a typical body length around 2.5 m (8 ft 2 in). Its weight ranges from 200 to 350 kg (440 to 770 lb). It has a long neck, and large, flexible ears. Its coat is a chocolate to reddish brown, much in contrast with the white horizontal stripes and rings on the legs, and white ankles. Male okapis have short, distinct horn-like protuberances on their heads called ossicones, less than 15 cm (5.9 in) in length. Females possess hair whorls, and ossicones are absent.", "Okapi", "i dont know" },
                    { 6, 42, 4, "The goblin shark (Mitsukurina owstoni) is a rare species of deep-sea shark. Sometimes called a \"living fossil\", it is the only extant representative of the family Mitsukurinidae, a lineage some 125 million years old. This pink-skinned animal has a distinctive profile with an elongated, flat snout, and highly protrusible jaws containing prominent nail-like teeth. It is usually between 3 and 4 m (10 and 13 ft) long when mature, though it can grow considerably larger such as one captured in 2000 that is thought to have measured 6 m (20 ft). Goblin sharks are benthopelagic creatures that inhabit upper continental slopes, submarine canyons, and seamounts throughout the world at depths greater than 100 m (330 ft), with adults found deeper than juveniles. Some researchers believe that these sharks could also dive to depths of up to 1,300 m (4,270 ft), for short periods of time.", "Goblin Shark", "i dont know" },
                    { 7, 42, 2, "The goblin shark (Mitsukurina owstoni) is a rare species of deep-sea shark. Sometimes called a \"living fossil\", it is the only extant representative of the family Mitsukurinidae, a lineage some 125 million years old. This pink-skinned animal has a distinctive profile with an elongated, flat snout, and highly protrusible jaws containing prominent nail-like teeth. It is usually between 3 and 4 m (10 and 13 ft) long when mature, though it can grow considerably larger such as one captured in 2000 that is thought to have measured 6 m (20 ft). Goblin sharks are benthopelagic creatures that inhabit upper continental slopes, submarine canyons, and seamounts throughout the world at depths greater than 100 m (330 ft), with adults found deeper than juveniles. Some researchers believe that these sharks could also dive to depths of up to 1,300 m (4,270 ft), for short periods of time.", "pacu fish", "i dont know" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentsId", "AnimalId", "Descripition" },
                values: new object[,]
                {
                    { 1, 1, "very scry animal" },
                    { 2, 2, "poisaning animal" },
                    { 3, 3, "cute animal" },
                    { 4, 4, "huge animal" },
                    { 5, 5, "cool animal" },
                    { 6, 6, "scary animal" },
                    { 7, 7, "dangerous animal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
