using System;
namespace CarProject.Entities.Dtos.BoatDtos
{
    public class BoatUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }//Araç Adı
        public string Color { get; set; }//Renk
        public string Seat { get; set; }//Koltuk
    }
}

