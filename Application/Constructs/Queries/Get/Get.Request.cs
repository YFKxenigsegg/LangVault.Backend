namespace Application.Constructs.Queries;
public record GetRequest(int Id) : IRequest<ConstructInfo>;
