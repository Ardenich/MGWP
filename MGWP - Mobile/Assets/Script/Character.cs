using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

    public GameObject spawnPoint;
    public Text pointText;
    public int points = 0;
    public bool done = false;
    public GameObject[] balls;
    public JoyStickScript joystick;

    Command commandScript;
    Rigidbody2D rb;
    float movSpeed = 3;
    Animator anim;
    Vector2 direction;


    // Use this for initialization
    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = spawnPoint.transform.position;
        commandScript = spawnPoint.GetComponent<Command>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        this.transform.rotation = Quaternion.identity;
        pointText.text = points.ToString();

        if(joystick.Horizontal() == 0 && joystick.Vertical() == 0)
        {
            direction = Vector2.zero;
        }
        else
        {
            direction.x = joystick.Horizontal();
            direction.y = joystick.Vertical();
        }

        rb.velocity = new Vector2(direction.x * movSpeed, direction.y * movSpeed);

        if (direction.y >= 0.1f)
        {
            anim.SetBool("up", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }
        if (direction.y <= -0.1f)
        {
            anim.SetBool("down", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }
        if (direction.x >= 0.1f)
        {
            anim.SetBool("right", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        if (direction.x <= -0.1f)
        {
            anim.SetBool("left", true);
            anim.SetBool("moving", true);
            anim.SetBool("up", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }
        if(rb.velocity == Vector2.zero)
        {
            anim.SetBool("moving", false);
        }

        /*if (Input.GetKey("w"))
        {
            anim.SetBool("up", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            rb.velocity = new Vector2(rb.velocity.x, movSpeed);
        }
        if (Input.GetKey("s"))
        {
            anim.SetBool("down", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            rb.velocity = new Vector2(rb.velocity.x, -movSpeed);
        }
        if (Input.GetKey("a"))
        {
            anim.SetBool("left", true);
            anim.SetBool("moving", true);
            anim.SetBool("up", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
            rb.velocity = new Vector2(-movSpeed, rb.velocity.y);
        }
        if (Input.GetKey("d"))
        {
            anim.SetBool("right", true);
            anim.SetBool("moving", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
            rb.velocity = new Vector2(movSpeed, rb.velocity.y);
        }
        if (!Input.anyKey)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            anim.SetBool("moving", false);
        }*/
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (commandScript.arrayNum == 0 && collision.gameObject.name == "Blue Ball")
            {
                endPoints();
            }
            if (commandScript.arrayNum == 1 && collision.gameObject.name == "Black Ball")
            {
                endPoints();
            }
            if (commandScript.arrayNum == 2 && collision.gameObject.name == "Green Ball")
            {
                endPoints();
            }
        }
    }

    void endPoints()
    {
        done = true;
        points++;
        if (commandScript.timer > 0)
        {
            balls[commandScript.arrayNum].SetActive(false);
        }
        if (commandScript.timer < 0 || done == true)
        {
            balls[commandScript.arrayNum].SetActive(true);
            done = false;
            commandScript.Ended();
        }
    }

}
