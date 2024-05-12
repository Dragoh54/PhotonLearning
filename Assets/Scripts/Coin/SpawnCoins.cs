using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Coin
{
    public class SpawnCoins : MonoBehaviourPunCallbacks
    {
        public GameObject coinPrefab;

        public int numberOfCoins;

        public float minX, minY, maxX, maxY;
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
        }

        public void SpawnCoin()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)); 
            PhotonNetwork.Instantiate(coinPrefab.name, spawnPosition, Quaternion.identity);
        }
    }
}
