using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour {

    /// <summary>
    /// Here you define all variables you are going to use.
    /// Public variables are shown on Unity Inspector when you click on the object with this script attached to them.
    /// Private variables aren't shown on Unity Inspector, if you want a private variable to be shown please see more about [SerializeField]
    /// </summary>
    /// 
    public GameObject obstacle;
    public float distance;

    private float x = 0;

    public int numberOfObstacles = 0;

    void FixedUpdate()
    {
        //Get a random value from minimun range and max range on Y axis
        float y = Random.Range(-2.86f, 2.86f);

        //Define max number of obstacles at once
        if (x < 1000 && numberOfObstacles < 10)
        {
            //Create gameObject on GameScene
            Instantiate(obstacle, new Vector3(x * distance, y, 0), Quaternion.identity);

            //Increase X axis and number of obstacles;
            x++;
            numberOfObstacles++;
        }

    }

}
