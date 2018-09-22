using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Window
{
    public class UIWindow : MonoBehaviour
    {

        public void Show(UILayerType type)
        {
            gameObject.SetActive(true);
            UIController.Instance.GetUILayer(type).Insert(this);

        }

        public void Hide()
        {
            GameObject.Destroy(gameObject);
        }
    }


}
