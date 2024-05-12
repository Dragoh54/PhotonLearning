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

        readonly string? _nickname = PhotonNetwork.NickName;

        private void Start()
        {
            _text.text = _nickname;
        }

        public string? Nickname { get { return _nickname; } }
    }
}
