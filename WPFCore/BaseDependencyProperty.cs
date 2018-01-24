using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFCore
{
    public abstract class BaseDependencyProperty<OwnerType, PropertyType> where OwnerType : DependencyObject
    {
        public DependencyProperty Property { get; private set; }

        public BaseDependencyProperty(string name) : this(name, default(PropertyType)) { }

        public BaseDependencyProperty(string name, PropertyType defaultValue)
        {
            Property = DependencyProperty.Register(name, 
                typeof(PropertyType), 
                typeof(OwnerType), 
                new PropertyMetadata(defaultValue, BasePropertyChangedCallback, BaseCoerceValueCallback));
        }

        public PropertyType Get(OwnerType owner)
        {
            return (PropertyType)owner.GetValue(Property);
        }

        public void Set(OwnerType owner, PropertyType value)
        {
            owner.SetValue(Property, value);
        }

        private void BasePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var owner = d as OwnerType;
            OnPropertyChanged(owner, e);
        }

        private object BaseCoerceValueCallback(DependencyObject d, object baseValue)
        {
            var owner = d as OwnerType;
            var value = (PropertyType)baseValue;
            return OnCoerceValue(owner, value);
        }

        public virtual void OnPropertyChanged(OwnerType owner, DependencyPropertyChangedEventArgs e) { }
        public virtual PropertyType OnCoerceValue(OwnerType owner, PropertyType baseValue) { return baseValue; }
    }
}
