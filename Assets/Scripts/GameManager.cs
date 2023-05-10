﻿using UnityEngine;

/* Manage the state of the game */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Menu _menu;
    [SerializeField] private ObstacleManager _obstacleManager;
    [SerializeField] private ItemsManager _itemsManager;
    [SerializeField] private Player _player;

    private ISave _save;
    private float _startTime;

    private void Awake()
    {
        Instance = this;
    }

    public void Configure(ISave save)
    {
        _save = save;
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
