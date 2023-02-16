for (int i = 1; i <= 100; i++) {
    var projectileType = "Normal";
    if (i % 3 == 0)
        projectileType = "Fire";
    if (i % 5 == 0)
        projectileType = "Electric";
    Console.WriteLine($"{i}. {projectileType}");
}