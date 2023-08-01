using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour, IGameManager
{


    public enum MatchState
    {
        OnGoing,
        Finished
    }



    public ManagerStatus status { get; private set; }
    public MatchState matchState { get; private set; }
    [SerializeField] private float TotalMatchTime;
    public Transform players;


    #region Singleton matchInstance
    public static MatchManager matchInstance;
    #endregion


    public void Startup()
    {
        Debug.Log(" Match Manager Starting");

        status = ManagerStatus.Started;
        matchState = MatchState.OnGoing;

    }




    private void InitializeTimingPart()
    {
        TimerManager.TimerInstance.InitializeTimer(TotalMatchTime);
        
    }



    private void MatchFinishes()
    {
        matchState = MatchState.Finished;

        int goalsLost1, goalsLost2;
        goalsLost1 = players.GetChild(0).GetComponent<PlayerManager>().goalsLost;
        goalsLost2 = players.GetChild(1).GetComponent<PlayerManager>().goalsLost;


        if (goalsLost1 > goalsLost2)
            Player1Lost();


        else
            Player2Lost();

    }



    private void Player1Lost()
    {
        players.GetChild(0).GetComponent<PlayerManager>().playerState = PlayerManager.PlayerState.Lost;
        players.GetChild(1).GetComponent<PlayerManager>().playerState = PlayerManager.PlayerState.Won;
    }

    private void Player2Lost()
    {
        players.GetChild(1).GetComponent<PlayerManager>().playerState = PlayerManager.PlayerState.Lost;
        players.GetChild(0).GetComponent<PlayerManager>().playerState = PlayerManager.PlayerState.Won;
    }



    public void resetPlayersPosition()
    {
        players.GetChild(0).GetComponent<PlayerManager>().ResetPosition();
        players.GetChild(1).GetComponent<PlayerManager>().ResetPosition();

    }


    #region MonoBehavior

    private void Awake()
    {
        matchInstance = this;
        Startup();
    }

    private void Start()
    {
        InitializeTimingPart();
    }

    private void FixedUpdate()
    {
        
        TimerManager.TimerInstance.TimeEvolution();

        if (TimerManager.TimerInstance.getTime() <= 0f)
            MatchFinishes();

    }
    #endregion
}
