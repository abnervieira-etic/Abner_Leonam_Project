using UnityEngine;

public class GameSceneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] playerPrefabs;
    [SerializeField] Transform[] p1SpawnPoint;
    [SerializeField] Transform[] p2SpawnPoint;

    private void Start()
    {
       
        Instantiate(playerPrefabs[GameManager.instance.player1Choice], p1SpawnPoint[0].position,Quaternion.identity);
        Instantiate(playerPrefabs[GameManager.instance.player2Choice], p2SpawnPoint[0].position, Quaternion.identity);

    }
}
