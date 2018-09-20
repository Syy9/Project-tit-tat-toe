using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineController : SingletonMonoBehaviour<CoroutineController> {
    public void Call(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
