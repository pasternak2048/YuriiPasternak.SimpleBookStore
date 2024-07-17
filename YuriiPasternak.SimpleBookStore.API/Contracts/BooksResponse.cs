namespace YuriiPasternak.SimpleBookStore.API.Contracts
{
    public record BooksResponse(
        Guid id,
        string Title,
        string Description,
        decimal Price);
}
