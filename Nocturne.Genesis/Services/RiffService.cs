using Nocturne.Abstractions.Genesis;

namespace Nocturne.Genesis.Services;

internal sealed class RiffService : IRiffService
{
    private readonly IApprovalService _approval;

    public RiffService(IApprovalService approval)
    {
        _approval = approval;
    }

    public ICard Riff(ICard card, string contributor, string prompt)
    {
        return _approval.ProposeEdit(card, contributor, prompt);
    }
}