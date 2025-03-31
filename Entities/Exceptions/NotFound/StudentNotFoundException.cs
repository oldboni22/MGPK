namespace Entities.Exceptions.NotFound;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException(int id) 
        : base($"The group with id {id} was not found")
    {
    }
}