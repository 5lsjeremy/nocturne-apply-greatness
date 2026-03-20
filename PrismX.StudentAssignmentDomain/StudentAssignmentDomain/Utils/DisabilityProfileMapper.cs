namespace PrismX.StudentAssignmentDomain.StudentAssignmentDomain.Utils
{
    public static class DisabilityProfileMapper
    {
        public static string Map(StudentAnalyzeInput input)
        {
            var text = input.StudentResponse.ToLowerInvariant();

            string profile =
                text.Contains("hard to read") ||
                text.Contains("letters move") ||
                text.Contains("reading is difficult")
                    ? "dyslexia"

                    : text.Contains("hard to focus") ||
                      text.Contains("can't concentrate") ||
                      text.Contains("mind wanders")
                        ? "adhd"

                        : text.Contains("can't see well") ||
                          text.Contains("text too small")
                            ? "visual-impairment"

                            : text.Contains("can't hear") ||
                              text.Contains("audio unclear")
                                ? "auditory-impairment"

                                : text.Contains("processing slow") ||
                                  text.Contains("takes me longer")
                                    ? "processing-speed"

                                    : "none";

            return Slug.Create("disability", profile);
        }
    }
}