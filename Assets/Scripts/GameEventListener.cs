using UnityEngine;

/* Manage the state of the game */
public class GameEventListener : MonoBehaviour
{
    public static GameEventListener Instance { get; private set; }

    [SerializeField] private MainMenu _menu;
    [SerializeField] private ObstacleSpawner _obstacleManager;
    [SerializeField] private ItemsSpawner _itemsManager;
    [SerializeField] private Player _player;

    private ISaver _save;
    private float _startTime;

    private void Awake()
    {
        Instance = this;
    }

    public void Configure(ILoader loadPersistance, ISaver save)
    {
        _save = save;
        _menu.Configure(loadPersistance);
    }

    public void OnPlayerDeath()
    {
        _obstacleManager.DestroyProjectiles();
        _itemsManager.DestroyItems();
        var duration = Time.time - _startTime;
        // Save the last duration
        _save.SaveLastDuration(duration);
        _menu.ShowGameOver();
    }

    public void OnStartGame()
    {
        // Start timer
        _startTime = Time.time;
        // Start the logic of the managers and reset the player
        _obstacleManager.StartSpawning();
        _itemsManager.StartSpawning();
        _player.Reset();
    }
}
