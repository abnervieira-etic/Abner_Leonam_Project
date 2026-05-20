using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefab = new GameObject[3];
    [SerializeField] Transform spawnPoint;
    public static BallSpawner Ballinstance;
    private GameObject currentBall;

    void Start()
    {
        SpawnBall();
    }
    void Awake()
    {
        Ballinstance = this;
    }
    IEnumerator SpawnDelay()
    {   
        DisableBall(currentBall);

        yield return new WaitForSeconds(2f);
        currentBall.transform.position = spawnPoint.position;
        currentBall.transform.rotation = spawnPoint.rotation;
        EnableBall(currentBall);
    }

    public void SpawnBall()
    {
        currentBall = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
    }
    public void SpawnSystem()
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
