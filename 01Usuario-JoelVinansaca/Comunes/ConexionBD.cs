using _01Usuario_JoelVinansaca.Modelos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _01Usuarios___RobertoOyola.Comunes
{
    public static class ConexionBD
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("Server=DESKTOP-0EV0SR4\\SQLEXPRESS;Database=PROYECTO_1;Trusted_Connection=True;");
            conexion.Open();
            return conexion;
        }

        public static List<Usuario> GetUsuarios()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_USUARIO";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillUsuarios(ds);

        }

        private static List<Usuario> fillUsuarios(DataSet ds)
        {
            List<Usuario> lrespuesta = new List<Usuario>();
            Usuario objUsuario = new Usuario();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                objUsuario = new Usuario();
                objUsuario.id_usuario = Convert.ToInt32(ds.Tables[0].Rows[i]["ID_USUARIO"].ToString());
                objUsuario.codigo = ds.Tables[0].Rows[i]["CODIGO"].ToString();
                objUsuario.nombres = ds.Tables[0].Rows[i]["NOMBRES"].ToString();
                objUsuario.apellidos = ds.Tables[0].Rows[i]["APELLIDOS"].ToString();
                objUsuario.mail = ds.Tables[0].Rows[i]["MAIL"].ToString();
                objUsuario.fecha_nacimiento = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_NACIMIENTO"].ToString());
                objUsuario.contrasena = ds.Tables[0].Rows[i]["CONTRASENA"].ToString();
                objUsuario.estado = ds.Tables[0].Rows[i]["ESTADO"].ToString();
                objUsuario.fecha_ultima_conexion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_ULTIMA_CONEXION"].ToString());
                objUsuario.usuario_creacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_CREACION"].ToString());
                objUsuario.fecha_creacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_CREACION"].ToString());
                objUsuario.usuario_modificacion = Convert.ToInt32(ds.Tables[0].Rows[i]["USUARIO_MODIFICACION"].ToString());
                objUsuario.fecha_modificacion = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_MODIFICACION"].ToString());
                lrespuesta.Add(objUsuario);
            }
            return lrespuesta;
        }
    }
}
