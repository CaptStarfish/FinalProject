using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    public GameController gameController;

    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script bg");
        }
        gameObject.GetComponent<MoverBolt>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            gameObject.GetComponent<MoverBolt>().enabled = true;
            gameObject.GetComponent<Mover>().enabled = false;
        }
    }
}