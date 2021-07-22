using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public Transform[] waypoints;
    Transform nextWP;
    int wpIndex = 0;
    public float moveSpeed = 3f;
    bool patrol = true;
    public float aggroDistance;
    
    protected override void Start()
    {
        base.Start();
        transform.position = waypoints[0].position;
        nextWP = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(patrol)
        {
            if(Mathf.Abs(Vector2.Distance(nextWP.position, transform.position)) < 0.5f)
            {
                if(wpIndex == waypoints.Length - 1)
                {
                    wpIndex = 0;
                }
                else
                {
                    wpIndex++;
                }
                nextWP = waypoints[wpIndex];
            }
            else
            {
                rb2d.velocity = (Vector2)(nextWP.position - transform.position).normalized * moveSpeed;
            }

            if(Mathf.Abs(Vector2.Distance(player.transform.position, transform.position)) < aggroDistance)
            {
                patrol = false;
            }
        }
        else
        {
            rb2d.velocity = (player.transform.position - transform.position).normalized * moveSpeed;   
        }

        transform.right = rb2d.velocity.x > 0 ? Vector3.right : Vector3.left;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, aggroDistance);
    }
}
