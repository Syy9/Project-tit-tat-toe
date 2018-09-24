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
        ChangeBG(Bord.BordType);
        Button.onClick.AddListener(() =>
        {
            OnSelectBord.Call(Bord);
        });
    }

    void OnChangeBordType(BordType bordType)
    {
        ChangeBG(bordType);
    }

    void ChangeBG(BordType bordType)
    {
        switch (bordType)
        {
            case BordType.None:
                BG.color = Color.white;
                break;
            case BordType.Blue:
                BG.color = Color.blue;
                break;
            case BordType.Red:
                BG.color = Color.red;
                break;
            default:
                throw new NotImplementedException("Not Implemented BordType");
        }
    }
}
