using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int Lifetime {get; set;}

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifetime)
            : base(topLeft, body)
        {
            this.Lifetime = lifetime;
        }

        public override void Update()
        {
            Lifetime--;
            if (Lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
