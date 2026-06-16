//using Microsoft.Data.SqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Text;

//namespace LoginSystem.DAL
//{
//    public class UserDAL
//    {
//        public void Excluir(int codigo)
//        {
//            try
//            {
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = cn;
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.CommandText = "exclui_cliente";
//                //Parâmetros de SP
//                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
//                pcodigo.Value = codigo;
//                cmd.Parameters.Add(pcodigo);
//                cn.Open();
//                cmd.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Erro ao abrir conexão com o banco de dados. " + ex.Message);
//            }
//            catch
//            {
//                throw new Exception("Errro descohecido ao acessar banco de dados");
//            }
//            finally
//            {
//                cn.Close();
//            }
//        }
//}
