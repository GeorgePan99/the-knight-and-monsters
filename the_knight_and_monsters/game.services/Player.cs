namespace game.services;

public class Player(
    int health,
    int attack,
    int armor,
    int lowerDamage,
    int upperDamage
    ): Creature
{
    public override int Health { get; set; } = health;
    public override int Attack { get; set; }  = attack;
    public override int Armor { get; set; }  = armor;
    public override Range Damage { get; set; } = lowerDamage..(upperDamage + 1);
    private readonly int _regenerationPercentage = (int)(0.3f * health);
    private readonly int _maxHealth = health;
    public int FlaskAmount { get; private set; } = 4;


    public void Heal()
    {
        if (FlaskAmount == 0)
        {
            return;
        }
        if (_regenerationPercentage + Health > Health)
        {
            Health = _maxHealth;
        }
        else
        {
            Health = Health + _regenerationPercentage;
        }
    }
}