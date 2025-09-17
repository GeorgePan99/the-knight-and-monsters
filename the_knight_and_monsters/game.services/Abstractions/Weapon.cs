namespace game.services.Abstractions;

public abstract class Weapon
{
    private int _damage;
    public string Name { get; }

    public int Durable { get; private set; } = 10;

    public int Damage { get => _damage;
        private set
        {
            if (value is < 1 or > 10 )
                throw new ArgumentException("Урон оружия должен быть в диапазоне " +
                                            "от 1 до 10 единиц"); 
            _damage = value;
        }
    }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage; 
    }
}