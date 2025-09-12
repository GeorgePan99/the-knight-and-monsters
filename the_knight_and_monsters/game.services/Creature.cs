namespace game.services
{
    public abstract class Creature
    {
        public abstract int Health { get; set; }
        public abstract int Attack { get; set; }
        public abstract int Armor { get; set; }
        public abstract Range Damage { get; set; }

        public void DealDamage(Creature enemy)
        {
            if (ReferenceEquals(this, enemy))
            {
                throw new InvalidOperationException("Самого себя атаковать нельзя!");
            }

            Random dice = new Random();
            int attakModificator = Attack - enemy.Armor + 1;
            for (int i = 0; i < attakModificator; i++)
            { 
                if (dice.Next(1, 7) >= 5) 
                {
                    enemy.Health -= dice.Next(Damage.Start.Value, Damage.End.Value);
                }
            }
        }
    }
}
