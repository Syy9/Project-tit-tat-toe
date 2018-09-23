using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(ExecutionOrder.LEVEL_SCENE)]
public class SceneController : MonoBehaviour {
    void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake() { }
}
