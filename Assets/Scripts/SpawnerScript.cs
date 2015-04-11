using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	
	public int SpawnMultipler = 1;

	public int SpawnAdditionPerLevel;
	
	public int SpawnN;

	public enum GameState { Playing, GameOver , Start};

	public int Wave = 1;

	public GameState myState;

	public float SpawnTime;
	public GameObject[] Spawn;
	public float timer;

	public int EnemiesSpawned;
	public int MaxEnemies = 1;


	public Transform[] locations;

	public int[] Level = new int[] { 0, 1, 2 ,3, -1, 0, 0,0,-1};
	private int levelCounter;
	public bool waiting;

	public void EnemyKilled() {
		EnemiesSpawned--;
		if (waiting && EnemiesSpawned<=0) {
			waiting = false;
			Wave++;
			MaxEnemies = 0;
		}
	}

	public void StartGame() {
		myState = GameState.Playing;
	}

	// Use this for initialization
	void Start () {
	
	}

	public void SpawnEnemy(int i) {

		int type = i/10; // 10 kinds of positions... should be Okay!
		int location = i%10;

		GameObject spawn = Spawn[type];

		Instantiate(spawn, locations[location].position, Quaternion.identity);
		EnemiesSpawned++;
		MaxEnemies++;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (myState != SpawnerScript.GameState.Playing)
			return;


		if (timer <=0) {
			if (!waiting) {
				if (levelCounter == Level.Length) {
					Debug.Log("WRAP");
					levelCounter=0;
					SpawnMultipler+=SpawnAdditionPerLevel;
				}
				
				
				var i = Level[levelCounter];
				if (i==-1) {
					waiting = true;
					levelCounter++;
				} else {
					if (SpawnMultipler > SpawnN) {
						SpawnEnemy(i);
						SpawnN++;
						timer = SpawnTime;
						if (SpawnN == SpawnMultipler) {
							SpawnN = 0;
							levelCounter++;
						}
					}
				}
			}
		} else {
			timer-=Time.fixedDeltaTime;
		}

	}
}
