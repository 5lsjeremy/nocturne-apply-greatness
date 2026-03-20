using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

public sealed class SkillUnit
{
    private string _unitName = string.Empty;

    public string UnitId { get; set; } = string.Empty;

    public string UnitName
    {
        get => _unitName;
        set
        {
            _unitName = value;
            UnitSlug = Slug.Create(UnitId, value);
        }
    }

    public string UnitSlug { get; private set; } = string.Empty;

    public float Score { get; set; }
    public string? Description { get; set; }
}