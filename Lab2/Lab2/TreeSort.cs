namespace Lab2;

public class TreeSort
{
    public void Sorting(int[] arr)
    {
        var n = arr.Length;

        // Построение кучи (перегруппируем массив)
        for (var i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);

        // Один за другим извлекаем элементы из кучи
        for (var i=n-1; i>=0; i--)
        {
            // Перемещаем текущий корень в конец
            (arr[0], arr[i]) = (arr[i], arr[0]);

            // вызываем процедуру heapify на уменьшенной куче
            heapify(arr, i, 0);
        }
    }

    // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
    // индексом в arr[]. n - размер кучи

    private void heapify(int[] arr, int n, int i)
    {
        var largest = i;
        // Инициализируем наибольший элемент как корень
        var l = 2*i + 1; // left = 2*i + 1
        var r = 2*i + 2; // right = 2*i + 2

        // Если левый дочерний элемент больше корня
        if (l < n && arr[l] > arr[largest])
            largest = l;

        // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
        if (r < n && arr[r] > arr[largest])
            largest = r;

        // Если самый большой элемент не корень
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);

            // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
            heapify(arr, n, largest);
        }
    }
}
