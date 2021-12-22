using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    private bool turnLeft, turnRight, jump, slide;
    public float speed;
    public float jumpSpeed;
    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity = Vector3.zero;
    dragonController dragon;
    public Text scoreText;
    private int score = 0;
    private float startTime;
    public Text gameover;
    //private float gravityValue = -100.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        dragon = GameObject.FindObjectOfType<dragonController>();
        alive = true;
        score = 0;
        startTime = Time.time;
        gameover.enabled = false;
    }
    private float margin = 0.1f;
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, margin);
    }
    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (Time.time - startTime > 1)
            {
                score++;
                startTime = Time.time;
            }
            scoreText.text = "SCORE: " + score;
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = 0;
            }

            if (transform.position.y < -5)
            {
                Die();
            }
            turnLeft = Input.GetKeyDown(KeyCode.A);
            turnRight = Input.GetKeyDown(KeyCode.D);
            jump = Input.GetKeyDown(KeyCode.Space);
            slide = Input.GetKeyDown(KeyCode.S);
            if (turnLeft)
                transform.Rotate(new Vector3(0f, -90f, 0f));
            else if (turnRight)
                transform.Rotate(new Vector3(0f, 90f, 0f));
            if (IsGrounded() && jump)
            {
                playerVelocity.y += jumpSpeed;
                animator.Play("Jump");
            }
            else if (IsGrounded() && slide)
            {
                //animator.Play("Slide");
            }
            /*else if(alive && IsGrounded())
            {
                animator.Play("Running");
            }*/
            playerVelocity.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            controller.SimpleMove(new Vector3(0f, 0f, 0f));
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
    }
    public void Die()
    {
        alive = false;
        gameover.enabled = true;
        animator.Play("Idle");
        // Restart the game
        Debug.Log("Restart");
        //SceneManager.LoadScene(0);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            Debug.Log("Die");
            dragon.catchPlayer();
            Die();
        }
        if (hit.gameObject.tag == "coin")
        {
            Debug.Log("getCoin");
            Destroy(hit.gameObject);
            score++;
        }
    }
}
