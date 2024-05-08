using BulletHell.Controllers;

namespace BulletHell.Commands
{
    public class UpdatePlayerInvulnerable : ICommand
    {
        private int duration = 120;
        private int counter;

        public UpdatePlayerInvulnerable()
        {
            this.counter = 0;
        }
        public void Execute()
        {
            if (PlayerController.Instance.Player.Invulnerable == true)
            {
                counter++;

                if (counter == duration)
                {
                    counter = 0;
                    PlayerController.Instance.Player.Invulnerable = false;
                }
            }
        }
    }
}
