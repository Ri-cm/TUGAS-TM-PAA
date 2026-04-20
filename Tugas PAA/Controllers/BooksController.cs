using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Dapper;
using Tugas_PAA.Models;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly string _connStr = "Host=127.0.0.1;Database=book_api;Username=postgres;Password=admin123";

    // 1. READ ALL (GET /api/Books)
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = "SELECT * FROM books WHERE deleted_at IS NULL";
        var books = await conn.QueryAsync(sql);
        return Ok(new ApiResponse<object> { Status = true, Message = "Success", Data = books });
    }

    // 2. READ DETAIL (GET /api/Books/{id}) -> Sudah ada di screenshot Anda
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = "SELECT * FROM books WHERE id = @Id AND deleted_at IS NULL";
        var book = await conn.QueryFirstOrDefaultAsync(sql, new { Id = id });
        if (book == null) return NotFound(new ApiResponse<string> { Status = false, Message = "Not Found" });
        return Ok(new ApiResponse<object> { Status = true, Message = "Success", Data = book });
    }

    // 3. CREATE (POST /api/Books) -> Sudah ada di screenshot Anda
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookCreateDto model)
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = @"INSERT INTO books (title, author_id, category_id, price, stock) 
                    VALUES (@Title, @AuthorId, @CategoryId, @Price, @Stock) RETURNING id";
        var id = await conn.ExecuteScalarAsync<int>(sql, model);
        return CreatedAtAction(nameof(GetById), new { id }, new ApiResponse<int> { Status = true, Message = "Created", Data = id });
    }

    // 4. UPDATE (PUT /api/Books/{id})
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookCreateDto model)
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = "UPDATE books SET title = @Title, price = @Price, stock = @Stock WHERE id = @Id";
        await conn.ExecuteAsync(sql, new { model.Title, model.Price, model.Stock, Id = id });
        return Ok(new ApiResponse<string> { Status = true, Message = "Updated Successfully" });
    }

    // 5. DELETE (DELETE /api/Books/{id}) -> Soft Delete sesuai kriteria Skor 5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        using var conn = new NpgsqlConnection(_connStr);
        var sql = "UPDATE books SET deleted_at = CURRENT_TIMESTAMP WHERE id = @Id";
        await conn.ExecuteAsync(sql, new { Id = id });
        return Ok(new ApiResponse<string> { Status = true, Message = "Deleted Successfully" });
    }
}