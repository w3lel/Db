using CyberAge.Domain.Services.Companies;
using CyberAge.Domain.Services.prog;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberAge.API.Controllers
{
/// <summary>
/// Контроллер компаний
/// </summary>
//[Authorize("Bearer")]
[Route("Project")]
[AllowAnonymous]
public class ProgrammaController : Controller
{
    private readonly ProgrammaService _programmaService;

    public ProgrammaController(ProgrammaService programmaService)
    {
        _programmaService = programmaService;
    }


    /// <summary>
    /// Получение компании
    /// </summary>
    [HttpGet]
    [Route("Project id")]
    public async Task<Programma> GetProgrammas([FromQuery] Guid id)
    {
        return _programmaService.GetProgramma(id);
    }

    /// <summary>
    /// Получение компаний
    /// </summary>
    //[HttpGet]
    //public async Task<List<Programma>> GetProgrammas()
    //{
    //    return _programmaService.GetProgramma();
    //}

    /// <summary>
    /// Добавлени компании
    /// </summary>
    [HttpPost]
    public async Task AddProgrammas([FromBody]Programma programma)
    {
       _programmaService.AddProgramma(programma);
    }

    /// <summary>
    /// Изменение компании
    /// </summary>
    [HttpPatch]
    public async Task EditProgrammas([FromBody]Programma programma)
    {
       _programmaService.EditProgramma(programma);
    }

    /// <summary>
    /// Удаление компании
    /// </summary>
    [HttpDelete]
    public async Task RemoveProgrammas([FromQuery] Guid id)
    {
        _programmaService.RemoveProgramma(id);
    }
}
}