using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;

    private float jumpForce = 7f;
    private int score;
    public Text scoreText;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector2.up * jumpForce;
            
        }

        transform.position = new Vector3(0, Mathf.Clamp(transform.position.y, -10, 6), 0);

        if(transform.position.y < -6)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ScoreTrigger")
        {
            score++;
            scoreText.text = "SCORE : " + score;
        }
    }
}
