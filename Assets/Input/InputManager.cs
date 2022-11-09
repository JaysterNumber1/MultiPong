using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Input input;
    [SerializeField]
    private Vector2 move;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speedMod = 1;



    private void Awake()
    {
        input = new Input();
        input.Enable();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        input.Player.Movement.performed +=  input => move = input.ReadValue<Vector2>();


    }

    // Update is called once per frame
    void Update()
    {
        playerMovement(Time.deltaTime);

        
    }

    void playerMovement(float time)
    {
        if (move.y == 1)
        {

            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1 * Time.deltaTime * speedMod);

        }
        if (move.y == -1){

            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1 * Time.deltaTime *speedMod);

        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            if (move.y != 0)
            {
                move.y = 0;
            }
           
        }
        else
        {
            Debug.Log("Collision!");
        }

        
    }

}
