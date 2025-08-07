using System.Globalization;

public static class CsvLoader
{
    private static readonly string[] DateFormats = {
        "yyyy-MM-dd", "MM/dd/yyyy", "dd.MM.yyyy", "yyyy/MM/dd"
    };

    public static List<Actor> LoadActors(string path)
    {
        var actors = new List<Actor>();
        foreach (var line in File.ReadLines(path).Skip(1))
        {
            var parts = line.Split(',', 3);
            if (parts.Length < 3) continue;
            actors.Add(new Actor
            {
                Id = int.Parse(parts[0].Trim()),
                FullName = parts[1].Trim(),
                BirthDate = ParseDate(parts[2].Trim())
            });
        }
        return actors;
    }

    public static List<Movie> LoadMovies(string path)
    {
        var movies = new List<Movie>();
        foreach (var line in File.ReadLines(path).Skip(1))
        {
            var parts = line.Split(',', 3);
            if (parts.Length < 3) continue;
            movies.Add(new Movie
            {
                Id = int.Parse(parts[0].Trim()),
                Title = parts[1].Trim(),
                ReleaseDate = ParseDate(parts[2].Trim())
            });
        }
        return movies;
    }

    public static List<Role> LoadRoles(string path)
    {
        var roles = new List<Role>();
        foreach (var line in File.ReadLines(path).Skip(1))
        {
            var parts = line.Split(',', 4);
            if (parts.Length < 4) continue;
            roles.Add(new Role
            {
                Id = int.Parse(parts[0].Trim()),
                ActorId = int.Parse(parts[1].Trim()),
                MovieId = int.Parse(parts[2].Trim()),
                RoleName = string.IsNullOrWhiteSpace(parts[3]) || parts[3].Trim().ToUpper() == "NULL" ? null : parts[3].Trim()
            });
        }
        return roles;
    }

    private static DateTime ParseDate(string input)
    {
        foreach (var fmt in DateFormats)
        {
            if (DateTime.TryParseExact(input, fmt, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                return dt;
        }
        return DateTime.Parse(input, CultureInfo.InvariantCulture);
    }
}