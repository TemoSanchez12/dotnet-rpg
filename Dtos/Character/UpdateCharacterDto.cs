﻿using dotnet_rpg.Models;

namespace dotnet_rpg.Dtos.Character;

public class UpdateCharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "Frodo";
    public int HitPoints { get; set; } = 10;
    public int Strength { get; set; } = 10;
    public int Defence { get; set; } = 10;
    public int Intelligense { get; set; } = 10;
    public RpgClass RpgClass { get; set; } = RpgClass.Knight;
}
