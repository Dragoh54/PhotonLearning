using UnityEngine;
using TMPro;

namespace Coin
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;
        CoinCollector _counter;
        
        void Start()
        {
            _counter = FindAnyObjectByType<CoinCollector>();
        }

        void FixedUpdate()
        {
            _text.text = _counter.GetCoins().ToString();
        }
    }
}
