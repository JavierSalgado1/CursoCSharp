using System.Data;
using System.Data.SqlClient;

namespace Video94
{
    class CapaDatos
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-AQDSLK4;Initial Catalog=CursoCSharp1;User ID=sa;Password=somela2005");

        public DataTable ListarPersonas()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT\r\n\tCONCAT(nombre, ' ', apPaterno, ' ', apMaterno) AS 'nombre', \r\n\tCONCAT(edad, '') AS 'edad', \r\n\tCASE sexo \r\n\tWHEN 0 THEN 'Mujer' \r\n\tWHEN 1 THEN 'Hombre' END AS 'sexo'\r\nFROM \r\n\tPersona", conexion);

            using (adaptador) { adaptador.Fill(dt); }

            return dt;
        }

        public DataTable ListarPersonasPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("SELECT\r\n\tCONCAT(nombre, ' ', apPaterno, ' ', apMaterno) AS 'nombre', \r\n\tCONCAT(edad, '') AS 'edad', \r\n\tCASE sexo \r\n\tWHEN 0 THEN 'Mujer' \r\n\tWHEN 1 THEN 'Hombre' END AS 'sexo'\r\nFROM\r\n\tPersona\r\nWHERE\r\n\tnombre LIKE @nombre", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            nombre = $"%{nombre}%";

            using (adaptador) 
            {
                comando.Parameters.AddWithValue("@nombre", nombre);
                adaptador.Fill(dt);
            }

            return dt;
        }

        public DataTable ListarPersonasPorRangoEdad(byte edadDesde, byte edadHasta)
        {
            DataTable dt = new DataTable();
            SqlCommand comando = new SqlCommand("SELECT\r\n\tCONCAT(nombre, ' ', apPaterno, ' ', apMaterno) AS 'nombre', \r\n\tCONCAT(edad, '') AS 'edad', \r\n\tCASE sexo \r\n\tWHEN 0 THEN 'Mujer' \r\n\tWHEN 1 THEN 'Hombre' END AS 'sexo'\r\nFROM\r\n\tPersona\r\nWHERE\r\n\tedad BETWEEN @edadDesde AND @edadHasta", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);

            using (adaptador)
            {
                comando.Parameters.AddWithValue("@edadDesde", edadDesde);
                comando.Parameters.AddWithValue("@edadHasta", edadHasta);
                adaptador.Fill(dt);
            }

            return dt;
        }
    }
}