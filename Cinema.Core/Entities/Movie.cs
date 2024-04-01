namespace Cinema.Core;

using System;
using System.Collections.Generic;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int AgeLimit { get; set; }
    public string Language { get; set; }
    public string UnderText { get; set; }
    public List<string> Actors { get; set; }
    public List<string> Direction { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public TimeOnly Time { get; set; }
    public string? ImageUrl { get; set; }
}
