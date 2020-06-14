using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMazeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToMazeScene()
    {
        PlayerController.hp = 3;
        PlayerController.shieldsLeft = 0;
        SceneManager.LoadScene("MazeScene");
    }
}
