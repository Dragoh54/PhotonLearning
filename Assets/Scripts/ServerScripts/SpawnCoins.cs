using System;
using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ServerScripts
{
    public class SpawnCoins : MonoBehaviourPunCallbacks
    {
        public GameObject coinPrefab;
        private GameObject _currentCoin;
        
        public float minX, minY, maxX, maxY;

        void Start()
        {
            SpawnCoin();
        }

        private void Update()
        {
            SpawnCoin();
        }

        public void SpawnCoin()
        {
            if (_currentCoin == null)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                _currentCoin = PhotonNetwork.Instantiate(coinPrefab.name, spawnPosition, Quaternion.identity);
            }
        }
    }
}
