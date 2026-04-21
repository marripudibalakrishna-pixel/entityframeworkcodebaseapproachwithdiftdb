using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface IOrderservice
    {
        public Task<int> Addorder(Orderdto order);
        public Task<List<Orderdto>> Getorders();
        public Task<Orderdto> Getorderid(int id);
        public Task<bool> Deleteorderbyid(int id);
        public Task<bool> Updateorder(Orderdto order);
    }
}

