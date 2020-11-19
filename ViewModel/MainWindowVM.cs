using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using 管理系统.Command;
using 管理系统.Model;
using 管理系统.Service;

namespace 管理系统.ViewModel
{
    /// <summary>
    /// mainwindow Vm
    /// </summary>
    public class MainWindowVM : NotificationObject
    {
        /// <summary>
        /// 订餐命令
        /// </summary>
        public DelegateCommand PlaceOrderCommand { get; set; }
        /// <summary>
        /// 选中命令
        /// </summary>
        public DelegateCommand SelectMenuItemCommand { get; set; }
        
        //私有字段
        private int count;
        //共有属性
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChange("Count");
            }
        }

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChange("Restaurant");
            }
        }
        private List<DishMenuItemVm> dishMenu;
        public List<DishMenuItemVm> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChange("DishMenu");
            }
        }
        public MainWindowVM()
        {
            this.LoadResturant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand();
            this.PlaceOrderCommand.ExcuteAction = new Action<object>(this.PlaceOrderCommandExcute);


            this.SelectMenuItemCommand = new DelegateCommand();
            this.SelectMenuItemCommand.ExcuteAction = new Action<object>(this.SelectMenuItemExcute);
        }
        private void LoadResturant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Craze大象";
            this.Restaurant.Address = "北京市海淀区万泉河路紫金庄园1号楼";
            this.Restaurant.Phone = "13679112984";
        }
        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.DishMenu = new List<DishMenuItemVm>();
            foreach (var dish in dishes)
            {
                DishMenuItemVm item = new DishMenuItemVm();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }
        private void PlaceOrderCommandExcute(object o)
        {
            var selectedDishes = this.DishMenu.Where(t => t.IsSelected == true).Select(t => t.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");
        }
        private void SelectMenuItemExcute(object o)
        {
            this.Count = this.DishMenu.Count(t => t.IsSelected == true);
        }
    }
}
