namespace Shared.DTOs.Persons;

public record ConnectedPersonsRelationshipDto(
    int? PersonId,
    int? ConnectedPersonId,
    ConnectionType ConnectionType
);