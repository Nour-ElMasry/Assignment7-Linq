using System;
using System.Linq;
using Vehicles;


var carsList = Car.GenerateCars();

var FilterByProductionDate = carsList.Where(c => c.ProductionDate.Year <= 2019)
    .OrderByDescending(c => c.ProductionDate)
    .Select(c => new { c.Manufacturer, c.ProductionDate.Year });

//printThis(FilterByProductionDate);

var tmpListOfYears = new List<DateTime>
{
    new DateTime(2019,1,1),
    new DateTime(2011,2,2)
};

var joinBothLists = from p in carsList
                    join ls in tmpListOfYears
                    on p.ProductionDate.Year equals ls.Year
                    select new
                    {
                        p.Manufacturer,
                        p.ProductionDate.Year
                    };

//printThis(joinBothLists);

var tmpStrings = new List<string> 
{ 
    "Car 1",
    "Car 2",
    "Car 3"
};

var zipTest = FilterByProductionDate.Zip(tmpStrings, (c, y) => c.ToString() + " - " + y);

//printThis(zipTest);

var orderingTest = carsList.OrderByDescending(c => c.Price)
    .ThenBy(c => c.ProductionDate.Year)
    .Reverse();

//printThis(orderingTest);

var groupByTest = carsList.GroupBy(c => c.Manufacturer);

//foreach(var group in groupByTest)
//{
//    Console.WriteLine(group.Key + " : " + group.Count() + "\n");

//    printThis(group);
//    Console.WriteLine("\n");
//}

var convertionMethod = carsList.ToDictionary(c => c.Id, c => c.Model);

//printThis(convertionMethod);

var elementOperators = orderingTest.First(c => c.Manufacturer == "Volkswagen");

//printThis(orderingTest);
//Console.WriteLine("\n/////////////////////////\n\nFirst Volkswagen in list is:");
//Console.WriteLine(elementOperators);

var AggregationMethods = orderingTest.Sum(c => c.Price);

var AggregationMethods2 = orderingTest.Average(c => c.Price);

//Console.WriteLine($"Sum of all car prices: {AggregationMethods}");
//Console.WriteLine($"Average price of cars in list: {AggregationMethods2}");

var quantifiers = carsList.All(c => c.ProductionDate.Year > 2010);

var quantifiers2 = FilterByProductionDate.Contains(joinBothLists.Last());

var quantifiers3 = carsList.Any(c => c.ProductionDate.Year < 2015);

//Console.WriteLine($"All cars manufacutured after 2010? -> {quantifiers}");
//Console.WriteLine($"Does last element from joinBothLists list exist in FilterByProductionDate List? -> {quantifiers2}");
//Console.WriteLine($"Any cars manufactured before 2015? -> {quantifiers3}");

static void printThis<T>(IEnumerable<T> items) 
{
    foreach (T item in items)
    {
        Console.WriteLine(item);
    }
}