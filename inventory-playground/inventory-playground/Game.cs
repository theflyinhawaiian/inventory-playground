namespace InventoryPlayground
{
    public class Game
    {
        static void Main(string[] _)
        {
            var userInput = string.Empty;

            var rooms = new List<int> { 1, 2, 3, 4, 5 };
            var adjacencyMatrix = new List<List<int>> { new() { 2, 3, 4, 5 }, new() { 1 }, new() { 1 }, new() { 1 }, new() { 1 }};

            var currentRoom = rooms[0];

            var connectedRooms = string.Join(", ", adjacencyMatrix[currentRoom - 1]);

            Console.WriteLine($"You are in room {currentRoom}. Connected are rooms {connectedRooms}.");

            while (!userInput.Equals("quit")) {
                Console.WriteLine("Enter an action, or type \"help\" for a list of options: ");
                userInput = Console.ReadLine() ?? string.Empty;
                Console.Clear();

                var args = userInput.Split(" ");

                switch (args[0].ToLower()) {
                    case "help":
                        Console.WriteLine("goto <room-number>: navigate to the specified room number");
                        Console.WriteLine("whereami: display current whereabouts and related info");
                        Console.WriteLine("quit: dip the fuqq out");
                        break;
                    case "goto":
                        var roomNum = int.Parse(args[1]);
                        if (adjacencyMatrix[currentRoom - 1].Contains(roomNum)){
                            currentRoom = roomNum;
                            connectedRooms = string.Join(", ", adjacencyMatrix[currentRoom - 1]);
                            Console.WriteLine($"You are now in room {currentRoom}. Connected rooms are {connectedRooms}");
                            continue;
                        }

                        Console.WriteLine($"{roomNum} is not connected to this room. Connected rooms are {connectedRooms}");
                        break;
                    case "whereami":
                        Console.WriteLine($"You are in room {currentRoom}. Connected are rooms {connectedRooms}.");
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Type \"help\" for a list of options: ");
                        break;
                }
            }
        }
    }
}
