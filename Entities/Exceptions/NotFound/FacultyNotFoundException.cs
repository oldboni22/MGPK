namespace Entities.Exceptions.NotFound;

public class FacultyNotFoundException : NotFoundException
{
    public FacultyNotFoundException(int id) 
        : base($"The faculty with id {id} was not found")
    {
    }
}