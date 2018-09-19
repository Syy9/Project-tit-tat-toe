using System.Collections;
using System.Collections.Generic;
using UI.Lyaer;
using UnityEngine;

namespace UI
{
    public class UIController : SingletonMonoBehaviour<UIController> {
        public UILayer Content;
        public UILayer Popup;
    }
}
