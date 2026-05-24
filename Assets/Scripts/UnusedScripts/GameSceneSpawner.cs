using UnityEngine;

public class GameSceneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;
    //[SerializeField] Transform[] p1SpawnPoint;
    //[SerializeField] Transform[] p2SpawnPoint;

    private void Start()
    {
       
        Instantiate(playerPrefabs[GameManager.instance.player1Choice]);
        Instantiate(playerPrefabs[GameManager.instance.player2Choice]);

    }
}
