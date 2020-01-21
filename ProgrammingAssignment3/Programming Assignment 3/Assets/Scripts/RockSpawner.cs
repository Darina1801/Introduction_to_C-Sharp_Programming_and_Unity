using UnityEngine;

public class RockSpawner : MonoBehaviour
{
	// needed for spawning
	[SerializeField]
	GameObject prefabGreenRock;
	[SerializeField]
	GameObject prefabMagentaRock;
	[SerializeField]
	GameObject prefabWhiteRock;

	// spawn control
	const float MinSpawnDelay = 1;
	const float MaxSpawnDelay = 2;
	Timer spawnTimer;

	// spawn location support
	const int SpawnBorderSize = 100;
	int minSpawnX;
	int maxSpawnX;
	int minSpawnY;
	int maxSpawnY;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
		// save spawn boundaries for efficiency
		minSpawnX = SpawnBorderSize;
		maxSpawnX = Screen.width - SpawnBorderSize;
		minSpawnY = SpawnBorderSize;
		maxSpawnY = Screen.height - SpawnBorderSize;

		// create and start timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
		spawnTimer.Run();
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// count objects currently on the screen
		int count = GameObject.FindGameObjectsWithTag("OnTheScreen").Length;

		// check for time to spawn a new rock
		if (spawnTimer.Finished && count < 3)
		{
			SpawnRock();

			// change spawn timer duration and restart
			spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
			spawnTimer.Run();
		}

		/// <summary>
		/// Spawns a new rock at a random location
		/// </summary>
		void SpawnRock()
		{
			// generate random location and create new rock
			Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX),
				Random.Range(minSpawnY, maxSpawnY),
				-Camera.main.transform.position.z);
			Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

			// spawn random prefab
			int prefabNumber = Random.Range(0, 3);
			if (prefabNumber == 0)
			{
				GameObject greenRock = Instantiate<GameObject>(
					prefabGreenRock,
					worldLocation, Quaternion.identity);
				greenRock.tag = "OnTheScreen";
			}
			else if (prefabNumber == 1)
			{
				GameObject magnetaRock = Instantiate<GameObject>(prefabMagentaRock,
					worldLocation, Quaternion.identity);
				magnetaRock.tag = "OnTheScreen";
			}
			else
			{
				GameObject whiteRock = Instantiate<GameObject>(prefabWhiteRock,
					worldLocation, Quaternion.identity);	
				whiteRock.tag = "OnTheScreen";
			}
		}
	}
}
