using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameEventListener _gameEventListener;

        private void Awake()
        {
            #if UNITY_EDITOR
            ILoader loaderPersisntace = new FilePersistance();
            ISaver saverPersistance = new FilePersistance();
            #endif
            
            #if UNITY_ANDROID
            ILoad loadPesistance = new PlayerPrefsPersistence();
            ISave savePersistance = new PlayerPrefsPersistence();
            #endif
            
            _gameEventListener.Configure(loaderPersisntace, saverPersistance);
        }
    }
}
