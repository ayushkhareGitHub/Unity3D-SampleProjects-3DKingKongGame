using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_01 : MonoBehaviour
{
    public float moveVelocity;

    private bool isMoving;
    private int directionChanges = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(
            (isMoving?moveVelocity:-moveVelocity)*Time.deltaTime,
            this.GetComponent<Rigidbody>().velocity.y,
            this.GetComponent<Rigidbody>().velocity.z
        );
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.tag=="Wall")
        {
            isMoving = !isMoving;

            directionChanges--;

            if (directionChanges == 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
