using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FifteenGame
{
    public class PlayerInput : MonoBehaviour
    {
        private void Update()
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
            else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
            }
        }

        private void MoveLeft()
        {

        }

        private void MoveDown()
        {

        }
        private void MoveRight()
        {

        }
        private void MoveUp()
        {

        }
    }
}