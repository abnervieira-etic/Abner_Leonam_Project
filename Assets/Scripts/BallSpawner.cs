using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform spawnPoint;
    public static BallSpawner Ballinstance;

    void Start()
    {
        Spawn();
        EnableBall(ballPrefab);
    }
    void Awake()
    {
        Ballinstance = this;
    }
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(2f);
        EnableBall(ballPrefab);
        Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void Spawn()
    {
        StartCoroutine(SpawnDelay());
    }

    public void DisableBall(GameObject ball)
    {
        ball.SetActive(false);
    }

    public void EnableBall(GameObject ball)
    {
        ball.SetActive(true);
    }
}
