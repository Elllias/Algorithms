namespace HungaryanAlgoritm.classes;

public class Hungaryan
{
     public List<List<int>> hungarian(List<List<int>> matrix)
     {
         var height = matrix.Count;
         var width = matrix[0].Count;
 
         var u = new List<int>(height); // Значения, вычитаемые из строк.
         var v = new List<int>(width); // Значения, вычитаемые из столбцов.
         
         for (var x = 0; x < height; x++)
             u.Add(0);
         for (var x = 0; x < width; x++)
             v.Add(0);
         
         // Индекс помеченной клетки в каждом столбце.
         var zeroIndexes = new List<int>(width);
         for (var x = 0; x < width; x++)
             zeroIndexes.Add(-1);
         
         for (var i = 0; i < height; i++)
         {
             var links = new List<int>(width); // Тут будут храниться ссылки на пред. столбец.
             var mins = new List<int>(width); // Тут хранится минимальное значение в текущем столбце.
             var visited = new List<int>(width); // Массив посещенных стобцов.
 
             for (var a = 0; a < width; a++)
             {
                 links.Add(-1);
                 mins.Add(int.MaxValue);
                 visited.Add(0);
             }
             
             var markedI = i; // i последнего посещенного элемента
             var markedJ = -1; // j последнего посещенного элемента
             var j = 0;
             
             while (markedI != -1)
             {
                 j = -1;
                 
                 for (var j1 = 0; j1 < width; j1++)
                     if (visited[j1] != 1)
                     {
                         // Находим минимальный элемент в строке.
                         // Добавляем ссылку на пред. элемент в графе.
                         // В j добавим индекс столбца с самым маленьким минимумом.
                         if (matrix[markedI][j1] - u[markedI] - v[j1] < mins[j1])
                         {
                             mins[j1] = matrix[markedI][j1] - u[markedI] - v[j1];
                             links[j1] = markedJ;
                         }
                         if (j == -1 || mins[j1] < mins[j])
                             j = j1;
                     }
                 
                 // Произведем манипуляции со строками и столбцами так, чтобы обнулился (markIndices[links[j]], j)
                 // (markIndices[links[j]], j) - это будущий ноль, по которому мы востановим минимумы.
                 for (var j1 = 0; j1 < width; j1++)
                     if (visited[j1] == 1)
                     {
                         u[zeroIndexes[j1]] += mins[j];
                         v[j1] -= mins[j];
                     }
                     else
                     {
                         mins[j1] -= mins[j];
                     }
                 u[i] += mins[j];
                 
                 visited[j] = 1;
                 markedJ = j;
                 markedI = zeroIndexes[j];
             }
 
             // Пройдем по найденной цепочке клеток, поставим отметки на неотмеченные клетки.
             for (; links[j] != -1; j = links[j])
                 zeroIndexes[j] = zeroIndexes[links[j]];
             zeroIndexes[j] = i;
         }
         
         // Востанавливаем ответ.
         var result = new List<List<int>>();
         for (var j = 0; j < width; j++)
             if (zeroIndexes[j] != -1)
                 result.Add(new List<int>() { j, zeroIndexes[j]});
         return result;
     }
}