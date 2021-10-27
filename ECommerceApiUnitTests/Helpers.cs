using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECommerceApiUnitTests
{
    public static class Helpers
    {
        /// <summary>
        /// Use this to test if a property on a class has an attribute.
        /// </summary>
        /// <typeparam name="T">The Type of Class</typeparam>
        /// <typeparam name="TAttribute">The Type of the Attribte your Looking For</typeparam>
        /// <param name="propertyExpression">Give an example of the property that this should check</param>
        /// <returns>true of the property has that attribute, and false if does not</returns>
        public static bool HasAttribute<T, TAttribute>(
            Expression<Func<T, object>> propertyExpression
        ) where TAttribute : Attribute
        {

            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null;
        }

        /// <summary>
        /// Checks a property value on an attribute 
        /// </summary>
        /// <typeparam name="T">The class with the property you want to check</typeparam>
        /// <typeparam name="TOut">The data type of that property</typeparam>
        /// <typeparam name="TAttribute">The attribute you want to read</typeparam>
        /// <typeparam name="TValue">The data type of that property</typeparam>
        /// <param name="propertyExpression">A Func that describes how to get the property</param>
        /// <param name="valueSelector">The value for that property</param>
        /// <returns>The actual value of the property</returns>
        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(
                Expression<Func<T, TOut>> propertyExpression,
                Func<TAttribute, TValue> valueSelector
            ) where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null ? valueSelector(attr) : default(TValue);
        }
    }
}