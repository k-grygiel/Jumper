using Levels;

public interface ILevel
{
    public LevelManager LevelManager { get; set; }

    public void OnEnter();

    public void OnExit();

    public void Enter();
}
