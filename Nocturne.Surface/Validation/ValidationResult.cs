using System.Collections.Generic;
using System.Linq;

namespace Nocturne.Surface.Validation
{
    public sealed class ValidationResult
    {
        private readonly List<string> _errors = new();
        private readonly List<string> _warnings = new();

        public IReadOnlyCollection<string> Errors => _errors;
        public IReadOnlyCollection<string> Warnings => _warnings;

        public bool IsValid => !_errors.Any();

        public ValidationResult() { }

        public void AddError(string message)
        {
            _errors.Add(message);
        }

        public void AddWarning(string message)
        {
            _warnings.Add(message);
        }
    }
}