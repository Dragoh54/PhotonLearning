using UnityEngine;
using TMPro;

namespace Coin
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;

        CoinCollector _counter;
        EndgameManager _endgame;

        void Start()
        {
            _endgame = FindAnyObjectByType<EndgameManager>();
            _counter = FindAnyObjectByType<CoinCollector>();
        }

        void Update()
        {
            var coins = _counter.GetCoins();
            _endgame.SetScore(coins);
            _text.text = $"Score: {coins}";
        }
    }
}
