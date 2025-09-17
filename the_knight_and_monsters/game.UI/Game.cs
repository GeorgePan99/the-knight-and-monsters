using game.services.Abstractions;
using game.services.Entities;

namespace game.UI;

public class Game
{
    public void GamePlay()
    {
        Creature knight = CreateCharacter();
        
        Creature gremlin = new Monster("Gremlin", 15, 15, 10);
        Console.WriteLine("Перед вами появился гремлин! " +
                          $"Он имеет {gremlin.Health} жизней, " +
                          $"{gremlin.Attack} атаки и {gremlin.Armor} брони." + 
                          " Сразите его!");
        Fight(ref knight, ref gremlin);
    }

    private Creature CreateCharacter()
    {
        Console.WriteLine("Добро пожаловать в игру 'рыцарь против монстров'!");

        while (true)
        {
            try
            {
                Console.Write("Введите имя персонажа: ");
                string name = Console.ReadLine();

                Console.Write("Введите здороьве: ");
                int health = int.Parse(Console.ReadLine());

                Console.Write("Введите количество атаки: ");
                int attack = int.Parse(Console.ReadLine());

                Console.Write("Введите защиту: ");
                int armor = int.Parse(Console.ReadLine());

                Creature knight = new Player(name, health, attack, armor);

                Console.WriteLine("Персонаж успешно создан!");

                return knight;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
        }
    }

    private void Fight(ref Creature player, ref Creature monster)
    { 
        Console.WriteLine("Чтобы ударить врага, введите '1'\n" +
                        "Чтобы исцелить себя, введите '2'");
        while (player.Health > 0 && monster.Health > 0)
        {
            string command =  Console.ReadLine();
            if (command == "1")
            {
                Console.WriteLine(player.DealDamage(monster));
                Console.WriteLine(monster.DealDamage(player));
            }
            else if (command == "2")
            {
                Console.WriteLine(((IHealable)player).Heal());
                Console.WriteLine(monster.DealDamage(player));
            }
            else
            {
                Console.WriteLine("Некорректная команда!");
            }
        }
    }
}















