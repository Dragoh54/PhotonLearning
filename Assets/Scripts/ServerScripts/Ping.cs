using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ping : MonoBehaviour
{
    private int _nPing;

    private void FixedUpdate()
    {
        NPing();
    }
        
    public void NPing()
    {
        _nPing = PhotonNetwork.GetPing();
        Debug.Log(_nPing);
    }
}