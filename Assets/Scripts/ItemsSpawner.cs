﻿using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private AbstractItem[] Items;

    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _minSpawnInterval = 2;
    [SerializeField] private float _maxSpawnInterval = 4;

    private List<GameObject> _spawnedItems = new List<GameObject>();
    private Dictionary<ItemTypes, AbstractItem> _itemTypeToItem = new Dictionary<ItemTypes, AbstractItem>();
    private bool _isSpawnAvailable;
    private float _timeToNextSpawn;

    private void Start()
    {
        CalculateTimeToNextSpawn();
        foreach (var item in Items)
        {
            _itemTypeToItem.Add(item.Type, item);
        }
    }

    private void Update()
    {
        if (_isSpawnAvailable)
        {
            _timeToNextSpawn -= Time.deltaTime;
            if (IsTimeToSpawn())
            {
                CalculateTimeToNextSpawn();
                SpawnRandomItem();
            }
        }
    }
    private bool IsTimeToSpawn()
    {
        return _timeToNextSpawn < 0;
    }

    private void SpawnRandomItem()
    {
        var selectedType = (ItemTypes)Random.Range(0, Enum.GetNames(typeof(ItemTypes)).Length);

        if (!_itemTypeToItem.ContainsKey(selectedType))
        {
            throw new ArgumentNullException(nameof(selectedType), "Selected type not found");
        }

        _itemTypeToItem.TryGetValue(selectedType, out AbstractItem selectedItem);
        SpawnItemInRandomPosition(selectedItem);
    }


    private void CalculateTimeToNextSpawn()
    {
        _timeToNextSpawn = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnItemInRandomPosition(AbstractItem item)
    {
        _spawnedItems.Add(Instantiate(item,
            _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position,
            Quaternion.identity).gameObject);
    }

    public void DestroyItems()
    {
        foreach (var projectile in _spawnedItems)
        {
            Destroy(projectile);
        }

        _isSpawnAvailable = false;
    }

    public void StartSpawning()
    {
        _isSpawnAvailable = true;
    }
}
