using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

namespace MainMenu
{
    public class MainMenuManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerName;
        public GameObject createRoom;
        public GameObject joinRoom;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };
            PhotonNetwork.CreateRoom(createRoom.GetComponent<TMP_InputField>().text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinRoom.GetComponent<TMP_InputField>().text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("Game");
        }
    }
}
