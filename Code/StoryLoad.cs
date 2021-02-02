using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryLoad : MonoBehaviour
{
    float timeLeft = 10.0f;
    Animator storyAnimator;
    [SerializeField] private string loadLevel;
    [SerializeField] private bool playInstantly, endLevel;
    public GameObject endGameScreen;

    void Start()
    {
        storyAnimator = (Animator)GameObject.Find("CanvasGroup").GetComponent<Animator>();
        if (!playInstantly)
            endGameScreen.SetActive(false);
        endLevel = false;
    }

    // This scene will playout in the time specified on timeLeft after that it will fade out into the tutorial level

    void Update()
    {
        PlayScene();
        EndLevelAnim();
    }

    void PlayScene()//Plays StoryScene 1 Animation
    {
        if (playInstantly)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
                storyAnimator.Play("Crossfade_end");
            if (timeLeft < -4)
                SceneManager.LoadScene(loadLevel);
        }
    }

    public void EndLevelAnim()//Plays ending screen and takes you to selected level.
    {
        if (endLevel)
        {
            endGameScreen.SetActive(true);
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
                storyAnimator.Play("EndGameEndAnim");
            if (timeLeft < -4)
                SceneManager.LoadScene(loadLevel);
        }
    }

    public void ToggleEnd()
    {
        endLevel = true;
    }

}
