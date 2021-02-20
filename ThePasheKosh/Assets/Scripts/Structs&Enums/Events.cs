
public struct Events
{
    // Events related to touch screen
    public static string TouchCollider { get; } = "TouchCollider";
    public static string TouchScreen { get; } = "TouchScreen";
    public static string TouchGameObject { get; } = "TouchGameObject";
    
    
    // Game Over Event
    public static string GameOver { get; } = "GameOver";

    
    // Events related to destroying game objects
    public static string InsectKilled { get; } = "InsectKilled";
    public static string FoodDestruction { get; } = "FoodDestruction";

    
    // Events related to game sounds
    public static string BackgroundSound { get; } = "BackgroundSound";
    public static string InsectsSound { get; } = "InsectSound";

    
    // Events that will be triggered whenever a power up button is clicked
    public static string ElectricalPasheKosh { get; } = "ElectricalPasheKosh";
    public static string Fan { get; } = "Fan";
    public static string Pill { get; } = "Pill";
    public static string Spray { get; } = "Spray";
    
    // Events that will be triggered whenever a power up should activate
    public static string ElectricalPasheKoshTriggered { get; } = "ElectricalPasheKoshTriggered";
    public static string FanTriggered { get; } = "FanTriggered";
    public static string PillTriggered { get; } = "PillTriggered";
    public static string SprayTriggered { get; } = "SprayTriggered";


}
