using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour, IGameManager
{

    [SerializeField] private Transform playerStart;
    [SerializeField] private TextMeshProUGUI playerScoreMesh;

    public enum PlayerState
    {
        Playing,
        Won,
        Lost
    }


    public ManagerStatus status { get; private set; }
    public PlayerState playerState;


    public int goalsLost { get; private set; }


    public void Startup()
    {
        Debug.Log("Player manager initialized...");

        goalsLost = 0;
        status = ManagerStatus.Started;
        playerState = PlayerState.Playing;
    }

    public void LosePoint()
    {
        goalsLost++;
       
    }

    public void ScorePlayer()
    {
        
        PlayerManager opponentManager = FindTheOther(transform.parent).gameObject.GetComponent<PlayerManager>();
        opponentManager.LosePoint();
        playerScoreMesh.text = opponentManager.goalsLost + "";
        
    }

    public void ResetPosition()
    {
        FindWithATag(transform, "Movable").position = playerStart.position ;
    }





    #region Utilities
    private Transform FindTheOther(Transform parent)
    {
        /*
         * A function that has as a goal to find me the child of the node that isn't this one
         */


        Transform children1, children2;
        children1 = parent.GetChild(0);
        children2 = parent.GetChild(1);

        if (children1 == transform)
            return children1;
        else
            return children2;
    }


    private Transform FindWithATag(Transform parent, string tag)
    {
        foreach (Transform t in parent)
        {
            if (t.CompareTag(tag))
                return t;
        }
        return null;
    }
    #endregion


}
