using System;
using Dapper;
using FolhaBack.Models;
using Microsoft.Extensions.Configuration;

namespace FolhaBack.Repositories
{
    public class SumarioRepository : Repository
    {
        public SumarioRepository(IConfiguration configuration) : base(configuration) { }

        public Sumario Get() 
        {
            var sumario = new Sumario();
            using(var conn = GetConnection()) 
            {
                sumario.QuantidadeTrabalhadores = conn.ExecuteScalar<int>("select count(*) from trabalhadores");
                sumario.TotalSalario = conn.ExecuteScalar<double>("select sum(salario) from trabalhadores");
            }

            return sumario;
        }
    }
}