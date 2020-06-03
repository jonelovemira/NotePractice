﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WpfDemo.Converters;

namespace WpfDemo.DynamicallyGeneratedDataGrid.Samples
{
    public class ModifyVisibilityConverter : IValueConverter
    {
        //当值从绑定源传播给绑定目标时，调用方法Convert
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = value as FakeDatabase;
            //翻页的时候data为空
            if (data != null)
            {
                if (data.Id % 2 == 0)
                {
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Visible;
        }
        //当值从绑定目标传播给绑定源时，调用此方法ConvertBack
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("");
        }
    }
}
