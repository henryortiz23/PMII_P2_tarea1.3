using SQLite;

namespace Ejercicio_1._3.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(50)]
        public string nombres { get; set; }

        [MaxLength(50)]
        public string apellidos { get; set; }

        [MaxLength(3)]
        public int edad { get; set; }

        [MaxLength(50)]
        public string correo { get; set; }

        [MaxLength(100)]
        public string direccion { get; set; }

    }
}
