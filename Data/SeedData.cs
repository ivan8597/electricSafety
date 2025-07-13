using ElectricalSafetyQuiz.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ElectricalSafetyQuiz.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new QuizDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<QuizDbContext>>()))
            {
                // Look for any questions.
                if (context.Questions.Any())
                {
                    return;   // DB has been seeded
                }

                context.Questions.AddRange(
                    new Question
                    {
                        QuestionText = "Что из перечисленного не является средством индивидуальной защиты от поражения электрическим током?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Диэлектрические перчатки", IsCorrect = false },
                            new Answer { AnswerText = "Защитные очки", IsCorrect = true },
                            new Answer { AnswerText = "Изолирующая штанга", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Какое напряжение считается безопасным для человека в сухом помещении?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "До 12 В", IsCorrect = false },
                            new Answer { AnswerText = "До 42 В", IsCorrect = true },
                            new Answer { AnswerText = "До 220 В", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Что необходимо сделать в первую очередь при обнаружении человека, пораженного электрическим током?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Оказать первую помощь", IsCorrect = false },
                            new Answer { AnswerText = "Вызвать скорую помощь", IsCorrect = false },
                            new Answer { AnswerText = "Обесточить источник тока", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Какой знак предупреждает об опасности поражения электрическим током?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Треугольник с молнией", IsCorrect = true },
                            new Answer { AnswerText = "Круг с перечеркнутой сигаретой", IsCorrect = false },
                            new Answer { AnswerText = "Квадрат с изображением огня", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Можно ли тушить водой электроприборы, находящиеся под напряжением?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Да, если вода дистиллированная", IsCorrect = false },
                            new Answer { AnswerText = "Категорически запрещено", IsCorrect = true },
                            new Answer { AnswerText = "Можно, если быстро", IsCorrect = false }
                        }
                    },
                     new Question
                    {
                        QuestionText = "Что означает знак 'Заземлено'?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Прибор имеет двойную изоляцию", IsCorrect = false },
                            new Answer { AnswerText = "Корпус прибора соединен с землей", IsCorrect = true },
                            new Answer { AnswerText = "Прибор работает от батареек", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        QuestionText = "На какое минимальное расстояние безопасно приближаться к оборванному проводу, лежащему на земле?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "1 метр", IsCorrect = false },
                            new Answer { AnswerText = "3 метра", IsCorrect = false },
                            new Answer { AnswerText = "8 метров", IsCorrect = true }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Можно ли пользоваться неисправными розетками или выключателями?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Можно, если осторожно", IsCorrect = false },
                            new Answer { AnswerText = "Нет, это опасно", IsCorrect = true },
                            new Answer { AnswerText = "Можно, если нет детей", IsCorrect = false }
                        }
                    },
                    new Question
                    {
                        QuestionText = "Какое действие является правильным при замене лампочки?",
                        Answers = new List<Answer>
                        {
                            new Answer { AnswerText = "Выключить свет выключателем", IsCorrect = false },
                            new Answer { AnswerText = "Обесточить квартиру/дом на щитке", IsCorrect = true },
                            new Answer { AnswerText = "Надеть резиновые перчатки", IsCorrect = false }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
} 