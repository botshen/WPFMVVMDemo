using System;
using System.Windows.Input;

namespace 管理系统.Command
{
    /// <summary>
    /// 命令委托类
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// 事件Handler
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// ICommand接口方法实现,继承ICommand,需要可执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            //空判断
            if (CanExcuteFunc == null)
            {
                return true;
            }
            //执行委托,返回bool,判断是否可执行
            return this.CanExcuteFunc(parameter);
        }
        //执行Action委托
        public void Execute(object parameter)
        {
            if (this.ExcuteAction == null)
            {
                return;
            }
            this.ExcuteAction(parameter);
        }
        /// <summary>
        /// Action委托,参数object类型,执行动作
        /// </summary>
        public Action<object> ExcuteAction { get; set; }
        /// <summary>
        /// Func委托,参数object类型,返回bool类型.判断能否执行
        /// </summary>
        public Func<object, bool> CanExcuteFunc { get; set; }
    }
}
