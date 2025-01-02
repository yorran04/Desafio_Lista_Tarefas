using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lista_de_tarefas.Context;
using Lista_de_tarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lista_de_tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TarefasControlles : ControllerBase
    {
      private readonly OrganizadorContext _context;

      public TarefasControlles(OrganizadorContext context)
      {
        _context = context;
      }   

      [HttpGet("{id}")]
      public IActionResult ObterPorId(int id){

        var tarefaId = _context.Tarefas.Find(id);
        if (tarefaId == null)
            return NotFound();

        return Ok(tarefaId);
      }


      [HttpGet("ObterTodos")]
      public IActionResult ObterTodos()
      {
        var todasTarefas = _context.Tarefas.ToList();
        return Ok(todasTarefas);
      }
  
      [HttpGet("ObterPorTitulo")]
      public IActionResult ObterPorTitulo(string titulo)
      {
        var tarefa = _context.Tarefas.Where(t => t.Titulo == titulo);
        return Ok (tarefa);
      }

      [HttpGet("ObterPorData")]
      public IActionResult ObterPorData(DateTime data)
      {
        var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
        return Ok(tarefa);
      }


      [HttpGet("ObterPorStatus")]
      public IActionResult ObterPorStatus(EnumStatusTarefa status)
      {
        var tarefa = _context.Tarefas.Where(x => x.Status == status);
        return Ok(tarefa);
      }


      [HttpPost]
      public IActionResult Create(Tarefa tarefa)
      {
         if(tarefa.Data == DateTime.MinValue)
            return BadRequest(new { Erro = "A data da tarefa não pode ser vazia"});

         _context.Add(tarefa);
         _context.SaveChanges();
         return Ok(tarefa);
      }


      [HttpDelete("{id}")]
      public IActionResult Deletar(int id)
      {
        var tarefa = _context.Tarefas.Find(id);

        if(tarefa == null)
        return NotFound();

        _context.Remove(tarefa);
        _context.SaveChanges();
        return NoContent();
      }
    }



    
}