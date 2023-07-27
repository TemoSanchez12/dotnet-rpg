namespace dotnet_rpg.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = "Frodo";
    public int HitPoints { get; set; } = 10;
    public int Strength { get; set; } = 10;
    public int Defence { get; set; } = 10;
    public int Intelligense { get; set; } = 10;
    public RpgClass RpgClass { get; set; } = RpgClass.Knight;
}
