using Entities;

namespace Repository.TypedRepositories;


public interface IGroupRepository
{
    
}

public class GroupRepository(RepositoryContext context) : RepositoryBase<Group>(context), IGroupRepository
{
    
}