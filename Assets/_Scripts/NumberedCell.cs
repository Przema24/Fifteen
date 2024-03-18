using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FifteenGame
{
    public class NumberedCell : Cell
    {
        [SerializeField] TextMeshPro numberText;
        private int number;
        public int Number 
        { 
            get { return number; }
            private set { number = value; } 
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
    }
}