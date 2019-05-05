using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    //Farklı tipte ya da farklı özelliklere sahip Rover lar olsaydı interface kullanımı daha iyi olabilirdi ama tek tip olduğu ve yetenekleri belli olduğu için direk class oluşturdum.
    public class Rover
    {
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public Orientations Orientation { get; set; }

        public Rover(int x,int y, Orientations orientation)
        {
            this.XLocation = x;
            this.YLocation = y;
            this.Orientation = orientation;
        }

        public void ProcessCommand(string commandSet)
        {
            foreach (var command in commandSet)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid command: {0}", command));
                }
            }
        }

        public void TurnLeft()
        {
            this.Orientation = (Orientation - 1) < Orientations.N ? Orientations.W : Orientation - 1;
        }

        public void TurnRight()
        {
            this.Orientation = (Orientation + 1) > Orientations.W ? Orientations.N : Orientation + 1;
        }

        public void Move()
        {
            if (Orientation == Orientations.N)
            {
                YLocation++;
            }
            else if (Orientation == Orientations.E)
            {
                XLocation++;
            }
            else if (Orientation == Orientations.S)
            {
                YLocation--;
            }
            else if (Orientation == Orientations.W)
            {
                XLocation--;
            }
        }
    }
}
