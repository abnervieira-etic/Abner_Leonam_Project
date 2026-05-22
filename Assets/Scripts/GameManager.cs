using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public int player1Choice = -1; // -1 indicates no choice made
    public int player2Choice = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   


}
