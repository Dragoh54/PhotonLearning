using System;
using Photon.Pun;
using ServerScripts;
using UnityEngine;
using TMPro;

namespace Coin
{
    public class CoinCollector : MonoBehaviour
    {
        private int _coinCounter;
        private PhotonView _view;
        
        private GameObject _text;

        private void Start()
        {
            _coinCounter = 0;
            _view = GetComponentInParent<PhotonView>();
            _text = GameObject.FindWithTag("Counter");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Coin") && _view.IsMine)
            {
                var coin = collision.GetComponent<Coin>();
                //PhotonNetwork.Destroy(collision.gameObject);
                _coinCounter++;
                _text.GetComponent<TMP_Text>().text = _coinCounter.ToString();
                coin.Collect();
            }
        }

        public int GetCoins()
        {
            return _coinCounter;
        }

        public void AddCoin()
        {
            _coinCounter++;
        }
    }
}
