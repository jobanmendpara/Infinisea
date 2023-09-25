using Godot;

public partial class InputManager : Node
{
  private GameManager gameManager;

  [Signal] public delegate void InputDirectionEventHandler(float x, float y);
  [Signal] public delegate void GameStateChangeEventHandler();

  public override void _Ready()
  {
    gameManager = GetNode<GameManager>("../GameManager");
  }

  public override void _Process(double delta)
  {
    handleInputKeyPress();
    handleInputDirection();
  }

  private void handleInputKeyPress()
  {
    if (Input.IsActionJustPressed("pause"))
    {
      EmitSignal(SignalName.GameStateChange);
    }
  }

  private void handleInputDirection()
  {
    float x = Input.GetAxis("left", "right");
    float y = Input.GetAxis("down", "up");

    EmitSignal(SignalName.InputDirection, x, y);
  }
}
