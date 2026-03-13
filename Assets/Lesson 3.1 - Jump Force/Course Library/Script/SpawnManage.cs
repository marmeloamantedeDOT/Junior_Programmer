using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController4 playerController4Script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerController4Script =
            GameObject.Find("Player").GetComponent<PlayerController4>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if (playerController4Script.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
      
    }
}
