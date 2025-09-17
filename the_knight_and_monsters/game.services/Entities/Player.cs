using game.services.Abstractions;


namespace game.services.Entities;

public class Player : Creature, IHealable
{
    private readonly int _maxHealth;
    private int _flaskAmount = 4;
    private readonly float _healingPercentage = 0.3f;
    private Weapon _weapon;
    public Weapon CurrentWeapon => _weapon;
    public Player(
        string name,
        int health,
        int attack,
        int armor) : base(name, health, attack, armor)
    {
        _maxHealth = health;
    }
    
    public string Heal()
    {
        if (_flaskAmount == 0)
            return $"{Name}, сцелить себя не получится." +
                   "Все зелья потрачены!";
        
        if (Health ==  _maxHealth)
            return $"{Name}, использовать зелье нет необходимости, "+
                   "здоровье на максимуме!";
        

        _flaskAmount -= 1;
        int healingBonus = (int)(_maxHealth * _healingPercentage);
        if (healingBonus + Health >= _maxHealth)
        {
            Health = _maxHealth;
            return $"Игрок {Name} вылечил своё здоровье на максимум!";
        }
        Health += healingBonus;
        return $"Игрок {Name} исцелил себя на {healingBonus}";
    }
    public string EquipWeapon(Weapon weapon)
    {
        if (_weapon != null)
            return $"{Name} уже имеет в своем арсенале {_weapon.Name}!";
        
        if (_weapon == weapon)
            return $"{Name} уже экипировал себе {_weapon.Name}!";
        _weapon = weapon;
        return $"{Name} взял себе {_weapon.Name}!";
    }
    public string UnequipWeapon(Weapon weapon)
    {
        return "Тут должен быть метод снятия оружия";
    }

    public string DealDamageWithWeapon(Creature enemy)
    {
        return "";
    }
}