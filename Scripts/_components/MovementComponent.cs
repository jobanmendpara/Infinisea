using Godot;

public partial class MovementComponent : Node
{
  [Export] public int Speed { get; private set; } = 200;
  [Export] public float RotationSpeed { get; private set; } = 1.5f;

  private float rotationDirection;
  public CharacterBody2D characterBody2D;

  public override void _Ready()
  {
    characterBody2D = GetParent<CharacterBody2D>();
  }

  public override void _PhysicsProcess(double delta)
  {
    characterBody2D.Rotation += rotationDirection * RotationSpeed * (float)delta;
    characterBody2D.MoveAndSlide();
  }

  public void Move(float hAxis, float vAxis)
  {
    rotationDirection = hAxis;
    characterBody2D.Velocity = characterBody2D.Transform.X * vAxis * Speed;
  }
}
