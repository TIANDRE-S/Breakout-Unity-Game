using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float ballSpeed = 2f;
    [SerializeField] Transform playerTransform;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] int yellowBrickValue = 1;
    [SerializeField] int greenBrickValue = 3;
    [SerializeField] int orangeBrickValue = 5;
    [SerializeField] int redBrickValue = 7;
    private Rigidbody2D rb;
    private bool hitOrange = false;
    private bool hitRed = false;
    private bool hitTop = false;
    private int hits = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(ballSpeed, -ballSpeed);
        Debug.Log("Hits = " + hits);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player"
        || other.gameObject.tag == "Wall"
        || other.gameObject.tag == "Top") { return; }

        ScoreManager.instance.WinState();
        if (other.gameObject.tag == "YellowBrick"
        || other.gameObject.tag == "GreenBrick")
        {
            if (other.gameObject.tag == "YellowBrick")
            {
                ScoreManager.instance.AddPoints(yellowBrickValue);
            }
            if (other.gameObject.tag == "GreenBrick")
            {
                ScoreManager.instance.AddPoints(greenBrickValue);
            }
            hits++;
            Debug.Log("Hits = " + hits);

            if (hits == 4)
            {
                ballSpeed = ballSpeed + 2f;
            }
            if (hits == 12)
            {
                ballSpeed = ballSpeed + 2f;
            }

            if (other.gameObject.tag == "OrangeBrick" && !hitOrange)
            {
                ScoreManager.instance.AddPoints(orangeBrickValue);
                hitOrange = true;
                ballSpeed = ballSpeed + 2f;
            }
            if (other.gameObject.tag == "RedBrick" && !hitRed)
            {
                ScoreManager.instance.AddPoints(redBrickValue);
                hitRed = true;
                ballSpeed = ballSpeed + 2f;
            }

            Destroy(other.gameObject);
            Debug.Log("Bounced off Brick");
        }

        // Changes paddle to half its size
        if (other.gameObject.tag == "Top" && !hitTop)
        {
            hitTop = true;

            playerTransform.transform.localScale = new Vector3(
                 playerTransform.transform.localScale.x / 2,
                 playerTransform.transform.localScale.y,
                 playerTransform.transform.localScale.z);
            Debug.Log("Hit Top Wall");
        }

    }




}
