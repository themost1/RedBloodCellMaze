using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 20;
    public int hp = 3;
    private TextMeshProUGUI WinText;

    private int points;
    private int StatusAlive;
    private bool facingRight;

    public float invFrames = 1.2f;
    public float hpTime = 0;

    public Sprite shieldedSprite;
    public Sprite regularSprite;
    public Sprite whiteSprite;
    public float shieldTime = 0;

    public string color = "red";
    public int shieldsLeft = 0;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StatusAlive = 0;
            Debug.Log("uh oh...");
        }
        else if (collision.gameObject.CompareTag("Prize"))
        {
            points += 1;
            Debug.Log("points +1");
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
            SceneManager.LoadScene("RestartScene");
    }

}
