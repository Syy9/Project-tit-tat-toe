using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Manager
{
    public class CoroutineManager : BaseManager
    {
        public void Call(IEnumerator coroutine)
        {
            CoroutineController.Instance.Call(coroutine);
        }
    }

}
