using System.Text;
using HungaryanAlgoritm.classes;

var hun = new Hungaryan(); 

// Пример работы алгоритма.
// 5 6 2
// 8 1 8 -> Наш выбор: (0,2), (1,1), (2,0) или 3 на первую работу, 1 на вторую и 2 на третью.
// 3 4 3
var matrix = new List<List<int>>(){new List<int>() {5, 8, 3}, new List<int>() {6, 1, 4}, new List<int>() {2, 8, 3}};
var a = hun.hungarian(matrix);
var result = new StringBuilder();

Console.WriteLine("\nМатрица работ и стоимости: ");
for (var i = 0; i < matrix.Count; i++)
{
    for (var j = 0; j < matrix[0].Count; j++)
    {
        Console.Write(matrix[j][i] + " ");
    }
    
    Console.Write("\n");
}
Console.Write("\n");

for (var i = 0; i < matrix.Count; i++)
{
    result.Append($"Работа {i + 1}: \n");
    result.Append("\tЦена: ");
    result.Append(matrix[i][a[i][1]]);
    result.Append("\n\tРаботник: ");
    result.Append(a[i][1] + 1);
    result.Append('\n');
}

Console.WriteLine(result);

Console.Read();