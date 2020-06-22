using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialPlayer : MonoBehaviour
{
    public TextMeshProUGUI descriptionDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HeartPickup"))
        {
            descriptionDisplay.text = "Gained new life!";
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShieldPickup"))
        {
            descriptionDisplay.text = "Press Space to activate shield!";
            Destroy(collision.gameObject);
        }
    } 
}
