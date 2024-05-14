using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;


namespace SpawnPlayers
{
    public class SpawnPlayers : MonoBehaviour
    {
        public GameObject player;
        public float minX, minY, maxX, maxY;

        public void Start()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, minY), Random.Range(maxX, maxY));
            PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);
        }
    }
}