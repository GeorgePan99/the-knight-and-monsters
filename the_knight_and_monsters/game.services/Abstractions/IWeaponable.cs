namespace game.services.Abstractions;

public interface IWeaponable
{
    public string EquipWeapon(Weapon weapon);
    public string UnequipWeapon();
}