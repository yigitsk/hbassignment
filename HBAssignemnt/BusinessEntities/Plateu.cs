using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBAssignemnt.Models
{
    public class Plateu
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        //Plateu daki roverların bilgisi, ileride crash saptama vb. durumlarda kullanılabilir. Speclerde yazmadığı için implemente etmedim.
        public List<Rover> Rovers { get; set; }
        public int[,] Map { get; private set; }

        public Plateu(int sizeX,int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Rovers = new List<Rover>();
            CreateMap();
        }

        private void CreateMap()
        {
            this.Map = new int[this.SizeX, this.SizeY];
        }

        public void DeployRover(Rover rover)
        {
            Rovers.Add(rover);
            if(rover.XLocation>this.SizeX)
                throw new System.InvalidOperationException("Cannot Deploy Rover to outside of plateu!");
            if (rover.YLocation > this.SizeY)
                throw new System.InvalidOperationException("Cannot Deploy Rover to outside of plateu!");
            if (this.Map[rover.XLocation, rover.YLocation] == 0)
                this.Map[rover.XLocation, rover.YLocation] = 1;
            else
                throw new System.InvalidOperationException("Cannot Deploy Rover on Another Rover!");
        }

        //Bu fonksiyon roverların plateudaki yerini takip etmek için ya da harita dışına çıkmalarını vb. durumları takip için oluşturdum. Assignment ta olmadığı için kapattım. Zaten
        //tam çalışmıyor büyük ihtimal :D
        public void UpdateMap()
        {
           foreach(var rover in Rovers)
           {
                if (rover.XLocation > this.SizeX)
                    throw new System.InvalidOperationException("Rover is out of the Map");
                if (rover.YLocation > this.SizeY)
                    throw new System.InvalidOperationException("Rover is out of the Map");
                if (this.Map[rover.XLocation, rover.YLocation] == 0)
                    this.Map[rover.XLocation, rover.YLocation] = 1;
                else
                {
                    throw new System.ApplicationException("Rovers Crashed!");
                }
            }
        }
    }
}
