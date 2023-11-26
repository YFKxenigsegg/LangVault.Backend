namespace Application.Words.Queries;
public record GetRequest(int Id) : IRequest<WordInfo>;
