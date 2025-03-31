namespace Entities.Exceptions.NotFound;

public class GroupNotFoundException : NotFoundException
{
    public GroupNotFoundException(int id) 
        : base($"The group with id {id} was not found")
    {
    }
}