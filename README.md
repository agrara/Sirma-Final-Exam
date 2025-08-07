# Actor Co-Star Analysis ASP.NET Application

## Task

Given CSV files for actors, movies, and roles, identify the pair of actors who have co-starred in the most movies together, and list those movies and their release years.

## Algorithm

1. Load actors, movies, and roles from CSV files (supporting multiple date formats, no external libraries).
2. Store data in a SQL database (Entity Framework Core).
3. For each movie, collect the set of actors.
4. For each unique actor pair, count the number of movies they co-starred in.
5. Identify the pair with the highest count.
6. List the movies and release years for that pair.

## Features

- Handles NULL roles.
- Supports multiple date formats.
- Clean code conventions.
- CRUD for Actors, Movies, and Roles (standard Web API controllers).
- Easily switch to another SQL database.

## How to Run

1. Place your CSV files in a known folder.
2. Use the CsvLoader to import data on startup.
3. Run the project and access `/analysis`