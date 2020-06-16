using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 20;
    public static int hp = 3;
    private TextMeshProUGUI WinText;

    private int points;
//    private int StatusAlive;
    private bool facingRight;

    public float invFrames = 1.2f;
    public float hpTime = 0;

    public Sprite shieldedSprite;
    public Sprite regularSprite;
    public Sprite whiteSprite;
    public Sprite damagedSprite;

    public float shieldTime = 0;

    public string color = "red";
    public static int shieldsLeft = 0;
    public static int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        // points = 0;
        // SetPointsText ();
        // WinText.text = "";
        // StatusAlive = 1;
        // facingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpTime > 0)
        {
            hpTime -= Time.deltaTime;
        } else
        {
            hpTime = 0;
        }

        if (shieldTime > 0)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = shieldedSprite;
            shieldTime -= Time.deltaTime;
        }
        else if (hpTime > 0 && hpTime % 0.2 < 0.1)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = damagedSprite;
        }
        else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = regularSprite;
        }
    }

    void FixedUpdate() {
        float xDir = 0, yDir = 0;
        if (Input.GetKey(KeyCode.A))
            xDir = -1;
        if (Input.GetKey(KeyCode.D))
            xDir = 1;
        if (Input.GetKey(KeyCode.W))
            yDir = 1;
        if (Input.GetKey(KeyCode.S))
            yDir = -1;
        transform.position += speed * Time.deltaTime * new Vector3(xDir, yDir, 0f);
        // Debug.Log("transforms: xDir " + yDir + " " + transform.position);

        bool flip = (facingRight && xDir < 0) || (!facingRight && xDir >= 0);
        facingRight = xDir >= 0;
        transform.Rotate(0f, flip ? 180f : 0f, 0f);

        if (Input.GetKey(KeyCode.Space))
        {
            if (shieldTime <= 0 && shieldsLeft > 0)
            {
                shieldsLeft--;
                shieldTime = 3;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage();
        }
        else if (collision.gameObject.CompareTag("HeartPickup"))
        {
            if (hp < 3) hp++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("ShieldPickup"))
        {
            if (shieldsLeft < 3) shieldsLeft++;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("MazeEnd"))
        {
            score++;
            SceneManager.LoadScene("MazeScene");
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        }
        
    }

    // void SetPointsText()
    // {
    //     // SetPointsText.text = "Points: " + points.ToString ();
    //     if (StatusAlive == 0){
    //         WinText.text = "You died";
    //     }
    //     if (points >= 10){
    //         WinText.text = "You won";
    //     }

    // }

    public void takeDamage()
    {
        if (shieldTime > 0)
        {
            return;
        }

        if (hpTime > 0) return;
    
        hp--;
        hpTime = invFrames;
        if (hp <= 0)
        {
            hp = 3;
            shieldsLeft = 0;
            score = 0;
            SceneManager.LoadScene("RestartScene");
        }
    }

}
