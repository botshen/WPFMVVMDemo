using System;
using System.Collections.Generic;
using System.Text;

namespace 管理系统.Service
{
    public class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> Dieshes)
        {
            System.IO.File.WriteAllLines(@"E:\Order.txt", Dieshes.ToArray());
        }
    }
}
