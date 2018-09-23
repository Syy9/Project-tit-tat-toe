using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

public class GameScene : SceneController {
    Managers managers;
	void Awake () {
        managers = new Managers();
        managers.Init();

        managers.Game.ActivateGame();
	}
}
