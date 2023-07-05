using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float minY;
    public float maxY;
    public float randomY;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  
        if(timer >= maxTime) //first object will be created at maxTime (eg:if maxtime=3 then first obstacle will appear 3 secs after the game has started)
        {
            randomY = Random.Range(minY, maxY);  //so the obstacle position on y axis wont be same for every obstacle
            InstantiateObstacle();
            timer = 0;
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
