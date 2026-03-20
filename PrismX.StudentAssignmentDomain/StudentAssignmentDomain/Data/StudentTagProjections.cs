using PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Models;

namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Data;

public static class StudentTagProjections
{
    public static readonly IReadOnlyDictionary<string, Action<StudentState, string>> Rules =
        new Dictionary<string, Action<StudentState, string>>
        {
            // ------------------------------------------------------------
            // Misconceptions
            // ------------------------------------------------------------
            ["student.misconception."] = (state, value) =>
            {
                if (!state.ActiveMisconceptions.Contains(value))
                    state.ActiveMisconceptions.Add(value);
            },

            // ------------------------------------------------------------
            // Cognitive dimensions
            // ------------------------------------------------------------
            ["student.cognitive."] = (state, value) =>
            {
                state.LastCognitiveDimension = value;
            },

            // ------------------------------------------------------------
            // Affective dimensions
            // ------------------------------------------------------------
            ["student.affective."] = (state, value) =>
            {
                state.LastAffectiveDimension = value;
            },

            // ------------------------------------------------------------
            // Skill categories
            // ------------------------------------------------------------
            ["student.skill."] = (state, value) =>
            {
                state.LastSkillCategory = value;
            },

            // ------------------------------------------------------------
            // Assignment type
            // ------------------------------------------------------------
            ["assignment.type."] = (state, value) =>
            {
                state.LastAssignmentType = value;
            },

            // ------------------------------------------------------------
            // Assignment topic
            // ------------------------------------------------------------
            ["assignment.topic."] = (state, value) =>
            {
                state.LastAssignmentTopic = value;
            },

            // ------------------------------------------------------------
            // Assignment difficulty
            // ------------------------------------------------------------
            ["assignment.difficulty."] = (state, value) =>
            {
                state.LastAssignmentDifficulty = value;
            }
        };
}