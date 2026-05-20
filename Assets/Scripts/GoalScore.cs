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
            }
            else if (gameObject.CompareTag ("rightGoal"))
            {
                ScoreManager.SMinstance.AddScore1();
                BallSpawner.Ballinstance.SpawnSystem();
                Player1.P1instance.ResetPos();
                Player1.P2instance.ResetPos();
            }
        }
    }
}
