using UnityEngine;

namespace SpaceSurvival.Core
{
    public enum GameState { MainMenu, Exploration, Paused, GameOver }

    public class GameManager : Singleton<GameManager>
    {
        public GameState CurrentState { get; private set; }

        private void Start()
        {
            SetState(GameState.Exploration);
        }

        public void SetState(GameState newState)
        {
            CurrentState = newState;
            Debug.Log($"Game State Changed to: {newState}");
            
            // Handle state transitions
            switch (newState)
            {
                case GameState.Exploration:
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case GameState.Paused:
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
            }
        }

        public void QuitGame()
        {
            Debug.Log("Quitting Game...");
            Application.Quit();
        }
    }
}
