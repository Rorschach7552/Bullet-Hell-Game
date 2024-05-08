using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BulletHell
{
    public class ExitCommand
    {
        public static bool IsExit()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return true;
            }
            return false;
        }
    }
}
