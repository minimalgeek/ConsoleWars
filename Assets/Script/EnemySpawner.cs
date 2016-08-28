using UnityEngine;
using System.Collections;
using Assets.Script;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 5.0f;
    public float spawnTimeDecrease = 0.2f;
    private PlayerHealth playerHealth;
    private float spawnTime;
    private GameObject placeToMoveInHierarchy;

    void Start () {
        placeToMoveInHierarchy = GameObject.FindGameObjectWithTag(Constants.SPAWN_ROOT_TAG);
        playerHealth = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG).GetComponent<PlayerHealth>();
        spawnTime = maxSpawnTime;
        StartCoroutine(SpawnRandom());
	}
	
	void Update () {
	
	}

    private IEnumerator SpawnRandom()
    {
        while (!playerHealth.IsDead)
        {
            GameObject inst = (GameObject)Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)], this.transform.position, Quaternion.identity);
            inst.transform.parent = placeToMoveInHierarchy.transform;
            yield return new WaitForSeconds(spawnTime);
            if (spawnTime > minSpawnTime)
            {
                spawnTime -= spawnTimeDecrease;
            }
        }
    }
}
