using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Maze.cs includes all the algorithms for maze generation
//GameManager.cs is the highest level view of the program, 
//and uses these functions to generate a random maze

public class Maze : MonoBehaviour {

	public IntVector2 size;				//size of maze
	public float generationStepDelay;   //for slowly generating the maze in front of the user

	public MazeCell cellPrefab;			//cell object to be used
	public MazePassage passagePrefab;	//empty object to be used
	public MazeWall wallPrefab;			//wall object to be used

	private MazeCell[,] cells;			//store coordinates of all cells


	public IntVector2 RandomCoordinates	//a random cell in the maze
	{
		get
		{
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

	//if a coordinate is within the bounds of the maze
	public bool ContainsCoordinates (IntVector2 coordinate)
	{
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}

	//return coordinates from vector object
	public MazeCell GetCell (IntVector2 coordinates)
	{
		return cells[coordinates.x, coordinates.z];
	}

	//generate a new maze
	public IEnumerator Generate ()
	{
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);

		cells = new MazeCell[size.x, size.z];
		List<MazeCell> activeCells = new List<MazeCell>();
		
		DoFirstGenerationStep(activeCells);	//get first cell coordinate
		while (activeCells.Count > 0)	//generate the rest of the maze
		{
			yield return delay;
			DoNextGenerationStep(activeCells);
		}
	}

	//get a random coordinate
	private void DoFirstGenerationStep (List<MazeCell> activeCells)
	{
		activeCells.Add(CreateCell(RandomCoordinates));
	}

	//choose next cell in maze path
	private void DoNextGenerationStep (List<MazeCell> activeCells)
	{
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];

		//if the cell is already used, return
		if (currentCell.IsFullyInitialized)
		{
			activeCells.RemoveAt(currentIndex);
			return;
		}

		MazeDirection direction = currentCell.RandomUninitializedDirection;	//choose random direction
		IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();	//choose next cell in that direction
		if (ContainsCoordinates(coordinates))	//if it's in the map
		{
			MazeCell neighbor = GetCell(coordinates);
			if (neighbor == null)	//if it's available
			{
				neighbor = CreateCell(coordinates);
				CreatePassage(currentCell, neighbor, direction);
				activeCells.Add(neighbor);
			}
			else
			{
				CreateWall(currentCell, neighbor, direction);
			}
		}
		else	//(if the space isn't in the map)
		{
			CreateWall(currentCell, null, direction);
		}
	}


	//create new cell
	private MazeCell CreateCell (IntVector2 coordinates)
	{
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
		return newCell;
	}

	//makes sure no wall is put up on the path
	private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction)
	{
		MazePassage passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(cell, otherCell, direction);
		passage = Instantiate(passagePrefab) as MazePassage;
		passage.Initialize(otherCell, cell, direction.GetOpposite());
	}

	//place a wall between two cells
	private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction)
	{
		MazeWall wall = Instantiate(wallPrefab) as MazeWall;
		wall.Initialize(cell, otherCell, direction);

		if (otherCell != null)	//make sure the wall is between two explored cells
		{
			wall = Instantiate(wallPrefab) as MazeWall;
			wall.Initialize(otherCell, cell, direction.GetOpposite());
		}
	}
}