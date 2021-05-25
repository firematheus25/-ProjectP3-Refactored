using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiP3.DATA
{
    public class P3Context : DbContext
    {

        public P3Context(DbContextOptions<P3Context> options) : base(options)
        {

                
        }

        public DbSet<Horista> Horista { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Comissionado> Comissionado { get; set; }
        public DbSet<Assalariado> Assalariado { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<TaxasServico> Taxas { get; set; }
        public DbSet<RegistroPonto> RegistroPontos { get; set; }
        public DbSet<Folha> Folhas { get; set; }
        public DbSet<Sindicato> Sindicato { get; set; }
        public DbSet<AgendaPagamento> AgendaPagamento { get; set; }
        public DbSet<FuncionarioSindical> FuncionarioSindical { get; set; }
        public DbSet<TaxasServico> TaxasServico { get; set; }
        public DbSet<FuncionarioVw> FuncionarioVw { get; set; }
    }
}
