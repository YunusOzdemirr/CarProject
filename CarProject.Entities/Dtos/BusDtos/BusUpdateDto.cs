using System;
namespace CarProject.Entities.Dtos.BusDtos
{
    public class BusUpdateDto
    {
        public string Wheels { get; set; }
        public string Headlights { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Seat { get; set; }
    }
}

