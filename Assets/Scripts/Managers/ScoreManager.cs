using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
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
       public void AddScore1()
    {
        leftGoalScore++;
        leftGoalTxt.text = "" + leftGoalScore.ToString();  
        if(leftGoalScore == 5)
        {            
            Debug.Log("Player 1 Wins!");
            SceneManager.LoadScene("StartMenu");

        }
    }
       public void AddScore2()
    {
        rightGoalScore++;
        rightGoalTxt.text = "" + rightGoalScore.ToString();   
        if(rightGoalScore == 5)
        {
            Debug.Log("Player 2 Wins!");
            SceneManager.LoadScene("StartMenu");
        }
    }
}
