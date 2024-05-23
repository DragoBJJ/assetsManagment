namespace Assets.Domain.Exceptions;

    public class NotFoundException(string resourceType, string resourceIdentifier): Exception($"{resourceType} with id: {resourceIdentifier} Doesn't exist")
    {
    public int StatusCode { get; } = 404;
    }

