using System;
using System.Collections.Generic;
using System.Text;
using 管理系统.Model;

namespace 管理系统.Service
{
    public interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}
