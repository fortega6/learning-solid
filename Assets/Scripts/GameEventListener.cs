using UnityEngine;

/* Manage the state of the game */
public class GameEventListener : MonoBehaviour
{
    public static GameEventListener Instance { get; private set; }

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private ItemsSpawner _itemsSpawner;
    [SerializeField] private Player _player;

    private float _gameStartTime;
    private ISaver _saver;

    private void Awake()
    {
        Instance = this;
    }

    public void Configure(ILoader loaderPersistance, ISaver saverPersistance)
    {
        _saver = saverPersistance;
        _mainMenu.Congigure(loaderPersistance);
    }

    public void OnPlayerDeath()
    {
        _obstacleSpawner.DestroyProjectiles();
        _itemsSpawner.DestroyItems();
        var gameDuration = Time.time - _gameStartTime;
        // Save the last duration
        _saver.SaveData(gameDuration);
        _mainMenu.ShowGameOver();
    }

    public void OnStartGame()
    {
        // Start timer
        _gameStartTime = Time.time;
        // Start the logic of the managers and reset the player
        _obstacleSpawner.StartSpawning();
        _itemsSpawner.StartSpawning();
        _player.Reset();
    }
}
