using Photon.Pun;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Coin
{
    public class SpawnCoins : MonoBehaviourPunCallbacks
    {
        public GameObject coinPrefab;

        public int numberOfCoins;

        public float minX, minY, maxX, maxY;

        bool _isSpawned;
        void Start()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }
            
            for (int i = 0; i < numberOfCoins; i++)
            {
                SpawnCoin();
            }

            _isSpawned = true;
        }

        private void Update()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }

            if (_isSpawned)
            {
                _isSpawned = false;
                StartCoroutine(WaitCoin(5f));
            }
        }

        public void SpawnCoin()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
            PhotonNetwork.Instantiate(coinPrefab.name, spawnPosition, Quaternion.identity);
        }

        IEnumerator WaitCoin(float time)
        {
            yield return new WaitForSeconds(time);
            SpawnCoin();
            _isSpawned = true;
        }
    }
}
