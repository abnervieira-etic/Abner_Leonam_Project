using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
     [SerializeField] GameObject[] ballPrefabs = new GameObject[3];
    [SerializeField] Transform spawnPoint;
    public static BallSpawner Ballinstance;

    private GameObject[] instances; // referências reais na cena
    private GameObject currentBall;
    public GameObject CurrentBall => currentBall;
    public int index;

    void Awake() => Ballinstance = this;

    void Start()
    {
        instances = new GameObject[ballPrefabs.Length];
        for (int i = 0; i < ballPrefabs.Length; i++)
        {
            instances[i] = Instantiate(ballPrefabs[i], spawnPoint.position, spawnPoint.rotation);
            instances[i].SetActive(false); 
        }

        RandomBall();
        currentBall.SetActive(true);
    }

    void RandomBall()
    {
        int index = Random.Range(0, instances.Length);
        currentBall = instances[index];
    }

    IEnumerator SpawnDelay()
    {
        currentBall.SetActive(false);
        yield return new WaitForSeconds(2f);

        RandomBall();

        currentBall.transform.position = spawnPoint.position;
        currentBall.transform.rotation = spawnPoint.rotation;
        currentBall.SetActive(true);
    }

    public void SpawnSystem() => StartCoroutine(SpawnDelay());
}
