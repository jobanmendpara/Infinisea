using Godot;

public partial class GameManager : Node
{
  [Export] private PackedScene playerScene = ResourceLoader.Load<PackedScene>("res://Scenes/Player.tscn");
  [Export] private PackedScene cameraScene = ResourceLoader.Load<PackedScene>("res://Scenes/_components/CameraComponent.tscn");

  public bool isGamePaused;

  private InputManager inputManager;
  private Node camera;
  private Node player;

  public override void _Ready()
  {
    setup();
  }

  public override void _Process(double delta)
  {
    // TODO: Remove temp testing label
    GetNode<Label>("/root/World/UI/temp_Label").Text = string.Concat("Game Paused: ", isGamePaused);
  }

  private void setup()
  {
    isGamePaused = true;
    inputManager = GetNode<InputManager>("/root/World/Managers/InputManager");
    camera = cameraScene.Instantiate();
    player = playerScene.Instantiate();

    GetNode("/root/World/Actors").AddChild(player);
    player.AddChild(camera);

    inputManager.GameStateChange += OnGameStateChange;
    inputManager.InputDirection += ((Player)player).OnInputDirection;
    isGamePaused = false;
  }

  private void OnGameStateChange()
  {
    isGamePaused = !isGamePaused;
    GetTree().Paused = isGamePaused;
  }
}
