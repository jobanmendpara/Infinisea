using Godot;

public partial class Player : CharacterBody2D
{
  private HealthComponent health;
  private MovementComponent movement;

  public override void _Ready()
  {
    health = GetNode<HealthComponent>("./HealthComponent");
    movement = GetNode<MovementComponent>("./MovementComponent");
  }

  public void OnInputDirection(float x, float y)
  {
    movement.Move(x, y);
  }
}
