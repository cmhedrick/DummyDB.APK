using SQLite;

namespace DummyDB
{
    class Dummy
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Persona { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0}, Name={1}, Persona={2}", ID, Name, Persona);
        }
    }
}