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
            /*if (photonView.IsMine)
            {
                photonView.RPC("SetNick", RpcTarget.All, PhotonNetwork.NickName);
            }*/
            photonView.RPC("RPC_SetNick", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        }

        public string Nickname { get { return _nickname; } }

        [PunRPC]
        private void RPC_SetNick(string nickname, PhotonMessageInfo info)
        {
            // Устанавливаем никнейм для всех объектов
            if (photonView.Owner == info.Sender)
            {
                _nickname = nickname;
                _text.text = nickname;
            }
        }

        /*[PunRPC]
        void SetNick(string nickname)
        {
            _nickname = nickname;
            _text.text = nickname;
        }*/
    }
}
