# TravelLineHttpHandler
## Описание
Репозиторий в котором хранится библиотека для очистки secure данных из http запросов. 

В директории **TravelLineHttpHandler** хранятся следующие файлы:

1. HttpResult.cs - файл http запроса, который имеет три свойства представляющие собой разные виды веб запросов;
2. ClearingHttp.cs - файл библиотека предназначенный для очистки http запроса от secure данных, таких как например имя пользователя и его пароль;
3. HttpHandlerLog.cs - файл логирования http запроса. Secure данные очищаются уже внутри класса перед логированием.

В директории **TravelLineHttpHandlerTests** хранятся следующие файлы:

1. ClearingHttpTests.cs - файл тестирования класса ClearingHttp;
2. HttpHandlerLogTests.cs - файл тестирования класса HttpHandlerLog;
