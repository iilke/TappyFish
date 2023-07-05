using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;
    float obstacleWidth;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Ground"))   //using tags for dissociating ground's movement from obstacle's movement
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);  //moves ground to left

        if (gameObject.CompareTag("Ground")) {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);  //looping grounds
            }
        }
        else if (gameObject.CompareTag("Obstacle")) //to destroy obstacle when they have passed behind from scene so we dont have clutter left behind
        {
            if (transform.position.x < GameManager.bottomLeft.x - obstacleWidth)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
