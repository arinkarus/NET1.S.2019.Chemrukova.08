# Задания

1. **(deadline - 05.04.2019, 24.00)**(*"3-ий перезапуск" НОД-а*) Есть унификация алгоритма нахождения НОД-а для двух целочисленных значений в виде интерфейса 

		 public interface IGcdAlgorithm
		 {
		     int Calculate(int first, int second);
		 }
		 
c реализацией в виде классов EuclideanGcdAlgorithm и BinaryGcdAlgorithm (доступ к коду классов для их измения не возможен, назовем эту сборку условно *#1.dll*). Предложить варианты расширения функциональности существующих (и новых) алгоритмов вычисления НОД-а, предлагающие возможность при вычислении определять показания времени работы алгоритма, рассмотреть возможность настройки алгоритма в контексте предоставления различных реализаций измерения времени.(Решения поместить в сборку *#2.dll*).

2. **(deadline - 06.04.2019 24.00)** Добавить в статический класс ArrayExtension ([Day 7](https://github.com/AnzhelikaKravchuk/.NET-Training.-Spring-2019/tree/master/Day%207%20-%2002.04.2019)) метод расширения для сортировки непрямоугольного ("jagged") целочисленного массива (матрицы) таким образом, чтобы была возможность, в частности, упорядочить строки матрицы:
   - в порядке возрастания(убывания) сумм элементов ее строк;
   - в порядке возрастания(убывания) максимальных элементов ее строк;
   - в порядке возрастания(убывания) минимальных элементов ее строк.
   
   Разработать unit-тесты.

3. **(deadline - 07.04.2019 24.00)** 
- Разработать класс Book (ISBN, автор, название, издательство, год издания, количество страниц, цена), переопределив для него необходимые методы класса Object. Для объектов класса реализовать отношения эквивалентности и порядка (используя соответствующие интерфейсы). 

		public class Book : IEquatable<Book>, IComparable<Book>
		{
		    public string Author { get; set; }
		    public string Title { get; set; }
		    ...
		}
		
Для выполнения основных операций со набором книг, который можно загрузить (Load) и, если возникнет необходимость, сохранить (Save) в некоторое хранилище BookListStorage разработать класс BookListService (как сервис для работы с коллекцией книг) с функциональностью Add (добавить книгу, если такой книги нет, в противном случае выбросить исключение); Remove (удалить книгу, если она есть, в противном случае выбросить исключение); FindByTag (найти книги по заданному критерию); SortBy (отсортировать список книг по заданному критерию), при реализации делегаты не использовать! 
		
		public interface IBookListStorage
		{
		    IEnumerable<Book> Load();
		    void Save(IEnumerable<Book> books);
		}
		
- В качестве хранилища пока использовать FakeBookListStorage как обертку для списка книг, который хранится в памяти ("in memory dataset"). Данное хранилище пока используется для целей тестирования. В дальнейшем хранилище будет изменяться.
- **(deadline - 08.04.2019 24.00)** Продемонстрировать возможности работы с системой типов в ASP.NET MVC приложении.

## Реализация
1. - [Алгоритмы](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/GCDAlgorithms)
   - [Расширение работы с подсчетом времени](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/GcdAlgorithmExtension)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/GcdAlgoritms.Tests)
2. - [Обобщенный метод SortBy](https://github.com/arinkarus/NET1.S.2019.Chemrukova.07/blob/master/ArrayExtension/ArrayExtension.cs)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.07/blob/master/ArrayExtension.Tests/ArrayExtensionTests.cs)
3. - [Решение](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/Books)
   - [Тесты](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/Books.Tests)
   - [MVC](https://github.com/arinkarus/NET1.S.2019.Chemrukova.08/tree/master/Books.MVC)
