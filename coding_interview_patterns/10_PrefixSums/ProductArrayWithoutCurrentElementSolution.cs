// «Паттерны Coding Interview», глава 10: листинги, адаптированные для C# / .NET 10.
namespace CodingInterviewPatterns.PrefixSums;

public static class ProductArrayWithoutCurrentElementSolution {
    public static int[] ProductArrayWithoutCurrentElement(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        Array.Fill(res, 1);
        // Заполняем выходной массив произведениями элементов
        // слева.
        for (int i = 1; i < n; i++) {
            res[i] = res[i - 1] * nums[i - 1];
        }
        // Умножаем элементы выходного массива на произведения
        // элементов справа (двигаемся справа налево).
        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--) {
            res[i] *= rightProduct;
            rightProduct *= nums[i];
        }
        return res;
    }
}
