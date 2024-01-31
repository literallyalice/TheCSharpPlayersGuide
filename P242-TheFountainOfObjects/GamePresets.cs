namespace P242_TheFountainOfObjects;

public static class GamePresets
{
    public static Game GameSetup() {
        ConsoleHelper.WriteLine("The Fountain of Objects", ConsoleColor.DarkCyan);
        ConsoleHelper.WriteLine("Choose game size: (small, medium, large)", ConsoleColor.White);
        Game? game;
        
        do {
            ConsoleHelper.Write("> ", ConsoleColor.White);
            var input = Console.ReadLine();
            game = input switch
            {
                "small" => CreateGame(MapSize.Small),
                "medium" => CreateGame(MapSize.Medium),
                "large" => CreateGame(MapSize.Large),
                _ => null
            };
    
            if (game == null) {
                ConsoleHelper.WriteLine("That's not a valid size", ConsoleColor.White);
            }
            
    
        } while (game == null);

        return game;
    }

    private static Game CreateGame(MapSize mapSize) {
        Map map;
        Location start;
        
        switch (mapSize) {
            
            default:
            case MapSize.Small:
                // Map Size and location settings
                map = new Map(4, 4);
                start = new Location(0, 0);
                
                // Room placements
                map.SetRoomAtLocation(start, new EntranceRoom());
                map.SetRoomAtLocation(new Location(0, 2), new FountainRoom());
                map.SetRoomAtLocation(new Location(3, 3), new PitRoom());
                
                break;
            
            case MapSize.Medium:
                
                // Map Size and location settings
                map = new Map(6, 6);
                start = new Location(5, 0);
                
                // Room placements
                map.SetRoomAtLocation(start, new EntranceRoom());
                map.SetRoomAtLocation(new Location(2, 4), new FountainRoom());
                map.SetRoomAtLocation(new Location(2, 5), new PitRoom());
                map.SetRoomAtLocation(new Location(5, 3), new PitRoom());
                
                break;
            
            case MapSize.Large:
                
                // Map Size and location settings
                map = new Map(8, 8);
                start = new Location(3, 7);
                
                // Room placements
                map.SetRoomAtLocation(start, new EntranceRoom());
                map.SetRoomAtLocation(new Location(4, 2), new FountainRoom());
                map.SetRoomAtLocation(new Location(2, 5), new PitRoom());
                map.SetRoomAtLocation(new Location(0, 7), new PitRoom());
                map.SetRoomAtLocation(new Location(6, 3), new PitRoom());
                map.SetRoomAtLocation(new Location(2, 7), new PitRoom());

                break;
            
        }
        return new Game(map, new Player(start));
    }
}