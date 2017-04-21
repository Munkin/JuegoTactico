using Characters;
using UnityEngine;

namespace Map
{
    public class Tile: MonoBehaviour
    {
        [SerializeField]
        private TerrainType terrain;

		public Character character;

		public Character Character { 
			get{
				
				return character; 
			} 
			set{
				Debug.Log ("paso");
				character = value; 
				if (character != null)
					cost = 0f;
				else
					cost = 1f;
			} 
		}

		[SerializeField]
		private float cost;

		void Awake()
		{/*if (character != null)
				cost = 0f;
			else
				cost = 1f;
				*/
		}

        public float Cost
        {
            get
            {
                //TODO: Get Cost
				return cost;
            }
			set{ cost = value;
			}
        }

        public bool IsOccupied
        {
            get
            {
                return Character != null;
            }
        }
    }
}