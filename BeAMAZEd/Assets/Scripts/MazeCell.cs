using UnityEngine;

public class MazeCell : MonoBehaviour {

	public IntVector2 coordinates;
	private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];
	private int initializedEdgeCount;

	public bool IsFullyInitialized	//if all of a cell's neighbors have been expolored
	{
		get
		{
			return initializedEdgeCount == MazeDirections.Count;
		}
	}

	public MazeDirection RandomUninitializedDirection	//a random neighbor that is unexplored
	{
		get
		{
			int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
			for (int i = 0; i < MazeDirections.Count; i++)
			{
				if (edges[i] == null)
				{
					if (skips == 0)
					{
						return (MazeDirection)i;
					}
					skips -= 1;
				}
			}

			throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
		}
	}



	//return edge data for specific direction
	public MazeCellEdge GetEdge (MazeDirection direction)
	{
		return edges[(int)direction];
	}

	//set edge data for specific direction on the cell
	public void SetEdge (MazeDirection direction, MazeCellEdge edge)
	{
		edges[(int)direction] = edge;
		initializedEdgeCount += 1;
	}
}