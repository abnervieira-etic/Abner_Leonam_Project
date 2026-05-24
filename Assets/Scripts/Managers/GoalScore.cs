using System.Collections;
using Unity.Cinemachine;
using UnityEngine;



public class GoalScore : MonoBehaviour
{


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
                UImanager.instance.CallGoal(); 
                UImanager.instance.HideModifier();
                SoundManager soundManager = FindObjectOfType<SoundManager>();
                if (soundManager != null)
                {
                    soundManager.PlayTralaleloSound();
                }
                ReturnModifier();
            }
            else if (gameObject.CompareTag ("rightGoal"))
            {
                ScoreManager.SMinstance.AddScore1();
                BallSpawner.Ballinstance.SpawnSystem();
                Player1.P1instance.ResetPos();
                Player1.P2instance.ResetPos();
                StartCoroutine(P2WinnerZoom()); 
                UImanager.instance.CallGoal(); 
                UImanager.instance.HideModifier();
                SoundManager soundManager = FindObjectOfType<SoundManager>();
                if (soundManager != null)
                {
                    soundManager.PlayTungTungSound();
                }
                ReturnModifier();  
            }
        } 
    }
    void ReturnModifier()
    {
        if (ModifierManager.instance.activeModifier != null)
        {
            OBJpooler.Instance.ReturnObject(ModifierManager.instance.activeModifier);
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
