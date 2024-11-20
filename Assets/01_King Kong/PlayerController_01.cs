using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_01 : MonoBehaviour
{
    public float jumpForce;
    public float moveVelocity;
    public float climbVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));
        }

        if (Input.GetKey("d"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                moveVelocity*Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
                );
        }

        if (Input.GetKey("a"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                -moveVelocity * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
                );
        }
    }

    void OnTriggerStay(Collider c)
    {
        Debug.Log(c.name);
        if (c.gameObject.GetComponent<LadderController_01>() != null)
        {
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(
                    this.GetComponent<Rigidbody>().velocity.x,
                    climbVelocity * Time.deltaTime,
                    this.GetComponent<Rigidbody>().velocity.z
                    );
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.GetComponent<EnemyController_01>() != null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.tag=="Orb")
        {
            Time.timeScale = 0;
//            GameObject.Destroy(this.gameObject);
         
        }
    }
}
