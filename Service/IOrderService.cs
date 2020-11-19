using System;
using System.Collections.Generic;
using System.Text;

namespace 管理系统.Service
{
    public interface IOrderService
    {
        void PlaceOrder(List<string> Dieshes);
    }
}
