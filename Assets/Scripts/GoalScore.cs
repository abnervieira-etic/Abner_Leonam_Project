using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class GoalScore : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (gameObject.CompareTag ("leftGoal"))
            {
                ScoreManager.SMinstance.AddScore2();
                BallSpawner.Ballinstance.SpawnSystem();
                Player1.P1instance.ResetPos();
                Player1.P2instance.ResetPos();
                StartCoroutine(P1WinnerZoom());
            }
            else if (gameObject.CompareTag ("rightGoal"))
            {
                ScoreManager.SMinstance.AddScore1();
                BallSpawner.Ballinstance.SpawnSystem();
                Player1.P1instance.ResetPos();
                Player1.P2instance.ResetPos();
                StartCoroutine(P2WinnerZoom());
            }
        } 
    }

    IEnumerator P1WinnerZoom()
    {
        CinemachineTargetGroup targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.Targets[0].Weight = 0f; 
        targetGroup.Targets[1].Weight = 1f; 
        yield return new WaitForSeconds(2f);
        targetGroup.Targets[0].Weight = 1f; 
        targetGroup.Targets[1].Weight = 1f; 
    }

    IEnumerator P2WinnerZoom()
    {
        CinemachineTargetGroup targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        targetGroup.Targets[0].Weight = 1f; 
        targetGroup.Targets[1].Weight = 0f; 
        yield return new WaitForSeconds(2f);
        targetGroup.Targets[0].Weight = 1f; 
        targetGroup.Targets[1].Weight = 1f; 
    }

}
