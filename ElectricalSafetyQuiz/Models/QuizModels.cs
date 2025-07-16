using System.Collections.Generic;

namespace ElectricalSafetyQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }

    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
} 