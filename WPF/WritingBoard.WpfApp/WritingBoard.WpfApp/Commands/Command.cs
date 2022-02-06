﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WritingBoard.WpfApp.Commands
{
    public class Command<T> : ICommand
    {
        private Action<T> m_handler;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_handler((T)parameter);
        }

        public Command(Action<T> handler)
        {
            m_handler = handler;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public class Command : ICommand
    {
        private Action m_handler;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_handler();
        }

        public Command(Action handler)
        {
            m_handler = handler;
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
