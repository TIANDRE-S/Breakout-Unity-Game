using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    public static Restart instance;
    [SerializeField] int Scene;
    [SerializeField] Rigidbody2D rb;


    private int lives = 3;
    private void Awake()
    {
        instance = this;
    }

    public void RestartScene()
    {
        lives--;

        if (lives >= 1)
        {
            print(lives);
            rb.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        RestartScene();

    }
}
