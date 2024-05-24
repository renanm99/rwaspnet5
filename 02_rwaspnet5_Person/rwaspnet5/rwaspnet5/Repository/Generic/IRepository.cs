using rwaspnet5.Model.Base;

namespace rwaspnet5.Repository
{
    public interface IRepository<Base> where Base : BaseEntity
    {
        Base Create(Base item);
        Base FindByID(long id);
        List<Base> FindAll();
        Base Update(Base item);
        void Delete(long id);
        bool Exists(long id);
    }
}
