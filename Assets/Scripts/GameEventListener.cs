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
        CleanPendingElements();
        SaveLastDuration();
        ShowGameOver();
    }

    private void CleanPendingElements()
    {
        _obstacleSpawner.DestroyProjectiles();
        _itemsSpawner.DestroyItems();
    }

    private void SaveLastDuration()
    {
        var gameDuration = Time.time - _gameStartTime;
        _saver.SaveData(gameDuration);
    }

    private void ShowGameOver()
    {
        _mainMenu.ShowGameOver();
    }

    public void OnStartGame()
    {
        StartTimer();
        Initialize();
    }

    private void StartTimer()
    {
        _gameStartTime = Time.time;
    }

    private void Initialize()
    {
        _obstacleSpawner.StartSpawning();
        _itemsSpawner.StartSpawning();
        _player.Reset();
    }
}
