using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FifteenGame
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Button newGameButton;
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] TextMeshProUGUI movesCounterText;

        int movesCounter = 0;
        int UItimer = 0;
        float timer = 0;
        bool timerStarted = false;

        private void Start()
        {
            newGameButton.onClick.AddListener(OnNewGameButtonClick);
        }

        public void EndGame()
        {
            timerStarted = false;
        }

        private void OnNewGameButtonClick()
        {
            Board.Instance.ResetGrid();
            Board.Instance.CreateGrid();

            timer = 0;
            timerStarted = false;

            UItimer = 0;
            timerText.text = $"Timer: {UItimer}";
            movesCounter = 0;
            movesCounterText.text = $"Moves: {movesCounter}";
        }

        private void Update()
        {
            if (timerStarted)
            {
                if (timer >= 1)
                {
                    UItimer++;
                    timerText.text = $"Timer: {UItimer}";
                    timer = 0;
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        public void AddOneMoveToCounter()
        {
            movesCounter++;
            movesCounterText.text = $"Moves: {movesCounter}";
        }

        public void StartTimer()
        {
            timerStarted = true;
        }
    }
}