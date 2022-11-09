using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField]
    private float xDirection;
    [SerializeField]
    private float yDirection;
    [SerializeField]
    Vector2 move;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private float speedMod;

    float time;

    // Start is called before the first frame update
    void Start()
    {

        newDirection();
       
    }

    // Update is called once per frame
    void Update()
    {
         time = Time.deltaTime;
        ballMovement(time);
    }

    private void ballMovement(float time)
    {
        ball.transform.position = new Vector2(ball.transform.position.x + (speedMod * xDirection*time), ball.transform.position.y + (speedMod * yDirection*time));
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            yDirection = -yDirection;
        }
    }
    private void newDirection()
    {
        xDirection = Random.Range(-1f, 1f);
        yDirection = Random.Range(-1f, 1f);
        move = new Vector2(xDirection, yDirection);
    }
}
