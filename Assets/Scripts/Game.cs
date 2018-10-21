using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
            LevelController.instance.CompleteLevel("Level1", 1);
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            LevelController.instance.StartLevel("Menu");
        }
    }
}
