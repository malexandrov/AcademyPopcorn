using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] {{'E'}};
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                List<GameObject> explosion = new List<GameObject>();

                explosion.Add(new ExplosionFragment
                    (this.topLeft + new MatrixCoords(-1, 0), new char[,] { { '&' } }, new MatrixCoords(-1, 0)));
                explosion.Add(new ExplosionFragment
                    (this.topLeft + new MatrixCoords(0, 1), new char[,] { { '&' } }, new MatrixCoords(0, 1)));
                explosion.Add(new ExplosionFragment
                    (this.topLeft + new MatrixCoords(1, 0), new char[,] { { '&' } }, new MatrixCoords(1, 0)));
                explosion.Add(new ExplosionFragment
                    (this.topLeft + new MatrixCoords(0, -1), new char[,] { { '&' } }, new MatrixCoords(0, -1)));

                return explosion;
            }
            else return base.ProduceObjects();
        }
    }
}
