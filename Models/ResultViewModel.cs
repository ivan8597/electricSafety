namespace ElectricalSafetyQuiz.Models
{
    public class ResultViewModel
    {
        public string QuestionText { get; set; } = string.Empty;
        public string UserAnswerText { get; set; } = string.Empty;
        public string CorrectAnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
} 