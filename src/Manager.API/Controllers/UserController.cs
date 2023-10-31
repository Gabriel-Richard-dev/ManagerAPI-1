using AutoMapper;
using Manager.API.Utillities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    [HttpPost]
    [Route("api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
    {
        var userDTO = _mapper.Map<UserDTO>(userViewModel);
        var userCreated = await _userService.Create(userDTO);
        return Ok(new ResultViewModel
        {
            Message = "Usuário criado com sucesso",
            Sucess = true,
            Data = userCreated
        });
    }

    [HttpPut]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateUserViewModel userViewModel)
    {
        
        var userDTO = _mapper.Map<UserDTO>(userViewModel);
        userDTO.Id = id;
        var userUpdated = await _userService.Update(userDTO);

        return Ok(new ResultViewModel
        {
            Message = "Usuário atualizado com sucesso!",
            Sucess = true,
            Data = userUpdated
        });
    }

    [HttpDelete]
    [Route("/api/v1/users/remove/{id}")]
    public async Task<IActionResult> Remove(long id)
    {
        await _userService.Remove(id);

        return Ok(new ResultViewModel
        {
            Message = "Usuário removido com sucesso!",
            Sucess = true,
            Data = null
        });
    }

    [HttpGet]
    [Route("/api/v1/users/get/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var user = await _userService.Get(id);

        if (user == null)
            return Ok(new ResultViewModel
            {
                Message = "Nenhum usuário foi encontrado com o ID informado.",
                Sucess = true,
                Data = user
            });

        return Ok(new ResultViewModel
        {
            Message = "Usuário encontrado com sucesso!",
            Sucess = true,
            Data = user
        });
    }


    [HttpGet]
    [Route("/api/v1/users/get-all")]
    public async Task<IActionResult> Get()
    {
        var allUsers = await _userService.Get();

        return Ok(new ResultViewModel
        {
            Message = "Usuários encontrados com sucesso!",
            Sucess = true,
            Data = allUsers
        });
    }


    [HttpGet]
    [Route("/api/v1/users/get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var user = await _userService.GetByEmail(email);

        if (user is not null)
            return Ok(new ResultViewModel
            {
                Message = "Email encontrado!",
                Sucess = true,
                Data = user
            });

        return Ok(new ResultViewModel
        {
            Message = "Usuário encontrado com sucesso!",
            Sucess = true,
            Data = user
        });
    }

    [HttpGet]
    [Route("/api/v1/users/search-by-name")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        var allUsers = await _userService.SearchByName(name);

        if (allUsers is null)
            return Ok(new ResultViewModel
            {
                Message = "Nenhum usuário foi encontrado com o nome informado",
                Sucess = true,
                Data = null
            });

        return Ok(new ResultViewModel
        {
            Message = "Usuário encontrado com sucesso!",
            Sucess = true,
            Data = allUsers
        });
    }


    [HttpGet]
    [Route("/api/v1/users/search-by-email")]
    public async Task<IActionResult> SearchByEmail([FromQuery] string email)
    {
        var allUsers = await _userService.SearchByEmail(email);

        if (allUsers is null)
            return Ok(new ResultViewModel
            {
                Message = "Nenhum usuário foi encontrado com o email informado",
                Sucess = true,
                Data = null
            });

        return Ok(new ResultViewModel
        {
            Message = "Usuário encontrado com sucesso!",
            Sucess = true,
            Data = allUsers
        });
    }
}