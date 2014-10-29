using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour 
{	
	public GameObject my_enemy;
	public GameObject my_boss;
	public Vector3 spawnValues;
	public float maxEnemyCount;
	public float rate;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	private int enemyCount;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if(enemyCount<=maxEnemyCount)
		{
			enemyCount = (int) Mathf.Ceil(Mathf.Clamp (Time.timeSinceLevelLoad * rate, 1f, maxEnemyCount));
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (enemyCount<maxEnemyCount)
		{
			for (int i = 0; i < enemyCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (spawnValues.x + transform.position.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Instantiate (my_enemy, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}

		if (enemyCount>=maxEnemyCount)
		{
			Vector3 spawnPosition = new Vector3 (spawnValues.x - 5 + transform.position.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
			Instantiate (my_boss, spawnPosition, Quaternion.identity);
		}
	}
}
