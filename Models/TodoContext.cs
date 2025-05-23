﻿using Microsoft.EntityFrameworkCore;

namespace api_teste.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<Veiculo> Veiculo { get; set; } = null!;
}