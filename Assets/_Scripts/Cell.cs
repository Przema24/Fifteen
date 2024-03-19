using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FifteenGame
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] TextMeshPro numberText;
        [SerializeField] SpriteRenderer spriteRenderer;
        private Vector2Int position;
        private int number;
        public int Number
        {
            get { return number; }
            private set { number = value; }
        }

        public Vector2Int Position
        {
            get { return position; }
            set { position = value; }
        }

        public void SetStartPosition(Vector2Int pos)
        {
            Position = pos;
        }

        public void SetNumber(int newNumber)
        {
            Number = newNumber;
            UpdateText();
        }

        private void UpdateText()
        {
            numberText.text = number.ToString();
        }

        public void ChangeColor(Color color)
        {
            spriteRenderer.color = color;
        }
    }
}