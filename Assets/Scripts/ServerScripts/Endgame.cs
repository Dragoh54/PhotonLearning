using System;
using Coin;
using HealthSystems;
using Photon.Pun;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace ServerScripts
{
    public class Endgame
    {
        public GameObject endgameCanvas;
        
        [SerializeField]
        public GameObject lastPlayerName;
        public GameObject LastPlayerScore;

        public void GameOver()
        { 
            endgameCanvas.SetActive(true);
            Time.timeScale = 0f;
            foreach (var player in PhotonNetwork.PlayerList)
            {
                GameObject playerObject =  GameObject.FindWithTag("Player");
                Health hp = playerObject.GetComponent<Health>();
                if (hp != null && hp.isAlive)
                {
                    lastPlayerName.GetComponent<TMP_Text>().text = player.NickName;
                    int coins = playerObject.GetComponent<CoinCollector>().GetCoins();
                    LastPlayerScore.GetComponent<TMP_Text>().text = coins.ToString();
                }
            }
        }
    }
}