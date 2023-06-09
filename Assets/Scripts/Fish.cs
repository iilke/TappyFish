
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_rb.gravityScale = 0; 
    }
    
    // Update is called once per frame
    void Update()
    {
        FishSwim();
        
    }

    private void FixedUpdate() //makes movements smoother that Update()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, 9f);
            }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }

        else if (_rb.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle); //for rotation on z axis
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Scored!..");
        }
    }

}
