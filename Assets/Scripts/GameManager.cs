using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public Text textCounter;
    public PlayableDirector timeline;
    public PlayableDirector failedCutscene;

    [Header("Player")]
    public Transform player;

    [Header("Cutscene")]
    public float timerCounter = 0;
    private bool isCutSceneDone = false;

    [Header("Checkpoint")]
    public Vector3 checkpoint = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        timeline.Play();
        timeline.stopped += OnCutsceneFinish;
        failedCutscene.stopped += OnFailedSceneFinish;
        textCounter.text = "Cutscene";
        Cursor.visible = false;
        checkpoint = player.position;
    }

    void OnFailedSceneFinish(PlayableDirector aDirector)
    {
        SceneManager.LoadScene(0);
    }

    void OnCutsceneFinish(PlayableDirector aDirector)
    {
        Debug.Log("Finish");
        isCutSceneDone = true;
    }

    public void SpawnToLastCheckPoint()
    {
        player.position = checkpoint;
    }

    public void SaveCheckPoint(Vector3 cp)
    {
        checkpoint = cp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCutSceneDone)
        {
            float minutes = Mathf.FloorToInt(timerCounter / 60);
            float seconds = Mathf.FloorToInt(timerCounter % 60);
            timerCounter += Time.deltaTime;
            textCounter.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if(Mathf.FloorToInt(timerCounter / 60) == 2)
        {
            Debug.Log("mulaii");
            failedCutscene.Play();
        }
    }
}
