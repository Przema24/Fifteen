using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class Cell : MonoBehaviour
    {
        private Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public void SetStartPosition(Vector2 pos)
        {
            Position = pos;
        }
    }
}