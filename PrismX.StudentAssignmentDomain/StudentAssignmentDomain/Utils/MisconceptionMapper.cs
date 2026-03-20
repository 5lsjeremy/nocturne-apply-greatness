namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class MisconceptionMapper
    {
        public static string Map(StudentAnalyzeInput input)
        {
            var response = input.StudentResponse.ToLowerInvariant();

            string misconception =
                response.Contains("photosynthesis happens at night") ? "photosynthesis-night" :
                response.Contains("the sun revolves around the earth") ? "geocentrism" :
                response.Contains("evolution is just a guess") ? "evolution-misunderstanding" :
                response.Contains("atoms are alive") ? "atoms-alive" :
                response.Contains("gravity needs air") ? "gravity-air" :
                "none";

            return Slug.Create("misconception", misconception);
        }
    }
}