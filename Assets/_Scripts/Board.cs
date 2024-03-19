using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class Board : MonoBehaviour
    {
        [SerializeField] UIManager uiManager;
        public static Board Instance { get; private set; }

        private int width = 4;
        private int height = 4;
        private int cellOffset = 1;

        public Cell[,] cells;
        public Cell[] cellPrefabs;

        private Cell emptyCell;

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

            cells = new Cell[width, height];
        }

        private void Start()
        {
            CreateGrid();
            GameManager.Instance.CheckCellsInCorrectPosition();
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
                    
                    if (arrayOfNumbers[i] == 0)
                    {
                        emptyCell = newCell;
                        newCell.ChangeColor(Color.grey);
                    }
                    else
                    {
                        Cell numberedCell = newCell;
                        numberedCell.SetNumber(arrayOfNumbers[i]);
                    }

                    cells[x, y] = newCell;
                    newCell.SetStartPosition(new Vector2Int(x, y));
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

            return randomNumbers;
        }

        public void SwapCellsLeft() 
        {
            if (emptyCell.Position.x <= 0) return;
            
            Cell targetCell = cells[emptyCell.Position.x - 1, emptyCell.Position.y];
            Swap(targetCell);
        }

        public void SwapCellsUp()
        {
            if (emptyCell.Position.y <= 0) return;

            Cell targetCell = cells[emptyCell.Position.x, emptyCell.Position.y - 1];
            Swap(targetCell);
        }

        public void SwapCellsRight()
        {
            if (emptyCell.Position.x >= 3) return;

            Cell targetCell = cells[emptyCell.Position.x + 1, emptyCell.Position.y];
            Swap(targetCell);
        }

        public void SwapCellsDown() 
        {
            if (emptyCell.Position.y >= 3) return;

            Cell targetCell = cells[emptyCell.Position.x, emptyCell.Position.y + 1];
            Swap(targetCell);
        }

        private void Swap(Cell target)
        {
            Vector2Int targetPos = target.Position;
            Vector2Int emptyCellPos = emptyCell.Position;
            target.Position = emptyCellPos;
            emptyCell.Position = targetPos;


            Cell temp = cells[emptyCell.Position.x, emptyCell.Position.y];
            cells[emptyCell.Position.x, emptyCell.Position.y] = cells[target.Position.x, target.Position.y];
            cells[target.Position.x, target.Position.y] = temp;


            Vector2 targetTransformPos = target.transform.position;
            Vector2 emptyCellTransformPos = emptyCell.transform.position;
            target.transform.position = emptyCellTransformPos;
            emptyCell.transform.position = targetTransformPos;

            GameManager.Instance.CheckCellsInCorrectPosition();
            uiManager.StartTimer();
            uiManager.AddOneMoveToCounter();

            if (GameManager.Instance.IsGameWon())
            {
                uiManager.EndGame();
            }
        }

        public void ResetGrid()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Destroy(cells[x, y].gameObject);
                }
            }
        }
    }
}