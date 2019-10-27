
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public Text scoreText;
    public Text winText;

    private int scoreValue;

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        winText.text = "";
        SetCountText();
    }


    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue = scoreValue + 1;
            //score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetCountText();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }

    void SetCountText()
    {
        scoreText.text = "count: " + scoreValue.ToString(); 
        if (scoreValue >= 6)
        {
            winText.text = "u win";
        }
    }
}
