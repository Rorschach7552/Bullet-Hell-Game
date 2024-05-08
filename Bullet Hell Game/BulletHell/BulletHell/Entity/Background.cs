using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Entity
{
    public class Background
    {
        private Texture2D texture;
        private Vector2 offset;
        private Vector2 speed;
        private Viewport viewport;
        public Rectangle Rectangle
        {
            get { return new Rectangle((int)Offset.X, (int)Offset.Y, Texture.Width, Texture.Height); }
        }

        public Texture2D Texture { get => texture; set => texture = value; }
        public Vector2 Offset
        {
            get => offset;
            set
            {
                if (value == offset)
                {
                    return;
                }
                else
                {
                    offset = value;
                }
            }
        }
        public Vector2 Speed { get => speed; set => speed = value; }
        public Viewport Viewport { get => viewport; set => viewport = value; }

        public Background(Texture2D texture, Vector2 speed)
        {
            this.texture = texture;
            this.speed = speed;
        }
    }
}
