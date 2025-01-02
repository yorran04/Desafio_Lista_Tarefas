using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lista_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Lista_de_tarefas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; } 
    }
}