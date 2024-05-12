
using System;
using Photon.Pun;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace ServerScripts
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        private const int MIN_PLAYERS = 2;
        
        public GameObject player;
        private GameObject _spawnedPlayer;
        public float minX, minY, maxX, maxY;
        
        private PhotonView _view;
        private Endgame _endgame;

        public void Start()
        {
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            _spawnedPlayer = PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);
            SetPlayerActive(false);
        }

        private void Update()
        {
            if (PhotonNetwork.InRoom)
            {
                int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

                if (playerCount >= MIN_PLAYERS)
                {
                    StartGame();
                }
            }
        }
        
        void StartGame()
        {
            SetPlayerActive(true);
        }
        
        public void Leave()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        private void SetPlayerActive(bool active)
        {
            _spawnedPlayer.GetComponent<PlayerController>().enabled = active;
            _spawnedPlayer.GetComponentInChildren<Projectile.ProjectileLauncher>().enabled = active;
        }
    }
}
