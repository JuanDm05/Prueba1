using Prueba1.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace Prueba1.Datos
{
    public class AlumnoDatos
    {
        public List<AlumnoModel> Listar()
        {
            var oLista = new List<AlumnoModel>();

            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("sp_ObtenerAlumnoPorMatricula", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new AlumnoModel()
                        {
                            Matricula = Convert.ToInt32(dr["IdContacto"]),
                            Nombres = dr["Nombre"].ToString(),
                            ApePat = dr["Nombre"].ToString(),
                            ApeMat = dr["Nombre"].ToString(),
                            CURP = dr["Nombre"].ToString(),
                            Telefono = dr["Nombre"].ToString(),
                            IdGrupo1 = Convert.ToInt32(dr["IdContacto"]),

                        });

                    }

                }


            }
            return oLista;
        }
        public AlumnoModel ObtenerAlumno(int Matricula)
        {
            var oAlumno = new AlumnoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("Matricula", Matricula);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oAlumno.Matricula = Convert.ToInt32(dr["Matricula"]);
                        oAlumno.Nombres = dr["Nombre"].ToString();
                        oAlumno.ApePat = dr["ApePat"].ToString();
                        oAlumno.ApeMat = dr["ApeMat"].ToString();
                        oAlumno.CURP = dr["CURP"].ToString();
                        oAlumno.Telefono = dr["Telefono"].ToString();
                        oAlumno.IdGrupo1 = Convert.ToInt32(dr["IdGrupo1"]);

                    }
                }


            }
            return oAlumno;
        }
        public bool GuardarAlumno(AlumnoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarAlumno", conexion);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("Nombres", model.Nombres);
                    cmd.Parameters.AddWithValue("ApePat", model.ApePat);
                    cmd.Parameters.AddWithValue("ApeMat", model.ApeMat);
                    cmd.Parameters.AddWithValue("CURP", model.CURP);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("IdGrupo1", model.IdGrupo1);
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
        public bool EditarAlumno(AlumnoModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarAlm", conexion);
                    cmd.Parameters.AddWithValue("Matricula", model.Matricula);
                    cmd.Parameters.AddWithValue("Nombres", model.Nombres);
                    cmd.Parameters.AddWithValue("ApePat", model.ApePat);
                    cmd.Parameters.AddWithValue("ApeMat", model.ApeMat);
                    cmd.Parameters.AddWithValue("CURP", model.CURP);
                    cmd.Parameters.AddWithValue("Telefono", model.Telefono);
                    cmd.Parameters.AddWithValue("IdGrupo1", model.IdGrupo1);
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
        public bool EliminarAlumno(int Matricula)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAlumno", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch(Exception e) 
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}

