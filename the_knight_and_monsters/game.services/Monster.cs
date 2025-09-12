namespace game.services;

public class Monster : Creature
{
    public Monster(
        string name,
        int health,
        int attack,
        int armor) : base(name, health, attack, armor)
    {
    }
}