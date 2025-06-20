<div align="center">

  <h1>EducationalPractice</h1>
  <p>🎮 Простая игра на Windows Forms с модульным тестированием и стартовым меню</p>

  <a href="#"><img src="https://img.shields.io/badge/version-1.0.0-blue" /></a> 
  <a href="#"><img src="https://img.shields.io/badge/platform-Windows-blue"  /></a>
  <a href="#"><img src="https://img.shields.io/badge/.NET-9.0-red"  /></a>
  <a href="#"><img src="https://img.shields.io/badge/license-MIT-green"  /></a>
  <a href="#"><img src="https://img.shields.io/badge/tests-passed-brightgreen"  /></a>
</div>

---

## 🧩 Описание

**EducationalPractice** — это обучающий проект, реализующий простую 2D игру с элементами управления, столкновений и логикой появления врагов.

Игра разработана с применением принципов ООП, паттерна "Фабрика", и покрыта **модульными тестами через NUnit**.


---

## 💡 Функции 

| Возможность        | Описание |
|--------------------|----------|
| 🎨 Выбор персонажа | Цвет игрока выбирается в стартовом меню |
| ⌨️ Управление      | WASD / стрелки |
| 💣 Ловушки         | Space — установка бомбы |
| 🤖 Враги           | Появляются случайно и двигаются хаотично |
| ⏱ Таймер           | Отсчёт времени и завершение игры |
| 🔥 Столкновения     | Проверка столкновений между игроком и врагами |
| 🧪 Тестирование     | Модульные тесты (NUnit) |

---

## 🛠 Технологии

| Технология       | Версия   |
|------------------|----------|
| .NET             | 9.0      |
| Windows Forms    | Built-in |
| NUnit            | 3.14.0   |
| C#               | 12.0     |
| Git + GitHub     | CI/CD    |

---

## 🛠 Как запустить проект

1. Убедись, что установлен [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) 
2. Клонируй репозиторий:
   git clone https://github.com/ваше-имя/EducationalPractice.git 
   cd EducationalPractice

3. Запусти проект:
   dotnet run

4. Для запуска тестов:
   cd EducationalPractice.Tests
   dotnet test

## 🧪 Результаты тестирования

Все тесты прошли успешно ✅
Test Run Successful.
Total tests: 10. Passed: 10. Failed: 0. Skipped: 0.
Test execution time: 2.187 seconds

См. файл `Tests.txt` или результаты в CI (если подключён GitHub Actions)
