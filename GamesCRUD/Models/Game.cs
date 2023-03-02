using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace GamesCRUD.Models;

public partial class Game
{
    [SwaggerSchema(Description = "Incremental ID", ReadOnly = true)]
    public int Id { get; set; }

    [SwaggerSchema(Description = "Nome do game")]
    public string Name { get; set; } = null!;

    [SwaggerSchema(Description = "Descrição do game")]
    public string? Description { get; set; }

    [SwaggerSchema(Description = "Categoria do game")]
    public string? Category { get; set; }

    [SwaggerSchema(Description = "Preço do game")]
    public decimal Price { get; set; }

    public string Platform { get; set; } = null!;

    [SwaggerSchema(Description = "Data de lançamento do game", Format = "date")]
    public DateTime ReleaseDate { get; set; }

    [SwaggerSchema(Description = "Data de criação do registro, gerado automaticamente", Format = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [SwaggerSchema(Description = "Data de atualização do registro, gerado automaticamente", Format = "timestamp")]
    public DateTime? UpdatedAt { get; set; }
}
