using entityframeworkcodebaseapproachwithdiftdb.Dtos;
using entityframeworkcodebaseapproachwithdiftdb.Entity;
using entityframeworkcodebaseapproachwithdiftdb.Interfaces;
using entityframeworkcodebaseapproachwithdiftdb.Repositories;

namespace entityframeworkcodebaseapproachwithdiftdb.services
{
    public class Orderservice : IOrderservice
    {
        private readonly IOrdersrepository _ordersrepository;
        public Orderservice(IOrdersrepository ordersrepository)
        {
            _ordersrepository = ordersrepository;
        }
        public async Task<int> Addorder(Orderdto order)
        {
            orders ord = new orders();
            ord.OrderId = order.OrderId;
            ord.OrderStatus = order.OrderStatus;
            ord.ordername = order.ordername;
            await _ordersrepository.Addorder(ord);
            return 1;
        }

        public async Task<bool> Deleteorderbyid(int id)
        {
            await _ordersrepository.Deleteorderbyid(id);
            return true;
        }

        public async Task<Orderdto> Getorderid(int id)
        {
            var res = await _ordersrepository.Getorderid(id);
            Orderdto orderdto = new Orderdto();

            orderdto.OrderId = res.OrderId;
            orderdto.OrderStatus = res.OrderStatus;
            orderdto.ordername = res.ordername;
            return orderdto;
        }

        public async Task<List<Orderdto>> Getorders()
        {
            List<Orderdto> orderdto = new List<Orderdto>();
            var item = await _ordersrepository.Getorders();
            foreach (var res in item)
            {
                Orderdto orderdtoo = new Orderdto();
                orderdtoo.OrderId = res.OrderId;
                orderdtoo.OrderStatus = res.OrderStatus;
                orderdtoo.ordername = res.ordername;
                orderdto.Add(orderdtoo);
            }
            return orderdto;
        }

        public async Task<bool> Updateorder(Orderdto order)
        {
            orders ord = new orders();
            ord.OrderId = order.OrderId;
            ord.OrderStatus = order.OrderStatus;
            ord.ordername = order.ordername;
            var res = await _ordersrepository.Updateorder(ord);
            return res;

        }
    }
}
    

