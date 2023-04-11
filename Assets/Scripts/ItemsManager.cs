﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private string[] _itemIds;

    [SerializeField] private Item[] _prefabItems;
    private Dictionary<string, Item> _idToItemPrefabs;
    
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;
    
    private List<GameObject> _items = new List<GameObject>();
    private bool _canSpawn;
    private float _timeToNextSpawn;

    private void Awake()
    {
        _idToItemPrefabs = new Dictionary<string, Item>();
        foreach (var prefabItem in _prefabItems)
        {
            _idToItemPrefabs.Add(prefabItem.Id, prefabItem);
        }
    }

    private void Start()
    {
        CalculateTimeToNextSpawn();
    }
    
    private void Update()
    {
        if (_canSpawn)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (_timeToNextSpawn < 0)
            {
                CalculateTimeToNextSpawn();
                // Get random item to spawn
                SpawnItem(_itemIds[Random.Range(0, _itemIds.Length)]);
            }
        }
    }
    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItem(string id)
    {
        // Spawn the items in random position
        if (!_idToItemPrefabs.TryGetValue(id, out var itemToInstantiate))
        {
            throw new ArgumentOutOfRangeException();
        }
        
        _items.Add(Instantiate(itemToInstantiate,
            _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
            Quaternion.identity).gameObject);
    }
    
    public void DestroyItems()
    {
        foreach (var projectile in _items)
        {
            Destroy(projectile);
        }

        _canSpawn = false;
    }
    
    public void StartSpawning()
    {
        _canSpawn = true;
    }
}
