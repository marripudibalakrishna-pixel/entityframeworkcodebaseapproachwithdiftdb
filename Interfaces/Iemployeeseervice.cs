using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Dtos;
namespace entityframeworkcodebaseapproachwithdiftdb.Interfaces
{
    public interface Iemployeeseervice
    {
        Task<List<Employeedto>> GetAll();
        Task<Employeedto   > GetById(int id);
        Task<bool> DeleteById(int id);
        Task<int> Addemployee(Employeedto empdetails);

        Task<bool> Updateemployee(Employeedto empdetails);
    }
}
