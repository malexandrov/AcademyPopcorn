using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplosionFragment : MovingObject
    {
        private int lifeTime = 1;

        public ExplosionFragment(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
            : base(topLeft, body, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            if (lifeTime <= 0)
            {
                this.IsDestroyed = true;
            }
            lifeTime--;
        }
    }
}
