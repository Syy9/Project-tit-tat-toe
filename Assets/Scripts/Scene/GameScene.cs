using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

public class GameScene : MonoBehaviour {
    Managers managers;
	void Awake () {
        managers = new Managers();
        managers.Init();

        managers.Game.ActivateGame();
	}
}
