using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level {
    public int ID { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Stars { get; set; }
    public bool Locked { get; set; }

    public Level(int id, string leveName, bool completed, int stars, bool locked) {
        this.ID = id;
        this.LevelName = leveName;
        this.Completed = completed;
        this.Stars = stars;
        this.Locked = locked;
    }

    public void Complete() {
        this.Completed = true;
    }

    public void Complete(int stars) {
        this.Completed = true;
        this.Stars = stars;
    }

    public void Lock() {
        this.Locked = true;
    }

    public void Unlock() {
        this.Locked = false;
    }
}
