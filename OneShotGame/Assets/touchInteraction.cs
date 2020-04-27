using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touchInteraction : MonoBehaviour
{

    private Touch touch;
    private Vector2 firstTouch;
    private Vector2 lastTouch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                lastTouch = touch.position;
            }
            if (firstTouch.y < -4)
            {
                if (firstTouch.x - lastTouch.x < 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                }
            }
            
        }
    }
}
