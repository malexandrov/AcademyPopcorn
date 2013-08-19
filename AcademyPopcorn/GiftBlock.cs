using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { {'$'} };
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (IsDestroyed)
            {
                List<GameObject> gift = new List<GameObject>();
                gift.Add(new Gift(this.topLeft));
                return gift;
            }
            return base.ProduceObjects();
        }
    }
}
