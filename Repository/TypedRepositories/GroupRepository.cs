using Entities;

namespace Repository.TypedRepositories;


public interface IGroupRepository
{
    IEnumerable<Group> GetGroups(int facultyId,bool trackChanges);
    Group? GetGroup(int facultyId,int id, bool trackChanges);
}

public class GroupRepository(RepositoryContext context) : RepositoryBase<Group>(context), IGroupRepository
{
    public IEnumerable<Group> GetGroups(int facultyId,bool trackChanges) =>
        FindByCondition(group => group.FacultyId == facultyId,trackChanges)
            .OrderBy(group => group.Name)
            .ToList();

    public Group? GetGroup(int facultyId,int id, bool trackChanges) =>
        FindByCondition(group => group.Id == id && group.FacultyId == facultyId, trackChanges)
            .SingleOrDefault();
    
    public Group? GetGroup(int id, bool trackChanges) =>
        FindByCondition(group => group.Id == id, trackChanges)
            .SingleOrDefault();
}