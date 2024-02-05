namespace Shared.DTOs.Persons;

public record PersonConnectionDto(
    int? ConnectedPersonId,
    ConnectionType ConnectionType
);