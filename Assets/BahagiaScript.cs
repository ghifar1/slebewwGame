using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BahagiaScript : MonoBehaviour
{
    private PlayableDirector bahagiaCutScene;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        bahagiaCutScene = gameObject.GetComponent<PlayableDirector>();
        bahagiaCutScene.stopped += OnCutsceneFinish;
    }

    void OnCutsceneFinish(PlayableDirector aDirector)
    {
        Debug.Log("Finish");
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            bahagiaCutScene.Play();
            gameManager.ChangeCutSceneStatus(false);
        }
    }
}
