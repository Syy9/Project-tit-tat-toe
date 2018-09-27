using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Window;
using UnityEngine;
using UnityEngine.UI;

public class UIResultWindow : UIWindow
{
    public Action OnCloseEvent;

    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] Button closeButton;

    void Awake()
    {
        closeButton.onClick.AddListener(() => {
            OnCloseEvent.Call();
        });
    }

    public void Init(PlayerType winner)
    {
        winnerText.text = winner.ToString();
    }
}
