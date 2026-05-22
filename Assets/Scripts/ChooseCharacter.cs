using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;
    [SerializeField] Button startGameButton;
    [SerializeField] string gameSceneName = "GameScene";

    string[] characters = { "Tralalelo", "TungTungSahur"};

    private void Start()
    {
        startGameButton.interactable = false;
        p1Text.text = "Player 1: Choose your character";
        p2Text.text = "Player 2: Choose your character";

        if(GameManager.instance == null)
        {
            new GameObject("GameManager").AddComponent<GameManager>();
        }

    }
    public void P1PickCharacter(int index)
    {
        GameManager.instance.player1Choice = index;
        p1Text.text = $"Player 1: {characters[index]}";
        CheckReady();


    }

    public void P2PickCharacter(int index)
    {
        GameManager.instance.player2Choice = index;
        p2Text.text = $"Player 2: {characters[index]}";
        CheckReady();
    }

    private void CheckReady()
    {
        startGameButton.interactable = GameManager.instance.player1Choice >= 0 && GameManager.instance.player2Choice >= 0;
    }

    public void StartGame()
    {
        if (GameManager.instance.player1Choice >= 0 && GameManager.instance.player2Choice >= 0)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
