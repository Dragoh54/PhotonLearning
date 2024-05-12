using UnityEngine;
using TMPro;

namespace Coin
{
    public class CoinCounter : MonoBehaviour
    {
        public GameObject text;
        public static int Counter;
        
        void Start()
        {
            Counter = 0;
        }

        void FixedUpdate()
        {
            text.GetComponent<TMP_Text>().text = Counter.ToString();
        }
    }
}
