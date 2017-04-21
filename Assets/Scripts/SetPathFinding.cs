using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map{

public class SetPathFinding : MonoBehaviour {

		[SerializeField]
		public Tilemap myGround;

		private float[,] tilesmap;

		PathFind.Grid grid;

		private PathFind.Pathfinding pathFindingMachin = new PathFind.Pathfinding();


		// Use this for initialization
		void Start () {
			

		
		}


		PathFind.Grid FillTileMap ()
		{
			int xSize = myGround.tiles [0].tiles.Length;
			int ySize = myGround.tiles.Length;

			tilesmap = new float[xSize,ySize];





			for (int i = 0; i < xSize; i++) 
			{
				for (int j = 0; j < ySize; j++) 
				{


					tilesmap [i, j] = myGround.GetTileAt (new Vector2 (i, j)).Cost;
				}
			}

			grid = new PathFind.Grid (xSize, ySize, tilesmap);
			return grid;
		}

		public List<Vector2> PathFinding(Vector2 startPoint, Vector2 endPoint)
		{
			
			
			PathFind.Point _from = VectorToPoint (startPoint);
			PathFind.Point _to = VectorToPoint (endPoint);
			List<PathFind.Point> path =  PathFind.Pathfinding.FindPath (FillTileMap(), _from, _to);
			List<Vector2> realPath = new List<Vector2>();

			foreach (PathFind.Point myPoint in path) 
			{
				realPath.Add (PointToVector (myPoint));
			}

			return realPath;
		}

		public Vector2 PointToVector (PathFind.Point point)
		{
			Vector2 tempVector = new Vector2 (point.x, point.y);
			return tempVector;
		}

		public PathFind.Point VectorToPoint (Vector2 point)
		{
			int x = (int)point.x;
			int y = (int)point.y;
			PathFind.Point tempPoint = new PathFind.Point (x, y);
			return tempPoint;
		}

	
	}
}
