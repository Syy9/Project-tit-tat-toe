﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Window
{
    public class UIWindow : MonoBehaviour
    {

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }


}
