using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FifteenGame
{
    public class EmptyCell : Cell
    {
        public static EmptyCell Instance { get; private set; }

        private void Awake()
        {

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }


    }
}