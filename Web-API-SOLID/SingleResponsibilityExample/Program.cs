
namespace SingleResponsibility
{
    // Single Responsibility Principle
    //
    // Bu prensip basit bir şekilde tüm methodların ve sınıfların tek bir görevi olduğunu söylüyor.
    // Yaptığım örnekte de oyuncu özelliklerini tutan sınıf ve bu oyuncunun seviye atlama ile ilgili methodlarını tutan sınıfı ayırdım.
    // LevelUp sınıfı içindeki bu sınıfın konusunda olup farklı görevleri olan kodlar da farklı methodlarda tutuluyor.
    // PlayMode ile alakalı olan GainExperience methodu da PlayModeManager adlı farklı bir sınıf içinde.
    class PlayMode
    {
        public static void Main(string[] args)
        {
            PlayerAttributes player = new PlayerAttributes("Burak");
            LevelUpManager manager = new LevelUpManager();
            PlayModeManager pManager = new PlayModeManager();
            for (int i = 0; i < 30; i++)
            {
                pManager.GainExperience(player);
                manager.CheckExperience(player);
                manager.CheckLevelUp(player);
            }
        }
    }

    public class PlayerAttributes
    {
        public PlayerAttributes(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public float Experience { get; set; } = 0;
    }

    public class LevelUpManager
    {
        float experience { get; set; }

        public void CheckExperience(PlayerAttributes playerAttributes)
        {
            experience = playerAttributes.Experience;
            Console.WriteLine(experience);
        }

        public void CheckLevelUp(PlayerAttributes playerAttributes)
        {
            if (experience > 10f)
            {
                playerAttributes.Level += 1;
                playerAttributes.Experience = 0;
                Console.WriteLine($"Level Up!! Current level is {playerAttributes.Level}");
            }
        }
        
    }

    public class PlayModeManager
    {
        public void GainExperience(PlayerAttributes player)
        {
            player.Experience += 1;
        }
    }







}