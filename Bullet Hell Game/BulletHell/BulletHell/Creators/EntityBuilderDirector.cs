using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Creators
{
    public class EntityBuilderDirector : IDirector
    {
        private AbstractEntityBuilder builder;
        public EntityBuilderDirector(AbstractEntityBuilder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildAttackPattern();
            builder.BuildHealth();
            builder.BuildMovement();
            builder.BuildOrigin();
            builder.BuildScore();
            builder.BuildRenderer();
        }
    }
}
