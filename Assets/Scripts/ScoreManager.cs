using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int leftGoalScore = 0;
    public int rightGoalScore = 0;

    public static ScoreManager SMinstance;
    [SerializeField] TMP_Text leftGoalTxt;
    [SerializeField] TMP_Text rightGoalTxt;
    void Start()
    {
        if (SMinstance == null)
            SMinstance = this;
    }

    void Update()
    {
        
    }

       public void AddScore1()
    {
        leftGoalScore++;
        leftGoalTxt.text = "" + leftGoalScore.ToString();
    }
       public void AddScore2()
    {
        rightGoalScore++;
        rightGoalTxt.text = "" + rightGoalScore.ToString();
    }
}
