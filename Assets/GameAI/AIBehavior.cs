using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private float speed;

    private Vector3 direction;

    public Transform ball;
    public Transform goodGoal;


    private void FixedUpdate()
    {

        Vector3 ballTarget = (ball.position - transform.position);
        Vector3 goalTarget = (goodGoal.position - transform.position);

        direction = (ballTarget + goalTarget) / 2;

        playerBody.velocity = speed * new Vector3(direction.normalized.x, 0f, direction.normalized.z)  ;
    }
}
