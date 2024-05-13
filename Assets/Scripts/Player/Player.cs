using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

namespace Player
{
    public class Player : MonoBehaviourPun
    {
        [SerializeField] TextMeshProUGUI _text;

        string _nickname;

        private void Start()
        {
            photonView.RPC("SetNick", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        }

        public string Nickname { get { return _nickname; } }

        [PunRPC]
        void SetNick(string nickname)
        {
            _nickname = nickname;
            _text.text = Nickname;
        }
    }
}
