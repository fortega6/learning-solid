using System;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private MainMenu _menu;
    [SerializeField] private GameEventListener _gameManager;

    private void Awake()
    {
        _menu.Configure(GetLoadPersistence());
        _gameManager.Configure(GetLoadPersistence(), GetSavePersistence());
    }

    private ILoader GetLoadPersistence()
    {
#if UNITY_EDITOR
        return new FilePersistence();
#endif
        return new PlayerPrefsPersistence();
    }

    private ISaver GetSavePersistence()
    {
#if UNITY_EDITOR
        return new FilePersistence();
#endif
        return new PlayerPrefsPersistence();
    }
}