using BulletHell.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.View
{
    public static class BackgroundRenderer
    {
        public static void Render(SpriteBatch spriteBatch, Background background)
        {
            spriteBatch.Draw(background.Texture, new Vector2(background.Viewport.X, background.Viewport.Y), background.Rectangle, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 1.0f);
        }
    }
}
