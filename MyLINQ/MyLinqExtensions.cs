﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace MyLINQ
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<T> MyPrepend<T>(this IEnumerable<T> lst, T arg)
        {
            yield return arg;
            foreach (var el in lst)
            {
                yield return el;
            }
        }
        public static IEnumerable<T> MyAppend<T>(this IEnumerable<T> lst, T arg)
        {
            foreach (var el in lst)
            {
                yield return el;
            }
            yield return arg;
        }
        public static IEnumerable<T> MyConcat<T>(this IEnumerable<T> lst1, IEnumerable<T> lst2)
        {
            foreach (var el in lst1)
            {
                yield return el;
            }
            foreach (var el in lst2)
            {
                yield return el;
            }
        }
        public static int MyMax(this IEnumerable<int> lst)
        {
            if (lst.Count() == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            var max = lst.First();
            foreach (var el in lst)
            {
                if (max < el)
                    max = el;
            }
            return max;
        }
        public static int MyMin(this IEnumerable<int> lst)
        {
            if (lst.Count() == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            var min = lst.First();
            foreach (var el in lst)
            {
                if (min > el)
                    min = el;
            }
            return min;
        }
        public static bool MyAll<T>(this IEnumerable<T> lst, Func<T, bool> predicate)
        {
            foreach (var el in lst)
            {
                if (!predicate(el))
                    return false;
            }
            return true;
        }
        public static bool MyAny<T>(this IEnumerable<T> lst, Func<T, bool> predicate)
        {
            foreach (var el in lst)
            {
                if (predicate(el))
                    return true;
            }
            return false;
        }
        public static T MyAggregate<T>(this IEnumerable<T> lst, Func<T, T, T> func)
        {
            if (lst.Count() == 0)
            {
                throw new InvalidOperationException("Sequence contains no elements");
            }

            T result = default;
            foreach (var el in lst)
            {
                result = func(result, el);
            }
            return result;
        }
    }
}
