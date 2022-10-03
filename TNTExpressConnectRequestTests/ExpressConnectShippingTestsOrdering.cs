namespace TNTExpressConnectRequest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class ExpressConnectShippingTestsOrdering : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            Dictionary<int, List<TTestCase>> sortedMethods = new();

            foreach (TTestCase testCase in testCases)
            {
                int priority =  testCase.TestMethod.Method.GetCustomAttributes(typeof(PriorityAttribute).AssemblyQualifiedName)
                    .FirstOrDefault()?.GetNamedArgument<int>("Priority") ?? 0;

                GetOrCreate(sortedMethods, priority).Add(testCase);
            }

            foreach (TTestCase testCase in sortedMethods.Keys.OrderByDescending(key => key)
                .Select(priority => sortedMethods[priority]
                .OrderBy(testCase => testCase.TestMethod.Method.Name)).Select(t => (TTestCase)t))
            {
                yield return testCase;
            }
        }

        private static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
        where TValue : new() =>
            dictionary.TryGetValue(key, out TValue? result) 
            ? result
            : (dictionary[key] = new TValue());
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class PriorityAttribute : Attribute
    {
        public PriorityAttribute(int priority) =>  Priority = priority;
        
        public int Priority { get; private set; }
    }
}
