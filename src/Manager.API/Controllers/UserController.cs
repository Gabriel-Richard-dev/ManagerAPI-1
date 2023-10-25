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
    public async Task<IActionResult> Create([FromBody]CreateUserViewModel userViewModel)
    {
      
            var userDTO = _mapper.Map<UserDTO>(userViewModel);
            var userCreated = await _userService.Create(userDTO);
            return Ok(new ResultViewModel{
                Message = "Usuário criado com sucesso",
                Sucess = true,
                Data = userCreated});
            
    }
}