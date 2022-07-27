using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    int level_unlocked;
    // Start is called before the first frame update
    void Start()
    {
        int levelFromPerfs = PlayerPrefs.GetInt("level_unlocked");
        level_unlocked = levelFromPerfs == 0 ? levelFromPerfs : 1 ;
    }

    void UnlockNextLevel()
    {
        if(level_unlocked < 3)
        {
            level_unlocked++;
        }
        PlayerPrefs.SetInt("level_unlocked", level_unlocked);
    }

    void ResetLevel ()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
