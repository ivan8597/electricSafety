# ElectricalSafetyQuiz

Веб-приложение для проверки знаний по электробезопасности для неэлектрического персонала.

## Возможности
- 9 вопросов с вариантами ответов (один правильный)
- Пошаговый режим: пользователь отвечает на вопросы по одному, пропуск невозможен
- Кнопка "Далее" активна только после выбора ответа
- Подробный результат с указанием правильных/неправильных ответов
- Современный адаптивный дизайн (Bootstrap + кастомные стили)
- Поддержка мобильных устройств
- Безопасное хранение строки подключения (Secret Manager)
- Готовность к интеграции с ERP Epicor через REST API

## Быстрый старт

1. **Клонируйте репозиторий:**
   ```bash
   git clone <ваш-репозиторий>
   cd ElectricalSafetyQuiz
   ```
2. **Установите зависимости:**
   ```bash
   dotnet restore
   ```
3. **Настройте строку подключения (используется SQLite):**
   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "DataSource=quiz.db"
   ```
4. **Запустите приложение:**
   ```bash
   dotnet run
   ```
5. **Откройте браузер:**
   Перейдите по адресу, который появится в консоли (например, http://localhost:5127)

## Структура проекта
- `Controllers/QuizController.cs` — логика теста
- `Models/` — модели данных и ViewModel для результатов
- `Data/QuizDbContext.cs`, `Data/SeedData.cs` — база данных и начальное заполнение
- `Views/Quiz/Question.cshtml` — пошаговый вывод вопросов
- `Views/Quiz/Result.cshtml` — страница результатов
- `wwwroot/css/site.css` — стили, включая мобильную адаптацию

## Безопасность
- Строка подключения хранится через Secret Manager (`dotnet user-secrets`)
- Все запросы к базе данных через Entity Framework Core (защита от SQL-инъекций)
- Для SQLite доступ ограничен правами на файл

## Мобильная версия
- Используется Bootstrap и медиазапросы для адаптивности
- Крупные кнопки, увеличенные отступы, удобная навигация на телефоне

## Интеграция с ERP Epicor (пример)
1. Добавьте настройки API Epicor в секреты:
   ```bash
   dotnet user-secrets set "Epicor:ApiUrl" "https://your-epicor-server.com/api/v2/odata/YourCompany/"
   dotnet user-secrets set "Epicor:ApiKey" "YOUR_SECRET_API_KEY_HERE"
   ```
2. Реализуйте сервис для отправки результатов в Epicor через REST API (см. документацию Epicor)

