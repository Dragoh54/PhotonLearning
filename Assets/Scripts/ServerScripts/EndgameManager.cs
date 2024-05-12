using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameManager : MonoBehaviour
{
    public void SetActiveEndgame(bool status)
    {
        gameObject.SetActive(status);
    }
}
