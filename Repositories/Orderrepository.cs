using entityframeworkcodebaseapproachwithdiftdb.DBcontext;
using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace entityframeworkcodebaseapproachwithdiftdb.Repositories
{
    public class Orderrepository : IOrdersrepository
    {   private readonly OrderContext _orderContext;
        public Orderrepository(OrderContext orderContext)        {
            _orderContext = orderContext;
        }
        public async Task<int> Addorder(orders order)
        {
            _orderContext.orders.Add(order);
            _orderContext.SaveChanges();
            return 1;


        }

        public async Task<bool> Deleteorderbyid(int id)
        {
           var res= await _orderContext.orders.Where(a=>a.OrderId==id).FirstOrDefaultAsync();
            if (res != null)
            {
                _orderContext.orders.Remove(res);
                _orderContext.SaveChanges();
                return true;
            }
            else return false;

        }

        public async  Task<orders> Getorderid(int id)
        {
            var res = await _orderContext.orders.Where(a => a.OrderId == id).FirstOrDefaultAsync();
             if (res != null)
                { return res; }
             else return null;
        }

        public Task<List<orders>> Getorders()
        {
           var res =  _orderContext.orders.ToListAsync();
            return res;
        }

        public async Task<bool> Updateorder(orders order)
        {
             _orderContext.orders.Update(order);
            await _orderContext.SaveChangesAsync();
            return true;
        }
    }
}
