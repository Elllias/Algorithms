namespace Lab2;

public class BubbleSort
{
    public static int[] Sorting(int[] mas)
    {
        int temp;
        for (int i = 0; i < mas.Length; i++)
        {
            for (int j = i + 1; j < mas.Length; j++)
            {
                if (mas[i] > mas[j])
                {
                    temp = mas[i];
                    mas[i] = mas[j];
                    mas[j] = temp;
                }                   
            }            
        }
        return mas;
    }
}