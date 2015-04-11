using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int Swedishness; // Life
	public int MaxSwedishness;

	public enum GameState {Running, GameOver};

	public GameState State;

	// Use this for initialization
	void Start () {
	
		// Calculate maximum Swedishness
		foreach (var s in FindObjectsOfType<SwedishDestructible>()) {
			Swedishness += s.Swedishness;
			MaxSwedishness += s.Swedishness;
		}
	}

	public void DamageSweden (int swedishness)
	{
		Swedishness -= swedishness;
	}

}
