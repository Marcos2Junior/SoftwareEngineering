
using MySql.Data.MySqlClient;
using SoftwareEngineering.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering.Business
{
    public class DAL
    {
        private string conectaBanco = "SERVER=localhost; database=appengsoftware; user id=root; Password=40xeyxqnv";
        protected MySqlConnection conexao = null;
        MySqlCommand comando = null;

        #region conexao
        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conectaBanco);
                conexao.Open();


            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void FecharConexao()
        {
            try
            {
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        #endregion

        public List<Sala> RetornaSalasDestaques()
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("SELECT * FROM sala order by dataInicio desc limit 9", conexao);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                List<Sala> salas = new List<Sala>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Sala sala = new Sala();
                    //Adiciona na lista Especificando a clouna 
                    sala.Id = int.Parse(dataRow["id"].ToString());
                    sala.Nome = dataRow["nome"].ToString();
                    sala.Senha = dataRow["senha"].ToString();
                    sala.QntJogadores = int.Parse(dataRow["qntJogadores"].ToString());
                    sala.Local = dataRow["local"].ToString();
                    sala.DataJogo = DateTime.Parse(dataRow["dataJogo"].ToString());
                    sala.DataInicio = DateTime.Parse(dataRow["dataInicio"].ToString());
                    sala.Categoria = dataRow["categoria"].ToString();
                    sala.Descricao = dataRow["descricao"].ToString();
                    sala.Usuario = dataRow["usuario"].ToString();
                    sala.Image = dataRow["image"].ToString();

                    salas.Add(sala);
                }

                return salas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        /// <summary>
        /// retorna todas as salas na qual o usuario é administrador
        /// </summary>
        /// <param name="usuario">nome da session</param>
        /// <returns></returns>
        public List<Sala> RetornaMinhaSala(string usuario)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("SELECT * FROM sala where usuario = @usuario limit 9", conexao);
                comando.Parameters.AddWithValue("@usuario", usuario);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                List<Sala> salas = new List<Sala>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Sala sala = new Sala();
                    //Adiciona na lista Especificando a clouna 
                    sala.Id = int.Parse(dataRow["id"].ToString());
                    sala.Nome = dataRow["nome"].ToString();
                    sala.Senha = dataRow["senha"].ToString();
                    sala.QntJogadores = int.Parse(dataRow["qntJogadores"].ToString());
                    sala.Local = dataRow["local"].ToString();
                    sala.DataJogo = DateTime.Parse(dataRow["dataJogo"].ToString());
                    sala.DataInicio = DateTime.Parse(dataRow["dataInicio"].ToString());
                    sala.Categoria = dataRow["categoria"].ToString();
                    sala.Descricao = dataRow["descricao"].ToString();
                    sala.Usuario = dataRow["usuario"].ToString();
                    sala.Image = dataRow["image"].ToString();

                    salas.Add(sala);
                }

                return salas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        /// <summary>
        /// Retorna todas as salas que o usuario está participando, menos as que ele é dono
        /// </summary>
        /// <param name="usuario">nome da session</param>
        /// <returns></returns>
        public List<Sala> RetornaSalaQueParticipo(string usuario)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("SELECT sala.id, sala.nome, sala.senha, sala.qntJogadores, sala.local, sala.dataJogo, sala.dataInicio, sala.categoria, sala.descricao, sala.usuario, sala.image FROM sala " +
                    " inner join usuarios_sala on sala.id = usuarios_sala.idSala" +
                    " where nomeUsuario = @usuario and sala.usuario != @usuario limit 9", conexao);
                comando.Parameters.AddWithValue("@usuario", usuario);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                List<Sala> salas = new List<Sala>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Sala sala = new Sala();
                    //Adiciona na lista Especificando a clouna 
                    sala.Id = int.Parse(dataRow["id"].ToString());
                    sala.Nome = dataRow["nome"].ToString();
                    sala.Senha = dataRow["senha"].ToString();
                    sala.QntJogadores = int.Parse(dataRow["qntJogadores"].ToString());
                    sala.Local = dataRow["local"].ToString();
                    sala.DataJogo = DateTime.Parse(dataRow["dataJogo"].ToString());
                    sala.DataInicio = DateTime.Parse(dataRow["dataInicio"].ToString());
                    sala.Categoria = dataRow["categoria"].ToString();
                    sala.Descricao = dataRow["descricao"].ToString();
                    sala.Usuario = dataRow["usuario"].ToString();
                    sala.Image = dataRow["image"].ToString();

                    salas.Add(sala);
                }

                return salas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void ExcluiUsuarioSala(int idSala, string usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM usuarios_sala WHERE  id > 0 and nomeUsuario = @usuario and idSala = @idSala", conexao);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@idSala", idSala);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }

        }

        public void ExcluirSala(int idSala)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM sala WHERE  id = @idSala ", conexao);
                comando.Parameters.AddWithValue("@idSala", idSala);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FecharConexao();
            }

        }
        #region cadastro de usuario

        public void GravarUsuario(Usuario usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO usuario (nome, senha, email, telefone, recebeNotificacao, image) values  (@nome, @senha, @email, @telefone, @recebeNotificacao, @image)", conexao);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
                comando.Parameters.AddWithValue("@recebeNotificacao", usuario.RecebeNotificacao);
                comando.Parameters.AddWithValue("@image", usuario.Image);
               

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        public int VerificaDados(Usuario usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT nome FROM usuario WHERE nome = @nome", conexao);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);

                MySqlDataReader dr = comando.ExecuteReader();

                comando = new MySqlCommand("SELECT nome FROM usuario WHERE email = @email", conexao);
                comando.Parameters.AddWithValue("@email", usuario.Email);

                MySqlDataReader dr1 = comando.ExecuteReader();

                int verifica = 0;
                if (dr.HasRows)
                    verifica = 1;
                if (dr1.HasRows)
                    verifica += 2;
                //valores retornados caso ja exista registros
                //1 = apenas nome
                //2 = apenas email
                //3 = nome e email
                //0 = não existe registro com nome ou email
                return verifica;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion

        #region cadastro de salas

        public int GravarSala(Sala sala)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO sala (nome, senha, qntJogadores, local, dataJogo, dataInicio, categoria, descricao, usuario, image) values  (@nome, @senha, @qntJogadores, @local, @dataJogo, @dataInicio, @categoria, @descricao, @usuario, @image)", conexao);
                comando.Parameters.AddWithValue("@nome", sala.Nome);
                comando.Parameters.AddWithValue("@senha", sala.Senha);
                comando.Parameters.AddWithValue("@qntJogadores", sala.QntJogadores);
                comando.Parameters.AddWithValue("@local", sala.Local);
                comando.Parameters.AddWithValue("@dataJogo", sala.DataJogo);
                comando.Parameters.AddWithValue("@dataInicio", sala.DataInicio);
                comando.Parameters.AddWithValue("@descricao", sala.Descricao);
                comando.Parameters.AddWithValue("@categoria", sala.Categoria);
                comando.Parameters.AddWithValue("@usuario", sala.Usuario);
                comando.Parameters.AddWithValue("@image", sala.Image);

                comando.ExecuteNonQuery();

                comando = new MySqlCommand("SELECT id FROM sala where nome = @nome", conexao);
                comando.Parameters.AddWithValue("@nome", sala.Nome);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);

                return int.Parse(dt.Rows[0]["id"].ToString());




            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion
        public bool VerificaLogin(Usuario usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * FROM usuario WHERE nome = @nome and senha = @senha", conexao);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                MySqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Close();
                    comando = new MySqlCommand("update usuario set ultimoLogin = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE nome = '" + usuario.Nome + "'", conexao);
                    comando.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        #region Mensagens da sala
        public void EnviaMsg(EnviaMsg msg)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO gravamensagem (mensagem, idUsuario, idSala, sequenciaMensagem, dataMensagem) values  (@mensagem, @idUsuario, @idSala, @sequenciaMensagem, @dataMensagem)", conexao);
                comando.Parameters.AddWithValue("@mensagem", msg.Mensagem);
                comando.Parameters.AddWithValue("@idUsuario", msg.IdUsuario);
                comando.Parameters.AddWithValue("@idSala", msg.IdSala);
                comando.Parameters.AddWithValue("@sequenciaMensagem", msg.sequencia);
                comando.Parameters.AddWithValue("@dataMensagem", msg.DataMensagem);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }
        //irá retornar sequencia da ultima mensagem enviada na sala
        public int verificaSequenciaMsg(int id)
        {
            int x;

            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT sequenciaMensagem FROM gravamensagem WHERE idSala = @idSala order by sequenciaMensagem desc limit 1", conexao);
                comando.Parameters.AddWithValue("@idSala", id);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);


                try
                {
                    x = int.Parse(dt.Rows[0]["sequenciaMensagem"].ToString()) + 1;
                }
                catch (Exception)
                {
                    x = 1;

                }



                return x;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        //retorna as mensagens ja enviadas na sala
        public List<EnviaMsg> MensagensSala(int idSala)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("SELECT * FROM gravamensagem where idSala = @idSala order by sequenciaMensagem", conexao);
                comando.Parameters.AddWithValue("@idSala", idSala);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                List<EnviaMsg> enviaMsgs = new List<EnviaMsg>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    EnviaMsg msg = new EnviaMsg();
                    //Adiciona na lista Especificando a clouna 
                    msg.Mensagem = dataRow["mensagem"].ToString();
                    msg.IdUsuario = dataRow["idUsuario"].ToString();
                    msg.IdSala = int.Parse(dataRow["idSala"].ToString());
                    msg.sequencia = int.Parse(dataRow["sequenciaMensagem"].ToString());
                    msg.DataMensagem = dataRow["dataMensagem"].ToString();

                    enviaMsgs.Add(msg);
                }

                return enviaMsgs;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        #endregion





        public Sala RetornaSala(int idSala)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("select * from sala where id = @idSala", conexao);
                comando.Parameters.AddWithValue("@idSala", idSala);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                Sala sala = new Sala();

                sala.Nome = dt.Rows[0]["nome"].ToString();
                sala.QntJogadores = int.Parse(dt.Rows[0]["qntJogadores"].ToString());
                sala.Local = dt.Rows[0]["local"].ToString();
                sala.DataInicio = DateTime.Parse(dt.Rows[0]["dataInicio"].ToString());
                sala.DataJogo = DateTime.Parse(dt.Rows[0]["dataJogo"].ToString());
                sala.Descricao = dt.Rows[0]["descricao"].ToString();
                sala.Usuario = dt.Rows[0]["usuario"].ToString();
                sala.Categoria = dt.Rows[0]["categoria"].ToString();
                sala.Image = dt.Rows[0]["image"].ToString();

                return sala;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }



        public List<string> UsuariosSala(int idSala)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("SELECT * FROM usuarios_sala where idSala = @idSala", conexao);
                comando.Parameters.AddWithValue("@idSala", idSala);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                List<string> usuarios = new List<string>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    usuarios.Add(dataRow["nomeUsuario"].ToString());
                }

                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void GravaUsuarioSala(string usuario, int idSala)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("SELECT * FROM usuarios_sala WHERE nomeUsuario = @nomeUsuario and idSala = @idSala", conexao);
                comando.Parameters.AddWithValue("@nomeUsuario", usuario);
                comando.Parameters.AddWithValue("@idSala", idSala);
                MySqlDataReader dr = comando.ExecuteReader();

                if (!dr.HasRows)
                {
                    dr.Close();
                    comando = new MySqlCommand("INSERT INTO usuarios_sala (nomeUsuario, idSala) values (@nomeUsuario, @idSala)", conexao);
                    comando.Parameters.AddWithValue("@nomeUsuario", usuario);
                    comando.Parameters.AddWithValue("@idSala", idSala);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        public Usuario RetornaUsuario(string usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("select * from usuario where nome = @nome", conexao);
                comando.Parameters.AddWithValue("@nome", usuario);
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                da.SelectCommand = comando;

                da.Fill(dt);
                Usuario user = new Usuario();

                user.Id = int.Parse(dt.Rows[0]["id"].ToString());
                user.Nome = dt.Rows[0]["nome"].ToString();
                user.Senha = dt.Rows[0]["senha"].ToString();
                //  user.RecebeNotificacao = bool.Parse(dt.Rows[0]["recebeNotificacao"].ToString());
                user.Telefone = dt.Rows[0]["telefone"].ToString();
                user.Email = dt.Rows[0]["email"].ToString();
                user.Image = dt.Rows[0]["image"].ToString();
                user.Sobre = dt.Rows[0]["sobre"].ToString();

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE usuario SET "
                + " nome = @nome, "
                + " senha = @senha, "
                + " email = @email, "
                + " telefone = @telefone, "
                + " image = @image, "
                + " sobre = @sobre "
                + "  WHERE id = @id; ", conexao);

                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
                comando.Parameters.AddWithValue("@image", usuario.Image);
                comando.Parameters.AddWithValue("@id", usuario.Id);
                comando.Parameters.AddWithValue("@sobre", usuario.Sobre);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
