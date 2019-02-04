using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour {

    public GameObject obstacle;
    public float distance;

    private float x = 0;
    private int numberOfObstacles = 0;

    void FixedUpdate()
    {
        float y = Random.Range(-2.86f, 2.86f);
        if (x < 1000 && numberOfObstacles < 10)
        {
            Instantiate(obstacle, new Vector3(x * distance, y, 0), Quaternion.identity);
            x++;
            numberOfObstacles++;
        }
        Debug.Log(x);
    }

}
