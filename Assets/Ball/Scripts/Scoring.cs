using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Scoring : MonoBehaviour
{

    [SerializeField] private GameObject player1, player2;
    [SerializeField] private Transform ballStart;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float drawBackForceIntensity;



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Limit"))
        {
            resetBallPosition();
        }

        // Nchofo had lmochkil dyal scoring, generaliser dikchi ela hadchi
        else if (other.CompareTag("Goal"))
        {
            

            Transform playerWhoGoaled;
            Transform playerWhoLostThePoint = other.transform.parent.parent;

            // Selecting the player
            if (MatchManager.matchInstance.players.GetChild(0) == playerWhoLostThePoint)
                playerWhoGoaled = MatchManager.matchInstance.players.GetChild(1);
            else
                playerWhoGoaled = MatchManager.matchInstance.players.GetChild(0);


            playerWhoGoaled.GetComponent<PlayerManager>().ScorePlayer();
            resetBallPosition();
            MatchManager.matchInstance.resetPlayersPosition();

            

        }

        
    }


    private Vector3 drawBackForce(float force, Transform targetPlayer)
    {
        float direction = -(ballStart.position - targetPlayer.position).x / Mathf.Abs((ballStart.position - targetPlayer.position).x);

        return new Vector3(direction*force, 0f,0f);
    }

    private void resetBallPosition()
    {
        transform.position = ballStart.position;
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
    }

    
}
