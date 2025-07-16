using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricalSafetyQuiz.Data;
using ElectricalSafetyQuiz.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace ElectricalSafetyQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly QuizDbContext _context;
        private const string AnswersKey = "UserAnswers";

        public QuizController(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Start()
        {
            HttpContext.Session.Remove(AnswersKey);
            var questions = await _context.Questions.Select(q => q.Id).ToListAsync();
            HttpContext.Session.SetString("QuestionIds", JsonSerializer.Serialize(questions));
            return RedirectToAction("Question", new { id = 0 });
        }

        public async Task<IActionResult> Question(int id)
        {
            var questionIdsJson = HttpContext.Session.GetString("QuestionIds");
            if (string.IsNullOrEmpty(questionIdsJson))
            {
                return RedirectToAction("Start");
            }

            var questionIds = JsonSerializer.Deserialize<List<int>>(questionIdsJson);
            if (questionIds == null || id >= questionIds.Count)
            {
                return RedirectToAction("Result");
            }

            var questionId = questionIds[id];
            var question = await _context.Questions.Include(q => q.Answers).FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
            {
                return NotFound();
            }

            ViewData["QuestionIndex"] = id;
            return View(question);
        }

        [HttpPost]
        public IActionResult SubmitAnswer(int questionIndex, int questionId, int answerId)
        {
            var answersJson = HttpContext.Session.GetString(AnswersKey);
            var answers = string.IsNullOrEmpty(answersJson) 
                ? new Dictionary<int, int>() 
                : JsonSerializer.Deserialize<Dictionary<int, int>>(answersJson) ?? new Dictionary<int, int>();

            answers[questionId] = answerId;
            HttpContext.Session.SetString(AnswersKey, JsonSerializer.Serialize(answers));

            return RedirectToAction("Question", new { id = questionIndex + 1 });
        }
        
        public async Task<IActionResult> Result()
        {
            var answersJson = HttpContext.Session.GetString(AnswersKey);
            var answers = string.IsNullOrEmpty(answersJson)
                ? new Dictionary<int, int>()
                : JsonSerializer.Deserialize<Dictionary<int, int>>(answersJson) ?? new Dictionary<int, int>();

            var results = new List<ResultViewModel>();
            var allQuestions = await _context.Questions.Include(q => q.Answers).ToListAsync();

            foreach (var question in allQuestions)
            {
                var correctAnswer = question.Answers.First(a => a.IsCorrect);
                var userAnswerId = answers.GetValueOrDefault(question.Id);
                var userAnswer = userAnswerId > 0 ? question.Answers.FirstOrDefault(a => a.Id == userAnswerId) : null;

                results.Add(new ResultViewModel
                {
                    QuestionText = question.QuestionText,
                    CorrectAnswerText = correctAnswer.AnswerText,
                    UserAnswerText = userAnswer?.AnswerText ?? "Нет ответа",
                    IsCorrect = userAnswer != null && userAnswer.IsCorrect
                });
            }

            ViewData["Score"] = results.Count(r => r.IsCorrect);
            ViewData["Total"] = allQuestions.Count;
            HttpContext.Session.Remove(AnswersKey);
            HttpContext.Session.Remove("QuestionIds");

            return View("Result", results);
        }
    }
} 