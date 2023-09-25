using Godot;

public partial class HealthComponent : Node
{
  [Export] public int MaxHealth { get; private set; } = 100;
  public int CurrentHealth { get; private set; }

  public override void _Ready()
  {
    CurrentHealth = MaxHealth;
  }

  public void Heal(int amount)
  {
    CurrentHealth += amount;
  }

  public void Damage(int amount)
  {
    CurrentHealth -= amount;
  }
}
