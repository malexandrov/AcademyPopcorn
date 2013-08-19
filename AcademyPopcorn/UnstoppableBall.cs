using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
       public new const string CollisionGroupString = "unstoppableBall";

       public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { '0' } };
        }

       public override string GetCollisionGroupString()
       {
           return UnstoppableBall.CollisionGroupString;
       }

       public override bool CanCollideWith(string otherCollisionGroupString)
       {
           return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassableBlock"
                  || otherCollisionGroupString == "block" || otherCollisionGroupString == "indestructibleBlock";
       }

       public override void RespondToCollision(CollisionData collisionData)
       {
           if (collisionData.hitObjectsCollisionGroupStrings.Contains("racket") 
               || collisionData.hitObjectsCollisionGroupStrings.Contains("unpassableBlock")
               || collisionData.hitObjectsCollisionGroupStrings.Contains("indestructibleBlock"))
          
           {
               if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
               {
                   this.Speed.Row *= -1;
               }

               if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
               {
                   this.Speed.Col *= -1;
               }
           }

       }
    }
}
