using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class EndgameManager : MonoBehaviourPun
{
    [SerializeField] TextMeshProUGUI _StatusText;
    [SerializeField] TextMeshProUGUI _ScoreText;

    [SerializeField] GameObject _engameCanvas;

    private void Start()
    {
        SetWinStatus(false);
        SetScore(0);
        SetActiveEndgame(false);
    }

    public void SetActiveEndgame(bool status)
    {
        _engameCanvas.SetActive(status);
    }

    public void SetWinStatus(bool status)
    {
        _StatusText.text = status ? "You Win!" : "You Lose(";
    }

    public void SetWinStatus(bool status, string nickname)
    {
        _StatusText.text = status ? $"{nickname} Win!" : $"{nickname} Lose(";
    }

    public void SetScore(int score)
    {
        _ScoreText.text = $"Your score: {score}";
    }
}
