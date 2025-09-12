using game.services;

Creature knight = new Player(30, 5, 5, 1, 6);
Creature monster = new Monster(30, 5, 5, 1, 6);


Console.WriteLine(monster.Health);
for (int i = 0; i < 4; i++)
{
    try
    {
        knight.DealDamage(knight);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}