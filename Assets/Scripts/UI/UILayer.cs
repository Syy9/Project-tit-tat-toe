using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Window;
using UnityEngine;

namespace UI.Lyaer
{
    public class UILayer : MonoBehaviour
    {
        public void Insert(UIWindow uiWindow)
        {
            uiWindow.transform.SetParent(transform);
        }
    }
}
