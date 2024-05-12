
using System;
using Photon.Pun;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace ServerScripts
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        private const int MIN_PLAYERS = 2;
        
        public GameObject player;
        private GameObject _spawnedPlayer;
        public float minX, minY, maxX, maxY;

        bool _isStarted = false;
        bool _isLocalAlive = true;
        int _playerCount;
        
        [SerializeField] EndgameManager _endgame;

        public void Start()
        {
            _endgame.SetWinStatus(false);
            _endgame.SetActiveEndgame(false);
            Vector2 spawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            _spawnedPlayer = PhotonNetwork.Instantiate(player.name, spawnPosition, Quaternion.identity);
            SetPlayerActive(false);
        }

        private void Update()
        {
            if (PhotonNetwork.InRoom && !_isStarted)
            {
                _playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

                if (_playerCount >= MIN_PLAYERS)
                {
                    StartCoroutine(WaitForStart(2f));   
                }
            }

            _playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
            Debug.Log(_isLocalAlive);

            if (_isStarted && _playerCount == 1 && _isLocalAlive)
            {
                var lastPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystems.Health>();
                /*Debug.Log($"lastPlayer: {lastPlayer.IsAlive}");
                lastPlayer.photonView.RPC("ShowWinScreen", RpcTarget.All);*/
                if (lastPlayer.IsAlive && lastPlayer.photonView.IsMine)
                {
                    ShowWinScreen();
                }
            }
        }

        [PunRPC]
        void ShowWinScreen()
        {
            _endgame.SetWinStatus(true);
            _endgame.SetActiveEndgame(true);
        }

        void StartGame()
        {
            SetPlayerActive(true);
            _isStarted = true;
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

        public bool IsLocalAlive { get { return _isLocalAlive; } set { _isLocalAlive = value; } }

        IEnumerator WaitForStart(float time)
        {
            yield return new WaitForSeconds(time);
            StartGame();
        }
    }
}
