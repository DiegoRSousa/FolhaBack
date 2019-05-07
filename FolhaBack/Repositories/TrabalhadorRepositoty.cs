using System.Collections.Generic;
using System.Linq;
using Dapper;
using FolhaBack.Models;
using Microsoft.Extensions.Configuration;

namespace FolhaBack.Repositories
{
    public class TrabalhadorRepository : Repository
    {
        public TrabalhadorRepository(IConfiguration configuration) : base(configuration) { }

        public IEnumerable<Trabalhador> Listar() 
        {
            using(var conn = GetConnection())
            {
                return conn.Query<Trabalhador>("SELECT id, nome, cpf, salario FROM trabalhadores");
            }
        }

        public Trabalhador PorId(long id)
        {
            using (var conn = GetConnection())
            {
                var query = "SELECT id, nome, cpf, salario FROM trabalhadores where id = @Id";
                return conn.Query<Trabalhador>(query, new { Id = id }).SingleOrDefault();
            }
        }


        public void Salvar(Trabalhador trabalhador)
        {
            using (var conn = GetConnection())
            {
                var query = "insert into trabalhadores (nome, cpf, salario) values (@Nome, @Cpf, @Salario)";
                conn.Query(query, trabalhador);
            }
        }

        public void Alterar(Trabalhador trabalhador)
        {
            using (var conn = GetConnection())
            {
                var query = "update trabalhadores set nome = @nome, cpf = @cpf, salario = @salario where id = @Id";
                conn.Query(query, trabalhador);
            }
        }

        public void Excluir(long id)
        {
            using (var conn = GetConnection())
            {
                var query = "delete from trabalhadores where id = @Id";
                conn.Query(query, new { Id = id });
            }
        }
    }
}