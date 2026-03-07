using System.Collections.ObjectModel;
using Nocturne.Abstractions.Genesis.Concepts;

namespace Nocturne.Genesis.Concepts
{
    internal sealed class DomainState : IDomainState
    {
        private readonly Dictionary<string, IDomainValue> _values = new();
        private readonly Dictionary<string, IDomainRuleSet> _rules;

        public DomainState(IEnumerable<IDomainRuleSet> rules)
        {
            _rules = rules.ToDictionary(r => r.Domain);

            foreach (var rule in rules)
            {
                _values[rule.Domain] = new DomainValue
                {
                    Current = rule.DefaultThreshold,
                    Gravity = rule.DefaultGravity,
                    Threshold = rule.DefaultThreshold
                };
            }

            Domains = new ReadOnlyDictionary<string, IDomainValue>(_values);
        }

        public IDomainValue this[string domain] => _values[domain];

        public IReadOnlyDictionary<string, IDomainValue> Domains { get; }

        public void ApplyPressure(IDomainPressure pressure)
        {
            var ruleSet = _rules[pressure.Domain];
            var value = _values[pressure.Domain];

            float modified = pressure.Magnitude;

            foreach (var rule in ruleSet.ProtectionRules)
            {
                if (rule.AppliesTo(pressure.Type, pressure.Tags))
                    modified = rule.ModifyIncomingPressure(modified, pressure.Type, pressure.Tags);
            }

            value.Current -= modified;
        }

        public void ApplySpark(IDomainSpark spark)
        {
            var ruleSet = _rules[spark.Domain];
            var value = _values[spark.Domain];

            float modified = spark.Magnitude;

            foreach (var rule in ruleSet.ReinforcementRules)
            {
                if (rule.AppliesTo(spark.Type, spark.Tags))
                    modified = rule.ModifyIncomingReinforcement(modified, spark.Type, spark.Tags);
            }

            value.Current += modified;
        }

        public float WorldStability
        {
            get
            {
                // Average domain health as a simple stability metric
                if (_values.Count == 0) return 1f;

                float sum = 0;
                foreach (var v in _values.Values)
                    sum += v.Current / v.Threshold;

                return sum / _values.Count;
            }
        }

        public bool IsCollapsing
        {
            get
            {
                foreach (var kvp in _values)
                {
                    var domain = kvp.Key;
                    var value = kvp.Value;
                    var rule = _rules[domain];

                    if (rule.CheckCollapse(value, null)) // world context injected later
                        return true;
                }

                return false;
            }
        }
    }
}