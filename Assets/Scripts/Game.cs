using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    [SerializeField]
    private int level;
	
    public void CompleteLevel(int stars) {
        LevelController.instance.CompleteLevel("Level" + level, stars);

        ExitLevel();
    }

    public void ExitLevel() {
        LevelController.instance.StartLevel("Menu");
    }
}
