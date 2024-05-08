using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BulletHell.Controllers;

namespace BulletHell.Commands
{
    public class PauseCommand : ICommand
    {
        GameState instance = GameState.Instance;
        private int count = 0;
        public void Execute()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(PlayerController.Instance.Config.Pause) && count == 10)
            {
                if (instance.PauseState == true)
                {
                    Debug.WriteLine("unpaused");
                    instance.PauseState = false;
                }
                else
                {
                    Debug.WriteLine("pause");
                    instance.PauseState = true;
                }

                count = 0;
            }

            if (count < 10)
            {
                count++;
            }
        }
    }
}
