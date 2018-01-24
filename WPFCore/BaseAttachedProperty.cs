using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCore
{
    public abstract class BaseAttachedProperty<PropertyType, OwnerType>
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
            typeof(PropertyType),
            typeof(OwnerType),
            new PropertyMetadata(default(PropertyType), BasePropertyChangedCallback, BaseCoerceValueCallback));

        // getter and setter must follow default WPF convention
        public static PropertyType GetValue(DependencyObject d)
        {
            return (PropertyType)d.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject d, PropertyType value)
        {
            d.SetValue(ValueProperty, value);
        }

        private static void BasePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var parent = d as BaseAttachedProperty<PropertyType, OwnerType>;
            parent?.PropertyChanged(d, e);
        }

        private static object BaseCoerceValueCallback(DependencyObject d, object baseValue)
        {
            var parent = d as BaseAttachedProperty<PropertyType, OwnerType>;
            return parent.CoerceValue(d, baseValue);
        }

        public virtual void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        public virtual object CoerceValue(DependencyObject d, object baseValue) { return baseValue; }
    }
}
