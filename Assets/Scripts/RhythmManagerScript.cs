using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManagerScript : MonoBehaviour
{
    public float timeAlive = 0;
    public float timeCutoff = 1.2f;
    public AudioSource heartbeat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > timeCutoff)
        {
            toggleState();
        }
    }

    void toggleState()
    {
        print("Toggling");
        timeAlive = 0;
        heartbeat.Stop();
        heartbeat.Play(0);
        GameObject[] go = GameObject.FindGameObjectsWithTag("RhythmObstacle");
        for (int i = 0; i < go.Length; ++i)
        {
            go[i].GetComponent<RhythmObstacle>().toggleState();
        }

    }
}
