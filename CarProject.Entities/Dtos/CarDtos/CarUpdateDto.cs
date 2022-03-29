using System;
namespace CarProject.Entities.Dtos.CarDtos
{
    public class CarUpdateDto
    {
        public int Id { get; set; }
        public int Wheels { get; set; }
        public string Headlights { get; set; }
        public string Name { get; set; }//Araç Adı
        public string Color { get; set; }//Renk
        public string Seat { get; set; }//Koltuk
    }
}

