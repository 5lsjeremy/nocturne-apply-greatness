namespace Nocturne.Abstractions.Genesis;

public interface IApprovalService
{
    void Approve(ICard card, string approver);
    void Reject(ICard card, string approver, string reason);
    ICard ProposeEdit(ICard card, string contributor, string prompt);
}