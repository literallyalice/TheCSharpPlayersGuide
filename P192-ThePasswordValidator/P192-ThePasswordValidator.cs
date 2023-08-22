

while (true) {
    Console.Write("Enter Password: ");
    var password = Console.ReadLine();

    Console.WriteLine(PasswordValidator.Validate(password) ? "Your password is valid." : "Your password is invalid.");
}

public class PasswordValidator
{
    public static bool Validate(string? password) {
        if (password == null) return false;
        if (password.Length is < 6 or > 13) return false;
        if (!HasUpperCase(password)) return false;
        if (!HasLowerCase(password)) return false;
        if (!HasDigits(password)) return false;
        if (Contains(password, 'T')) return false;
        if (Contains(password, '&')) return false;

        return true;
    }

    private static bool HasUpperCase(string password) {
        return password.Any(char.IsUpper);
    }

    private static bool HasLowerCase(string password) {
        return password.Any(char.IsLower);
    }

    private static bool HasDigits(string password) {
        return password.Any(char.IsDigit);
    }

    private static bool Contains(string password, char letter) {
        return password.Any(character => character == letter);
    }
}