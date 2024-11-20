using System;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    void Start()
    {
        UpdataCoin();
    }

    private void UpdataCoin()
    {
        Coins.text=ButtonManager.Instance.GetCoins().ToString();
    }
}
