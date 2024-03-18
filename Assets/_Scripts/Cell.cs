using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Vector2Int position;

        public Vector2Int Position
        {
            get { return position; }
            set { position = value; }
        }

        public void SetStartPosition(Vector2Int pos)
        {
            Position = pos;
        }
    }
}