# TravelLineHttpHandler
## Описание
Представлен репозиторий в котором хранится библиотека для очистки secure данных из http запросов релизованная по паттерну Фабрика. 

### В директории **TravelLineHttpHandler** хранятся следующие файлы:

1. HttpResult.cs - класс http запроса, который имеет три свойства представляющие собой разные виды веб запросов;
2. RequestCleaner.cs - класс обработки запроса, позволяет использовать разные фабрики для обработки;
3. HttpHandlerLog.cs - класс логирования http запроса. Secure данные очищаются уже внутри класса перед логированием.
4. В директории **ConcreteCleaner** хранятся классы, реализующие интерфейс ICleaner;
5. В директории **ConcreteFactories** хранится класс, реализующий интерфейс ICleanerFactory;
6. В директории **Interfaces** хранятся интерфейсы ICleaner и ICleanerFactory:
* ICleaner.cs - интерфейс, который должны реализовать классы по очистке разных видов строк: XML, JSON и т.д.;
* ICleanerFactory.cs - интерфейс класса фабрики;

### В директории **TravelLineHttpHandlerTests** хранятся следующие файлы:

1. RequestCleanerTest.cs - файл тестирования класса RequestCleanerTest;
2. HttpHandlerLogTests.cs - файл тестирования класса HttpHandlerLog.
