namespace game.services;

public class Monster(
    int health,
    int attack,
    int armor,
    int lowerDamage,
    int upperDamage) : Creature
{
    public override int Health { get; set; } = health;
    public override int Attack { get; set; } = attack;
    public override int Armor { get; set; } = armor;
    public override Range Damage { get; set; } = lowerDamage..upperDamage;
    private readonly int _regenerationPercentage = (int)(0.3f * health);
    private readonly int _maxHealth = health;
    
    
    
    
}
