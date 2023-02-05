using MySql.Data.MySqlClient;
using System;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace LivrariaApp.Models
{


    //Esta classe vai tratar de comunicar com a base de dados. * Executa queries SQL e mapeia nas outras classes criadas no Model. *
    public class LivrariaContext
    {
       
        private string ConnectionString { get; set; }
        public LivrariaContext()
        {
            ConnectionString = "server=localhost;port=3306;database=Livraria;user=root";
        }



        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Idioma> getAllIdioma()
        {
            //Lista para guardar todos os idiomas existentes na base de dados
            List<Idioma> lista = new List<Idioma>();
            using (MySqlConnection conn = GetConnection())
            {
                //Abrimos uma coneção com a base de dados

                conn.Open();

                //Criamos uma query onde vamos pedir todos os idiomas

                MySqlCommand query = new MySqlCommand("SELECT * FROM Idioma",conn);

                //Percorrer um a um resultado da query (pesquisa).
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Mapear os dados que vêm da base de dados com os da classe                    
                        //Atenção que os nomes têm que ser iguais aos da tabela na base de dados
                        lista.Add(new Idioma()
                        {
                            Id = reader.GetInt32("id_idioma"),
                        Nome = reader.GetString("nome"),
                        Sigla = reader.GetString("sigla"),
                    });
                        Console.WriteLine(reader.GetString("nome"));
                    }
                }
                return lista;
            }
        }






        //Actualiza na tabela Idioma um idioma existente
        public void updateIdioma(Idioma idioma)
        {
            using (MySqlConnection conn = GetConnection())
            {
                //Abrimos uma coneção com a base de dados
                conn.Open();

                //Criamos uma query de update 
                MySqlCommand query = new MySqlCommand("UPDATE Idioma SET nome=@nome , sigla=@sigla WHERE id_idioma=@id", conn);

                //Para evitar o SQL Injection usamos o mecanismo AddWithValue em vez de colocarmos directamente na string da Query
                query.Parameters.AddWithValue("@nome", idioma.Nome);
                query.Parameters.AddWithValue("@id", idioma.Id);
                query.Parameters.AddWithValue("@sigla", idioma.Sigla);

                //Como as queries de update não devolvem dados usamos o execute non query em vez do Reader como no exemplo ListAll
                query.ExecuteNonQuery();

                //Fechamos a ligação com a base de dados
                conn.Close();
            }
        }













        public List<Continente> getAllContinente()
        {
            //Lista para guardar todos os continentes existentes na base de dados
            List<Continente> lista = new List<Continente>();
            using (MySqlConnection conn = GetConnection())
            {
                //Abrimos uma coneção com a base de dados

                conn.Open();

                //Criamos uma query onde vamos pedir todos os continentes

                MySqlCommand query = new MySqlCommand("SELECT * FROM Continente", conn);

                //Percorrer um a um resultado da query (pesquisa).
                using (MySqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Mapear os dados que vêm da base de dados com os da classe                    
                        //Atenção que os nomes têm que ser iguais aos da tabela na base de dados
                        lista.Add(new Continente()
                        {
                            Id = reader.GetInt32("id_Continente"),
                            Nome = reader.GetString("nome"),
                         
                        });
                        Console.WriteLine(reader.GetString("nome"));
                    }
                }
                return lista;
            }
        }




        //Actualiza na tabela Continente um Continente existente
        public void updateContinente(Continente continente)
        {
            using (MySqlConnection conn = GetConnection())
            {
                //Abrimos uma coneção com a base de dados
                conn.Open();

                //Criamos uma query de update 
                MySqlCommand query = new MySqlCommand("UPDATE Continente SET nome=@nome WHERE id_continente=@id", conn);

                //Para evitar o SQL Injection usamos o mecanismo AddWithValue em vez de colocarmos directamente na string da Query
                query.Parameters.AddWithValue("@nome", continente.Nome);
                query.Parameters.AddWithValue("@id", continente.Id);
               

                //Como as queries de update não devolvem dados usamos o execute non query em vez do Reader como no exemplo ListAll
                query.ExecuteNonQuery();

                //Fechamos a ligação com a base de dados
                conn.Close();
            }
        }








    }
}






