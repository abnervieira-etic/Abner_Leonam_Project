using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
                ScoreManager.SMinstance.AddScore1();
                BallSpawner.Ballinstance.Spawn();
                BallSpawner.Ballinstance.DisableBall(other.gameObject);
                Player1.P1instance.ResetPos();
            }
            else if (gameObject.CompareTag ("rightGoal"))
            {
                ScoreManager.SMinstance.AddScore2();
                BallSpawner.Ballinstance.Spawn();
                BallSpawner.Ballinstance.DisableBall(other.gameObject);
                Player1.P1instance.ResetPos();
            }
        }
    }
}
