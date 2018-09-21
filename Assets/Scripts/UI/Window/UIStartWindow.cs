using System;
using System.Collections;
using System.Collections.Generic;
using UI.Window;
using UnityEngine;
using UnityEngine.UI;

public class UIStartWindow : UIWindow {
    public Action OnClick;
    [SerializeField] Button touchButton;

    void Awake()
    {
        touchButton.onClick.AddListener(() => {
            OnClick.Call();
        });
    }
}
