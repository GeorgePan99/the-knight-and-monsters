namespace game.services.Abstractions
{
    public abstract class Creature
    {
        private int _attack;
        private int _armor;
        private int _health;
        private readonly Range _damage = 1..7;
        private bool _isSuccessPunch;
        public string Name { get; }
        public int Health
        {
            get => _health;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Здоровье не может быть меньше нуля!");
                _health = value;
            }
        }
        public int Attack
        {
            get => _attack;
            protected set
            {
                if (value is < 1 or > 30 )
                    throw new ArgumentException("Атака должна быть в диапазоне " +
                                                "от 1 до 30 единиц"); 
                _attack = value;
            }
        }
        public int Armor
        {
            get => _armor;
            protected set
            {
                if (value is < 1 or > 31)
                    throw new ArgumentException("Защита должна быть в диапазоне " +
                                                "от 1 до 30 единиц");
                _armor = value;
            }
        }

        public Creature(string name, int health, int attack, int armor)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Armor = armor;
        }
        public string DealDamage(Creature enemy)
        {
            int attackModifier;
            Random dice = new Random();
            
            if (Attack > enemy.Armor + 1)
                attackModifier = Attack - enemy.Armor + 1;
            else
                attackModifier = 1;
            
            for (int i = 0; i < attackModifier; i++)
            {
                if (dice.Next(1, 7) > 4)
                {
                    _isSuccessPunch = true;
                    break;
                }
            }

            if (_isSuccessPunch)
            {
                int currentDamage = dice.Next(_damage.Start.Value, _damage.End.Value);
                enemy.Health -= currentDamage;
                _isSuccessPunch = false;
                return $"Игрок {Name} нанес {enemy.Name} {currentDamage} урона!";
            }
            return $"Игрок {Name} промазал!";
        }
    }
}