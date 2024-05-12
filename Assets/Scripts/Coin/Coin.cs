using Photon.Pun;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviourPun, IPunObservable
    {
        private bool _isCollected = false;

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !_isCollected)
            {
                _isCollected = true;
                Collect();
            }
        }

        public void Collect()
        {
            /*CoinCollector coinCollector = new CoinCollector();
            coinCollector.AddCoin();*/
            gameObject.SetActive(false);
            photonView.RPC("DestroyCoin", RpcTarget.AllViaServer);
        }

        [PunRPC]
        void DestroyCoin()
        {
            gameObject.SetActive(false);
            PhotonNetwork.Destroy(gameObject);
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_isCollected);
            }
            else
            {
                _isCollected = (bool)stream.ReceiveNext();
            }
        }
    }
}