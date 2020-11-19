using System;
using System.Collections.Generic;
using System.Text;
using 管理系统.Model;

namespace 管理系统.ViewModel
{
    public class DishMenuItemVm: NotificationObject
    {
        public Dish Dish { get; set; }
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChange("IsSelected");
            }
        }
    }
}
