using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class UIBord : MonoBehaviour {
    Image _bg;
    Image BG {
        get {
            if( _bg == null )
            {
                _bg = GetComponent<Image>();
            }
            return _bg;
        }
    }

    Button _button;
    Button Button {
        get {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            return _button;
        }
    }

    Bord Bord;

    public Action<Bord> OnSelectBord;

    public void Bind(Bord bord)
    {
        Bord = bord;
        Bord.OnChangeBordType = OnChangeBordType;
        Bord.OnChangeOwner = OnChangeOwner;
        ChangeBG(PlayerType.None);
        Button.onClick.AddListener(() =>
        {
            OnSelectBord.Call(Bord);
        });
    }

    void OnChangeBordType(BordType bordType)
    {
        
    }

    void OnChangeOwner(PlayerType owner)
    {
        ChangeBG(owner);
    }

    void ChangeBG(PlayerType owner)
    {
        BG.color = owner.GetColor();
    }
}
