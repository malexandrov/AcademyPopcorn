using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trail = new List<GameObject>();
            TrailObject trailObj = new TrailObject(this.topLeft, new char[,] {{'&'}}, 3);
            trail.Add(trailObj);

            return trail;
        }
    }
}
