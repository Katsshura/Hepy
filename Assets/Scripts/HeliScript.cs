using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliScript : MonoBehaviour {

    public float upForce;
    public float speed;
    private Rigidbody2D rigid;
    private bool isDead = false;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0,upForce));
            }

            rigid.transform.position = new Vector3(rigid.transform.position.x + (speed / 100), rigid.transform.position.y);
        }
	}
}
