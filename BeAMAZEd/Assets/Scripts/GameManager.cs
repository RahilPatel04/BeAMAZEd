using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

	public Maze mazePrefab;
	private Maze mazeInstance;

	private void Start()
	{
		BeginGame();
	}

	private void Update()
	{
		//restart game if user presses space
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RestartGame();
		}
	}




	//////////////////////////////////////////////////////////

	private void BeginGame()
	{
		mazeInstance = Instantiate(mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate());        //generate maze
	}

	private void RestartGame()
	{
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}