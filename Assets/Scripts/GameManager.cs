using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int Swedishness; // Life

	public enum GameState {Running, GameOver};

	public GameState State;

	// Use this for initialization
	void Start () {
	
	}

}
