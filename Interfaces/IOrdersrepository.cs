using entityframeworkcodebaseapproachwithdiftdb.Entity;

namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface IOrdersrepository
    {
        public Task<int> Addorder(orders order);
         public Task<List<orders>> Getorders();
         public Task<orders > Getorderid(int id);
         public Task<bool> Deleteorderbyid(int id);
         public Task<bool> Updateorder(orders order);
    }
}
