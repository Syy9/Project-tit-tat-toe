using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI.Window;
using UnityEngine;

namespace UI.Lyaer
{
    public class UILayer : MonoBehaviour
    {
        [SerializeField] List<UIWindow> RegisterUIList;

        public UIWindow GetUIWindow(string name)
        {
            return RegisterUIList.FirstOrDefault(ui => ui.name == name);
        }

    }

    [System.Serializable]
    public class UIRegister
    {
        public UIWindow UIWindow;
    }
}
