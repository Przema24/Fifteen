using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Dictionary<int, Vector2> correctPositions;
        public static GameManager Instance { get; private set; }

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

            correctPositions = new Dictionary<int, Vector2>();
            SetDictionaryValues();
        }

        private void SetDictionaryValues()
        {
            correctPositions[1] = new Vector2(0, 0);
            correctPositions[2] = new Vector2(1, 0);
            correctPositions[3] = new Vector2(2, 0);
            correctPositions[4] = new Vector2(3, 0);

            correctPositions[5] = new Vector2(0, 1);
            correctPositions[6] = new Vector2(1, 1);
            correctPositions[7] = new Vector2(2, 1);
            correctPositions[8] = new Vector2(3, 1);

            correctPositions[9] = new Vector2(0, 2);
            correctPositions[10] = new Vector2(1, 2);
            correctPositions[11] = new Vector2(2, 2);
            correctPositions[12] = new Vector2(3, 2);

            correctPositions[13] = new Vector2(0, 3);
            correctPositions[14] = new Vector2(1, 3);
            correctPositions[15] = new Vector2(2, 3);

            correctPositions[0] = new Vector2(3, 3);
        }

        public void CheckCellsInCorrectPosition()
        {
            foreach (Cell cellToCheck in Board.Instance.cells)
            {
                if (IsCellInCorrectPosition(cellToCheck.Number, cellToCheck.Position))
                {
                    cellToCheck.ChangeColor(Color.yellow);
                }
                else
                {
                    if (cellToCheck.Number == 0)
                    {
                        cellToCheck.ChangeColor(Color.grey);
                    }
                    else
                    {
                        cellToCheck.ChangeColor(Color.white);
                    }
                }
            }     
        }

        private bool IsCellInCorrectPosition(int number, Vector2 position)
        {
            if (correctPositions[number] == position)
            {
                return true;
            }
            return false;
        }
    }
}

                

            
        



