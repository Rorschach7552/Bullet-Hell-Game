using BulletHell.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    public class GameState
    {
        private static readonly GameState instance = new();
        public static GameState Instance => instance;

        private bool pauseState = false;
        public bool PauseState 
        {   get => pauseState;
            set {
                if (value != pauseState)
                {
                    pauseState = value;

                    // pause
                    if (value == true)
                    {
                        gameRunning = false;
                    }
                    // unpause
                    else if (value == false)
                    {
                        gameRunning = true;
                    }
                }
            }
        }

        private bool gameRunning = false;
        public bool GameRunning { get => gameRunning; set => gameRunning = value; }

        private bool gameOver = false;
        public bool GameOver
        {
            get => gameOver;
            set
            {
                if (value != gameOver)
                {
                    gameOver = value;
                    // if game over game stops
                    if (value == true)
                    {
                        gameRunning = false;
                    }
                }
            }
        }

        private bool cheatMode = false;
        public bool CheatMode { get => cheatMode; set => cheatMode = value; }
        private GameState() { }
    }
}
