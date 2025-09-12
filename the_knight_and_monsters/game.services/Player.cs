namespace game.services;

public class Player : Creature, IHealable
{
    private readonly int _maxHealth;
    private int _flaskAmount = 4;
    private readonly float _healingPercentage = 0.3f;
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
            return "Исцелить себя не получится." +
                   "Все зелья потрачены!";
        
        if (Health ==  _maxHealth)
            return "Использовать зелье нет необходимости, "+
                   "здоровье на максимуме!";
        

        _flaskAmount -= 1;
        int healingBonus = (int)(_maxHealth * _healingPercentage);
        if (healingBonus + Health > _maxHealth)
        {
            Health = _maxHealth;
            return $"Игрок {Name} вылечил своё здоровье на максимум!";
        }
        Health += healingBonus;
        return $"Игрок {Name} исцелил себя на {healingBonus}";
    }
}