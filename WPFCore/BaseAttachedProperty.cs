using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCore
{
    public abstract class BaseAttachedProperty<OwnerType, PropertyType> where OwnerType : new()
    {
        private static OwnerType instance;
        public static OwnerType Instance
        {
            get
            {
                if (instance == null)
                    instance = new OwnerType();
                return instance;
            }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value",
            typeof(PropertyType),
            typeof(OwnerType),
            new PropertyMetadata(default(PropertyType), BasePropertyChangedCallback, BaseCoerceValueCallback));

        // getter and setter must follow default WPF convention
        // this approach has one flaw - it can not be accessed by Binding in XAML
        public static PropertyType GetValue(DependencyObject d)
        {
            return (PropertyType)d.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject d, PropertyType val)
        {
            d.SetValue(ValueProperty, val);
        }

        private static void BasePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var i = Instance as BaseAttachedProperty<OwnerType, PropertyType>;
            i?.PropertyChanged(d, e);
        }

        private static object BaseCoerceValueCallback(DependencyObject d, object baseValue)
        {
            var i = Instance as BaseAttachedProperty<OwnerType, PropertyType>;
            return i?.CoerceValue(d, (PropertyType)baseValue);
        }

        public virtual void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }
        public virtual object CoerceValue(DependencyObject d, PropertyType baseValue) { return baseValue; }
    }
}
