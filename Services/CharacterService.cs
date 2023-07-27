using dotnet_rpg.Models;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Services.Contracts;
using AutoMapper;

namespace dotnet_rpg.Services;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    private static List<Character> characters = new()
    {
        new Character{Id = 1},
        new Character{Name = "Tracer", Id = 2}
    };

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
    {
        var newCharacter = _mapper.Map<Character>(character);
        newCharacter.Id = characters.Max(x => x.Id) + 1;
        characters.Add(newCharacter);

        var response = new ServiceResponse<List<GetCharacterDto>>();
        response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        response.Success = true;
        response.Message = "OK";

        return response;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var response = new ServiceResponse<List<GetCharacterDto>>();
        response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        response.Success = true;
        response.Message = "OK";

        return response;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var response = new ServiceResponse<GetCharacterDto>();
        var character = characters.FirstOrDefault(c => c.Id == id);
        response.Data = _mapper.Map<GetCharacterDto>(character);
        response.Success = character is not null;
        response.Message = character is not null ? "Ok" : "Character Not Found";

        return response;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var response = new ServiceResponse<GetCharacterDto>();
        var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

        if (character is not null)
        {
            character.Name = updatedCharacter.Name;
            character.Strength = updatedCharacter.Strength;
            character.Defence = updatedCharacter.Defence;
            character.RpgClass = updatedCharacter.RpgClass;
            character.Intelligense = updatedCharacter.Intelligense;
            character.HitPoints = updatedCharacter.HitPoints;

            response.Data = _mapper.Map<GetCharacterDto>(character);
            response.Success = true;
            response.Message = "Ok";
        }
        else
        {
            response.Success = false;
            response.Message = "Character not found";
        }

        return response;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var response = new ServiceResponse<List<GetCharacterDto>>();

        var character = characters.FirstOrDefault(c => c.Id == id);

        if (character is not null)
        {
            characters.Remove(character);
            response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            response.Success = true;
            response.Message = "Character removed";
        }
        else
        {
            response.Success = false;
            response.Message = "Character not found";
        }

        return response;
    }
}
