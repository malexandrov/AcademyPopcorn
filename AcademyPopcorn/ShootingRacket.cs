using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool hasBullets = false;
        private int bulletsCount = 6;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }
        
        public void Shoot()
        {
            this.hasBullets = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> shotBullets = new List<GameObject>();
            if (hasBullets && bulletsCount > 0)
            {
                shotBullets.Add(new Bullet(new MatrixCoords(this.topLeft.Row, this.topLeft.Col+ this.Width/2)));
                this.hasBullets = false;
                bulletsCount--;
            }

            return shotBullets;
        }
    }
}
