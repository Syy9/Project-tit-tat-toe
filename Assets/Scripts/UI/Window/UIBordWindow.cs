using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Window;
using UnityEngine;

public class UIBordWindow : UIWindow {
    IBordEventHandle Hnadler;
    [SerializeField] TextMeshProUGUI TurnPlayerName;

    public void Init(Bord[] bords, IBordEventHandle handler)
    {
        Hnadler = handler;
        var uiBords = GetComponentsInChildren<UIBord>();
        if(uiBords.Length != bords.Length)
        {
            throw new Exception("Not match Bord and uiBord Length");
        }

        int index = 0;
        foreach (var bord in bords)
        {
            var uiBord = uiBords[index];
            uiBord.Bind(bord);
            uiBord.OnSelectBord += Hnadler.OnSelectBord;
            index++;
        }
    }

    public void UpdateTurnPlayerName(PlayerType turnPlayer)
    {
        TurnPlayerName.text = turnPlayer.ToString();
    }
}
