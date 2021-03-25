using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.Sql;

namespace frutasyverduras.Models
{
    public class mantenimientousuario
    {
        private SqlConnection con;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }
        public int Alta(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into landingpage(nombre, celular, email, ciudad,fecharegistro) values(@nombre, @celular, @email, @ciudad, @fecharegistro)", con);


            
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);

            comando.Parameters["@nombre"].Value = usu.nombre;
            comando.Parameters["@celular"].Value = usu.celular;
            comando.Parameters["@email"].Value = usu.email;
            comando.Parameters["@ciudad"].Value = usu.ciudad;
            comando.Parameters["@fecharegistro"].Value = usu.fecharegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;

        }

        public List<usuario> RecuperarTodos()
        {
            Conectar();
            List<usuario> usuario = new List<usuario>();

            SqlCommand com = new SqlCommand("select nombre, celular, email, ciudad, fecharegistro from landingpage", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {


                usuario usu = new usuario
                {
                    
                    nombre = registros["nombre"].ToString(),
                    celular = registros["celular"].ToString(),
                    email = registros["email"].ToString(),
                    ciudad = registros["ciudad"].ToString(),
                    fecharegistro = registros["fecharegistro"].ToString(),
                };

                usuario.Add(usu);

            }
            con.Close();
            return usuario;
        }



        public usuario Recuperar(string nombre)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select nombre, celular, email, ciudad, fecharegistro from landingpage where nombre = @nombre", con);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = nombre;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            usuario usuario = new usuario();

            if (registros.Read())
            {
                usuario.nombre = registros["nombre"].ToString();
                usuario.celular = registros["celular"].ToString();
                usuario.email = registros["email"].ToString(); 
                usuario.ciudad = registros["ciudad"].ToString();
                usuario.fecharegistro = registros["fecharegistro"].ToString();
            }
            con.Close();
            return usuario;
        }

        public int Modificar(usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update landingpage set nombre=@nombre, celular=@celular, email=@email, ciudad=@ciudad, fecharegistro=@fecharegistro where nombre=@nombre", con);

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.email;


            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.ciudad;


            comando.Parameters.Add("@fecharegistro", SqlDbType.VarChar);
            comando.Parameters["@fecharegistro"].Value = usu.fecharegistro;


            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int Borrar(string nombre)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from landingpage where nombre=@nombre", con);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = nombre;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
