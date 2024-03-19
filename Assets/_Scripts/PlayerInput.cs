using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class PlayerInput : MonoBehaviour
    {
        
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(); 
            }
        }

        private void MoveLeft()
        {
            Board.Instance.SwapCellsLeft();
        }

        private void MoveDown()
        {
            Board.Instance.SwapCellsDown();
        }
        private void MoveRight()
        {
            Board.Instance.SwapCellsRight();
        }
        private void MoveUp()
        {
            Board.Instance.SwapCellsUp();
        }
    }
}