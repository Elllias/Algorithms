namespace Lab2;

public class QSort {
    static void Swap(ref int a, ref int b) {
        (a, b) = (b, a);
    }
    
    public static void Sorting(int[] array, int firstIndex = 0, int lastIndex = -1) 
    {
        if ( lastIndex < 0 )
            lastIndex = array.Length - 1;
        
        if ( firstIndex >= lastIndex )
            return;
        
        int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex, currentIndex = firstIndex;
        Swap(ref array[firstIndex], ref array[middleIndex]);
        
        for ( int i = firstIndex + 1; i <= lastIndex; ++i ) {
            if ( array[i] <= array[firstIndex] ) {
                Swap(ref array[++currentIndex], ref array[i]);
            }
        }
        
        Swap(ref array[firstIndex], ref array[currentIndex]);
        QSort.Sorting(array, firstIndex, currentIndex - 1);
        QSort.Sorting(array, currentIndex + 1, lastIndex);
    }
}