using game.services;


Creature knight = new Player("Goga", 40, 20, 20);
Creature gremlin = new Monster("Tar", 35, 15, 10);

Console.WriteLine(knight.DealDamage(gremlin));