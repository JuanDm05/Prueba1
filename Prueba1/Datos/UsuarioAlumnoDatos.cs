using Prueba1.Models;
using System.Data.SqlClient;
using System.Data;


namespace Prueba1.Datos
{
    public class UsuarioAlumnoDatos
    {
        public List<UsuarioAlumnoModel> Listar()
        {
            var oLista = new List<UsuarioAlumnoModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_MostrarUsuarioAlm", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new UsuarioAlumnoModel()
                        {
                            alumno = Convert.ToInt32(dr["IdContacto"]),
                            apellidoPaterno = dr["apellidoPaterno"].ToString(),
                            apellidoMaterno = dr["apellidoMaterno"].ToString(),
                            Grupo = Convert.ToInt32(dr["Grupo"]),
                            Carrera = dr["Carrera"].ToString(),
                            Cuatrimestre = Convert.ToInt32(dr["Cuatrimestre"]),
                            correo = dr["correo"].ToString()
                        });

                    }
                }
            }
            return oLista;

        }
        public bool CrearUsuarioAlm(UsuarioAlumnoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CrearUsuarioAlumno", conexion);
                    cmd.Parameters.AddWithValue("alumno", model.alumno);
                    cmd.Parameters.AddWithValue("apellidoPaterno", model.apellidoPaterno);
                    cmd.Parameters.AddWithValue("apellidoMaterno", model.apellidoMaterno);
                    cmd.Parameters.AddWithValue("Grupo", model.Grupo);
                    cmd.Parameters.AddWithValue("Carrera", model.Carrera);
                    cmd.Parameters.AddWithValue("Cuatrimestre", model.Cuatrimestre);
                    cmd.Parameters.AddWithValue("correo", model.correo);
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool EliminarUsuarioAlm(int Matricula)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Matricula", Matricula);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool EditarAlm(UsuarioAlumnoModel2 model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarUsuarioAlumno", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                    cmd.Parameters.AddWithValue("IdGrupo", model.IdGrupo);

                    cmd.Parameters.AddWithValue("Nombres", model.IdGrupo);
                    cmd.Parameters.AddWithValue("ApePat", model.ApePat);
                    cmd.Parameters.AddWithValue("ApeMat", model.ApeMat);
                    cmd.Parameters.AddWithValue("CURP", model.CURP);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("IdGrupo", model.IdGrupo);
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public UsuarioAlumnoModel ObtenerUsuario(int IdUsuario)
        {
            var oUsuario = new UsuarioAlumnoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_MostrarUsuarioAlm", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario.alumno = Convert.ToInt32(dr["alumno"]);
                        oUsuario.apellidoPaterno = dr["ApePat"].ToString();
                        oUsuario.apellidoMaterno = dr["ApeMat"].ToString();
                        oUsuario.Grupo = Convert.ToInt32(dr["Grupo"]);
                        oUsuario.Carrera = dr["Carrera"].ToString();
                        oUsuario.Cuatrimestre = Convert.ToInt32(dr["Cuatrimestre"]);
                        oUsuario.correo = dr["correo"].ToString();

                    }
                }
                
            }
            return oUsuario;    
        }

        internal bool EditarAlm(UsuarioAlumnoModel model)
        {
            throw new NotImplementedException();
        }
    }
}


