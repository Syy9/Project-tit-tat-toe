using System.Collections;
using System.Collections.Generic;
using Game.Manager;
using UnityEngine;

public class GameScene : MonoBehaviour {

    GameManager _gameManager;
	// Use this for initialization
	void Awake () {
        _gameManager = new GameManager();
        _gameManager.Init();
	}    
}
