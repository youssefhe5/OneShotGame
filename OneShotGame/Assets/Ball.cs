using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Vector2 touchStartingPosition;
    Vector2 touchEndingPosition;
    private Rigidbody2D rb;
    bool canMove;
    public Vector2 startingPosition = new Vector2(-0.7793833f, -1.404789f);
    public int force = 2;
    public int frameRate = 60;
    private Touch touch;
    public static bool complete;


    void Start()
    {
        complete = false;
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        rb.position = startingPosition;
        //Application.targetFrameRate = frameRate;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartingPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (canMove)
                {
                    touchEndingPosition = touch.position;
                    rb.isKinematic = false;
                    rb.AddForce(force * (touchStartingPosition - touchEndingPosition));
                    canMove = false;
                }
            }

            if (touch.tapCount == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

    }
    
      void OnMouseUp()
    {
        if (canMove)
        {
            touchEndingPosition = Input.mousePosition;
            rb.isKinematic = false;
            rb.AddForce(force * (touchStartingPosition - touchEndingPosition));
            canMove = false;
        }
        
                    

    }

    void OnMouseDown()
    {
        touchStartingPosition = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Bounce boy bounce!");
        }
      
    }

    private void OnBecameInvisible()
    {
        if (complete == false) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
