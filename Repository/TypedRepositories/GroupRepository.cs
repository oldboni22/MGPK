using Entities;

namespace Repository.TypedRepositories;


public interface IGroupRepository
{
    IEnumerable<Group> GetGroups(bool trackChanges);
    Group? GetGroup(int id, bool trackChanges);
}

public class GroupRepository(RepositoryContext context) : RepositoryBase<Group>(context), IGroupRepository
{
    public IEnumerable<Group> GetGroups(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(group => group.Name)
            .ToList();

    public Group? GetGroup(int id, bool trackChanges) =>
        FindByCondition(group => group.Id == id, trackChanges)
            .SingleOrDefault();
}