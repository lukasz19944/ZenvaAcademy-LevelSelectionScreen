using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public static LevelController instance;

    public List<Level> levels;

    private void Awake() {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        }
        if (FindObjectsOfType<LevelController>().Length > 1) {
            Destroy(gameObject);
        }

        levels = new List<Level> {
            new Level(0, "Level1", false, 2, false),
            new Level(1, "Level2", false, 0, true),
            new Level(2, "Level3", false, 0, true),
            new Level(3, "Level4", false, 0, true),
            new Level(4, "Level5", false, 0, true),
            new Level(5, "Level6", false, 0, true),
            new Level(6, "Level7", false, 0, true),
            new Level(7, "Level8", false, 0, true),
            new Level(8, "Level9", false, 0, true),
            new Level(9, "Level10", false, 0, true),
            new Level(10, "Level11", false, 0, true),
            new Level(11, "Level12", false, 0, true),
            new Level(12, "Level13", false, 0, true),
        };
    }

    public void StartLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void CompleteLevel(string levelName) {
        levels.Find(i => i.LevelName == levelName).Complete();
    }

    public void CompleteLevel(string levelName, int stars) {
        levels.Find(i => i.LevelName == levelName).Complete(stars);
    }

    public void LockLevel(string levelName) {
        levels.Find(i => i.LevelName == levelName).Lock();
    }

    public void UnlockLevel(string levelName) {
        levels.Find(i => i.LevelName == levelName).Unlock();
    }
}
