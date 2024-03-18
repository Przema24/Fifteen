using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class Board : MonoBehaviour
    {
        private int width = 4;
        private int height = 4;
        private int cellOffset = 1;

        public Cell[,] cells;
        public Cell[] cellPrefabs;

        private void Awake()
        {
            cells = new Cell[width, height];
        }

        private void Start()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            int i = 0;
            int[] arrayOfNumbers = CreateRandomArrayOfNumbers();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Cell newCell = Instantiate(cellPrefabs[arrayOfNumbers[i]], new Vector3(transform.position.x + x * cellOffset, transform.position.y + -y * cellOffset, 0), Quaternion.identity);
                    
                    if (newCell is NumberedCell)
                    {
                        NumberedCell numberedCell = (NumberedCell)newCell;
                        numberedCell.SetNumber(arrayOfNumbers[i]);
                    }

                    cells[x, y] = newCell;
                    newCell.transform.SetParent(transform);
                    i++;
                }
            }
        }

        private int[] CreateRandomArrayOfNumbers()
        {
            int[] randomNumbers = new int[16];
            List<int> numbersToUse = new List<int>();

            for (int i = 0; i < 16; i++)
            {
                numbersToUse.Add(i);
            }

            for (int i = 0; i < 16; i++)
            {
                int index = Random.Range(0, numbersToUse.Count);
                randomNumbers[i] = numbersToUse[index];
                numbersToUse.RemoveAt(index);
            }

            foreach (int n in randomNumbers)
            {
                Debug.Log(n);
            }

            return randomNumbers;
        }
    }
}