using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeliScript : MonoBehaviour {

    /// <summary>
    /// Here you define all variables you are going to use.
    /// Public variables are shown on Unity Inspector when you click on the object with this script attached to them.
    /// Private variables aren't shown on Unity Inspector, if you want a private variable to be shown please see more about [SerializeField]
    /// </summary>

    public float upForce;
    public float speed;
    public Transform camera;
    public Text scoreText;
    public GameObject gameOverScreen;

    private int score;
    private Rigidbody2D rigid;
    private bool isDead = false;


    /// <summary>
    /// This method is called when the Object with this script attached is initialized.
    /// Use it to start variables or define behaviours that you want your code to have.
    /// </summary>
    void Start () {

        // Obtaining RigidBody2D which is in Object and referencing in to rigid variable.
        rigid = GetComponent<Rigidbody2D>();

        //Initialization of score with 0
        score = 0;
	}

    /// <summary>
    /// This method is called once per frame during the executation of your app
    /// Use it to check stats of variables, to make loops, check for inputs and etc
    /// </summary>
    void Update () {

        //Checking if player is dead, I only want the code to be executed if he isn't dead.
        if (isDead == false)
        {
            //Getting Input from Keyboard space for debuging on editor and MouseButton
            //Ps.: On mobile unity get's touch as mouse button as well
            if (Input.GetKeyDown(KeyCode.Space) ||  Input.GetMouseButtonDown(0))
            {
                //Setting velocity to 0 and adding a force to it, so it can "jump"
                rigid.velocity = Vector2.zero;
                rigid.AddForce(new Vector2(0,upForce));
            }

            //Making the bird deslocate itself on X axis (for the bird, we only need to specify X and Y).
            rigid.transform.position = new Vector3(rigid.transform.position.x + (speed / 100), rigid.transform.position.y);

            //Making Camera follows bird on X axis, we need to specify Z axis as well because we need the camera to be far from the bird.
            camera.position = new Vector3(rigid.transform.position.x, camera.position.y, camera.position.z);
        }
	}

    /// <summary>
    /// This method is called every time the bird pass through a trigger collider.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the bird hit's the trigger it means that he passed through an obstacle

        //So increase score
        score++;
        //Set score on UI
        scoreText.text = score.ToString();

        //Destroy the obstacle after a determinated time.
        Destroy(collision.gameObject.transform.parent.gameObject, 10f);

        //Find and get SpawnObstacle and decrease the number of obstacles.
        FindObjectOfType<SpawnObstacle>().numberOfObstacles--;
    }

    /// <summary>
    /// This method is called every time the bird collides with a collider.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If collided means that game is over so:

        //Define that player is dead
        isDead = true;

        //Activate Game Over UI
        gameOverScreen.SetActive(true);
    }

    //Method to reload the actual scene.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
