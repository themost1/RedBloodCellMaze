using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTutorial1()
    {
        SceneManager.LoadScene("TutorialScene1");
    }

    public void GoToTutorial2() 
    {
        SceneManager.LoadScene("TutorialScene2");
    }

    public void GoToMazeScene()
    {
        PlayerController.hp = 3;
        PlayerController.shieldsLeft = 0;
        SceneManager.LoadScene("MazeScene");
    }
}
