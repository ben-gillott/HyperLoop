using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    void Update()
    {
        //If key down, and not in play state, start playing
        if ((Input.GetMouseButtonDown(0) || Input.GetKey("space")) & (SceneManager.GetActiveScene().buildIndex != 1)){
            LoadPlayScene();
        }
    }

    public void playerDied(){
        //If player died, switch to game over state
        StartCoroutine(LoadLevel(2));
    }

    public void LoadPlayScene(){
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex){
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);
        
        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
