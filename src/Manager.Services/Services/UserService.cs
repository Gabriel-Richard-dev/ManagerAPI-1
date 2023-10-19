using Manager.Core.Exceptions;
using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services;

public class UserService : IUserService
{
    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    
    
    public async Task<UserDTO> Create(UserDTO userDTO)
    {
        var userExists = await _userRepository.GetByEmail(userDTO.Email);
        
        if (userExists is not null)
        { throw new DomainException("Já existe um usuário cadastrado com o email informado!"); }

        var user = _mapper.Map<User>(typeof(UserDTO));

        user.Validate();
        var userCreated = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDTO)
    {
        var userExists = await _userRepository.Get(userDTO.Id);
        
        if (userExists is null)
        { throw new DomainException("Não há como atualizar um user inexistente"); }

        var user = _mapper.Map<User>(typeof(UserDTO));
        user.Validate();

        var userUpdated = await _userRepository.Update(user);

        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task Remove(long id)
    {
        await _userRepository.Remove(id);
    }

    public async Task<UserDTO> Get(long id)
    {
        var user = await _userRepository.Get(id);

        if (user is null)
        {
            throw new DomainException("Usuário com esse id inexiste");
        }

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var allusers = await _userRepository.Get();

        return _mapper.Map<List<UserDTO>>(allusers);
        
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
        var userlist = await _userRepository.SearchByName(name);

        return _mapper.Map<List<UserDTO>>(userlist);

    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var userlist = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDTO>>(userlist);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        if (user is null)
        {
            throw new DomainException("Não existe usuário cadastrado com esse email");
        }
        return _mapper.Map<UserDTO>(user);
        

    }
}