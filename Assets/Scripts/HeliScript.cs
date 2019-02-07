using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeliScript : MonoBehaviour {

    public float upForce;
    public float speed;
    public Transform camera;
    public Text scoreText;
    public GameObject gameOverScreen;

    private int score;
    private Rigidbody2D rigid;
    private bool isDead = false;


    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) ||  Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0,upForce));
            }

            rigid.transform.position = new Vector3(rigid.transform.position.x + (speed / 100), rigid.transform.position.y);
            camera.position = new Vector3(rigid.transform.position.x, camera.position.y, camera.position.z);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        Destroy(collision.gameObject.transform.parent.gameObject, 10f);
        FindObjectOfType<SpawnObstacle>().numberOfObstacles--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
