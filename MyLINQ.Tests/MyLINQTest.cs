using NUnit.Framework;

using System;
using System.Linq;
using System.Collections.Generic;

namespace MyLINQ.Tests
{
    public class MyLINQTest
    {
        [Test]
        public void MyPrependTest()
        {
            var inputListPrependArgsCollection = new List<(IEnumerable<int>, IEnumerable<int>)>
            {
                // adding to empty list
                (new List<int> { }, new List<int> { 3 }),
                (new List<int> { }, new List<int> { 1, 2, 3 }),
                // adding to not empty list
                (new List<int> { 1, 2, 3 }, new List<int> { 3 }),
                (new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 }),
            };

            foreach (var (inputList, prependArgs) in inputListPrependArgsCollection)
            {
                var actual = inputList.AsEnumerable();
                foreach (var arg in prependArgs) actual = actual.MyPrepend(arg);

                var expected = inputList.AsEnumerable();
                foreach (var arg in prependArgs) expected = expected.Prepend(arg);


                Assert.That(actual, Is.EquivalentTo(expected));
            }    
        }
        [Test]
        public void MyAppendTest()
        {
            var inputListAppendArgsCollection = new List<(IEnumerable<int>, IEnumerable<int>)>
            {
                // adding to empty list
                (new List<int> { }, new List<int> { 3 }),
                (new List<int> { }, new List<int> { 1, 2, 3 }),
                // adding to not empty list
                (new List<int> { 1, 2, 3 }, new List<int> { 3 }),
                (new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 }),
            };

            foreach (var (inputList, prependArgs) in inputListAppendArgsCollection)
            {
                var actual = inputList.AsEnumerable();
                foreach (var arg in prependArgs) actual = actual.MyAppend(arg);

                var expected = inputList.AsEnumerable();
                foreach (var arg in prependArgs) expected = expected.Append(arg);

                Assert.That(actual, Is.EquivalentTo(expected));
            }
        }
        [Test]
        public void MyConcatTest()
        {
            var inputListConcatListCollection = new List<(IEnumerable<int>, IEnumerable<int>)>
            {
                // adding to empty list
                (new List<int> { }, new List<int> { 3 }),
                (new List<int> { }, new List<int> { 1, 2, 3 }),
                // adding to not empty list
                (new List<int> { 1, 2, 3 }, new List<int> { }),
                (new List<int> { 1, 2, 3 }, new List<int> { 3 }),
                (new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 }),
            };

            foreach (var (firstList, secondList) in inputListConcatListCollection)
            {
                var actual = firstList.AsEnumerable();
                actual = actual.MyConcat(secondList);

                var expected = firstList.AsEnumerable();
                expected = expected.Concat(secondList);

                Assert.That(actual, Is.EquivalentTo(expected));
            }
        }
        [Test]
        public void MyMaxTest()
        {
            var inputList = new List<IEnumerable<int>>
            {
                (new List<int> { 1 }),
                (new List<int> { 1 , 8, 6 , -1 }),
                (new List<int> { -1 , -8, -1 }),
                (new List<int> { Int32.MaxValue, Int32.MinValue }),
            };

            foreach (var inputLst in inputList)
            {
                Assert.AreEqual(inputLst.Max(), inputLst.MyMax());
            }

            // throw on empty list
            Assert.Throws<InvalidOperationException>(() => new List<int>().MyMax());
        }
        [Test]
        public void MyMinTest()
        {
            var inputList = new List<IEnumerable<int>>
            {
                (new List<int> { 1 }),
                (new List<int> { 1 , 8, 6 , -1 }),
                (new List<int> { -1 , -8, -1 }),
                (new List<int> { Int32.MaxValue, Int32.MinValue }),
            };

            foreach (var inputLst in inputList)
            {
                Assert.AreEqual(inputLst.Min(), inputLst.MyMin());
            }

            // throw on empty list
            Assert.Throws<InvalidOperationException>(() => new List<int>().MyMin());
        }
        [Test]
        public void MyAllTest()
        {
            var inputList = new List<IEnumerable<int>>
            {
                (new List<int> { }),
                (new List<int> { 2, 3, 8 }),
                (new List<int> { -1, -5 }),
            };

            foreach (var list in inputList)
            {
                Assert.That(list.All(el => el > 0), Is.EqualTo(list.MyAll(el => el > 0)));
                Assert.That(list.All(el => el < 0), Is.EqualTo(list.MyAll(el => el < 0)));
                Assert.That(list.All(el => el > 2), Is.EqualTo(list.MyAll(el => el > 2)));
            }
        }
        [Test]
        public void MyAnyTest()
        {
            var inputList = new List<IEnumerable<int>>
            {
                (new List<int> { }),
                (new List<int> { 2, 3, 8 }),
                (new List<int> { 3, 3, 8 }),
                (new List<int> { -1, 5 }),
                (new List<int> { -1, -5 }),
            };

            foreach (var list in inputList)
            {
                Assert.That(list.Any(el => el > 0), Is.EqualTo(list.MyAny(el => el > 0)));
                Assert.That(list.Any(el => el < 0), Is.EqualTo(list.MyAny(el => el < 0)));
                Assert.That(list.Any(el => el > 2), Is.EqualTo(list.MyAny(el => el > 2)));
            }
        }
        [Test]
        public void MyAggregate()
        {
            var intList = new List<int> { 1, 5, 8 };
            var strList = new List<string> { "I'm", " a programmer." };

            Assert.AreEqual(intList.MyAggregate((accumulate, source) => accumulate / source), intList.Aggregate((accumulate, source) => accumulate / source));
            Assert.AreEqual(intList.MyAggregate((accumulate, source) => accumulate + source), intList.Aggregate((accumulate, source) => accumulate + source));
            Assert.AreEqual(strList.MyAggregate((accumulate, source) => accumulate + source), strList.Aggregate((accumulate, source) => accumulate + source));

            // throw on empty list
            Assert.Throws<InvalidOperationException>(() => new List<int>().MyAggregate((el1, el2) => el1 + el2));
        }

    }
}